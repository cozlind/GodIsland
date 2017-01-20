using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTest : MonoBehaviour {

    public Terrain terrain;
    public static float[,] heights;
    private int height, width;
	void Start () {
        terrain = GetComponent<Terrain>();
        width = terrain.terrainData.heightmapWidth;
        height = terrain.terrainData.heightmapHeight;
        heights = terrain.terrainData.GetHeights(0, 0, width, height);
	}
    [Range(0,0.015f)]
    public float brushStrength = 0.05f;
    [Range(0,300)]
    public int brushRadius = 100;
    float time=0;
    public float updateTime = 0.3f;
	void Update () {
        if (Time.time - time < updateTime) return;
        time = updateTime;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0)&&Physics.Raycast(ray,out hit)&&hit.collider!=null)
        {
            int pointY = (int)hit.point.x;
            int pointX = (int)hit.point.z;

            for(int i = -brushRadius; i <= brushRadius; i++)
            {
                for(int j = -brushRadius; j <= brushRadius; j++)
                {
                    float distance = Mathf.Sqrt(i * i + j * j);
                    if (distance <= brushRadius)
                    {
                        if (pointX + i < 0 || pointX + i >= width || pointY + j < 0 || pointY + j >= height) continue;
                        heights[pointX+i, pointY+j] += brushStrength * (brushRadius - distance) / brushRadius;
                    }
                }
            }
            terrain.terrainData.SetHeights(0, 0, heights);
        }
        else if (Input.GetMouseButton(1) && Physics.Raycast(ray, out hit) && hit.collider != null)
        {
            int pointY = (int)hit.point.x;
            int pointX = (int)hit.point.z;

            for (int i = -brushRadius; i <= brushRadius; i++)
            {
                for (int j = -brushRadius; j <= brushRadius; j++)
                {
                    float distance = Mathf.Sqrt(i * i + j * j);
                    if (distance <= brushRadius)
                    {
                        if (pointX + i<0||pointX + i >= width || pointY + j<0||pointY + j >= height) continue;
                        heights[pointX + i, pointY + j] -= brushStrength * (brushRadius - distance) / brushRadius;
                        if (heights[pointX + i, pointY + j] < 0) heights[pointX + i, pointY + j] = 0;
                    }
                }
            }
            terrain.terrainData.SetHeights(0, 0, heights);
        }

    }
}
