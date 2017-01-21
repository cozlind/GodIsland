using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPathFinding : MonoBehaviour {

    //three most important parameters about path finding
    [Range(0, 10)]
    public float maxAccessHeight = 0.1f;
    public static float peopleHeight = 0.7f;
    public static float waypointDistance = 1.4f;

    Grid gridScript;
    public Unit unitScript;
    public TerrainManager terrainScript;
    
    void Start()
    {
        gridScript = GetComponent<Grid>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DynamicAStar();
        }
    }

    public void DynamicAStar()
    {
        GenerateGrid();
        PathRequestManager.RequestPath(unitScript.transform.position, unitScript.target.position, unitScript.OnPathFound);
    }
    void GenerateGrid()
    {
        gridScript.grid = new Node[gridScript.gridSizeX, gridScript.gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridScript.gridWorldSize.x / 2 - Vector3.forward * gridScript.gridWorldSize.y / 2;
        for (int x = 0; x < gridScript.gridSizeX; x++)
        {
            for (int y = 0; y < gridScript.gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * gridScript.nodeDiameter + gridScript.nodeRadius) + Vector3.forward * (y * gridScript.nodeDiameter + gridScript.nodeRadius);

                int pointY = Mathf.RoundToInt(worldPoint.x * terrainScript.width / terrainScript.terrainData.size.x);
                int pointX = Mathf.RoundToInt(worldPoint.z * terrainScript.height / terrainScript.terrainData.size.z);
                float currentHeight = terrainScript.heights[pointX, pointY] * terrainScript.terrainData.size.y;

                worldPoint.Set(worldPoint.x, currentHeight, worldPoint.z);

                //bool walkable = !(Physics.CheckSphere(worldPoint, gridScript.nodeRadius, gridScript.unwalkableMask));

                //int movementPenalty = 0;


                //Ray ray = new Ray(worldPoint + Vector3.up * 50, Vector3.down);
                //RaycastHit hit;
                //if (Physics.Raycast(ray, out hit, 100, gridScript.walkableMask))
                //{
                //    gridScript.walkableRegionsDictionary.TryGetValue(hit.collider.gameObject.layer, out movementPenalty);
                //}

                //if (!walkable)
                //{
                //    movementPenalty += gridScript.obstacleProximityPenalty;
                //}


                gridScript.grid[x, y] = new Node(true, worldPoint, x, y, 0);




                //gridScript.grid[x, y] = new Node(walkable, worldPoint, x, y, movementPenalty);
            }
        }

        gridScript.BlurPenaltyMap(3);
    }


}
