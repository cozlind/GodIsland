using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {

    Terrain terrain;
    TerrainData terrainData;
    public static float[,] heights;
    private int height, width;
    float[,,] splatmapData;

    public GameObject peoplePfb;
    public GameObject treePfb;
    public GameObject titanPfb;
    GameObject titan;
    public Transform camera;

    [SerializeField]
    HumanManager humanManager;

    [SerializeField]
    List<HumanStatus> StartHumanStatusList = new List<HumanStatus>();

    void Start () {
        terrain = GetComponent<Terrain>();
        terrainData = terrain.terrainData;
        width = terrain.terrainData.heightmapWidth;
        height = terrain.terrainData.heightmapHeight;
        heights = terrain.terrainData.GetHeights(0, 0, width, height);



        // Splatmap data is stored internally as a 3d array of floats, so declare a new empty array ready for your custom splatmap data:
        splatmapData = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                AlphaMap(x, y);
            }
        }
        // Finally assign the new splatmap to the terrainData:
        terrainData.SetAlphamaps(0, 0, splatmapData);


        SpawnPeople();
        SpawnTrees();
        //SpawnTitan();
        if( titan == null )
        {
            titan = GameObject.FindObjectOfType<BlackGiant>().gameObject;
        }
        camera.transform.position=new Vector3(titan.transform.position.x+8, titan.transform.position.y +10, titan.transform.position.z + 8);
        camera.LookAt(titan.transform);
    }
    [Range(0,0.005f)]
    public float brushStrength = 0.05f;
    [Range(0,300)]
    public int brushRadius = 100;
    float time=0;
    public float updateTime = 0.3f;
    public float scale=0;

    void Update () {
        if (Time.time - time < updateTime) return;
        time = updateTime;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0)&&Physics.Raycast(ray,out hit)&&hit.collider!=null)
        {
            int pointY = (int)(hit.point.x*terrain.terrainData.heightmapWidth/terrain.terrainData.size.x);
            int pointX = (int)(hit.point.z * terrain.terrainData.heightmapHeight / terrain.terrainData.size.z);

            for (int i = -brushRadius; i <= brushRadius; i++)
            {
                for(int j = -brushRadius; j <= brushRadius; j++)
                {
                    float distance = Mathf.Sqrt(i * i + j * j);
                    if (distance <= brushRadius)
                    {
                        if (pointX + i < 0 || pointX + i >= width || pointY + j < 0 || pointY + j >= height) continue;
                        heights[pointX+i, pointY+j] += brushStrength * (brushRadius - distance) / brushRadius;
                        AlphaMap(pointX + i, pointY + j);
                    }
                }
            }
            terrain.terrainData.SetHeights(0, 0, heights);
            terrainData.SetAlphamaps(0, 0, splatmapData);
        }
        else if (Input.GetKey(KeyCode.LeftAlt)&&Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.collider != null)
        {
            int pointY = (int)(hit.point.x * terrain.terrainData.heightmapWidth / terrain.terrainData.size.x);
            int pointX = (int)(hit.point.z * terrain.terrainData.heightmapHeight / terrain.terrainData.size.z);

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
                        AlphaMap(pointX + i, pointY + j);
                    }
                }
            }
            terrain.terrainData.SetHeights(0, 0, heights);
            terrainData.SetAlphamaps(0, 0, splatmapData);
        }
    }
   
    void AlphaMap(int x,int y)
    {
        // Normalise x/y coordinates to range 0-1 
        float y_01 = (float)y / (float)terrainData.alphamapHeight;
        float x_01 = (float)x / (float)terrainData.alphamapWidth;

        // Sample the height at this location (note GetHeight expects int coordinates corresponding to locations in the heightmap array)
        float height = terrainData.GetHeight(Mathf.RoundToInt(y_01 * terrainData.heightmapHeight), Mathf.RoundToInt(x_01 * terrainData.heightmapWidth));

        // Calculate the normal of the terrain (note this is in normalised coordinates relative to the overall terrain dimensions)
        Vector3 normal = terrainData.GetInterpolatedNormal(y_01, x_01);

        // Calculate the steepness of the terrain
        float steepness = terrainData.GetSteepness(y_01, x_01);

        // Setup an array to record the mix of texture weights at this point
        float[] splatWeights = new float[terrainData.alphamapLayers];

        // CHANGE THE RULES BELOW TO SET THE WEIGHTS OF EACH TEXTURE ON WHATEVER RULES YOU WANT

        // Texture[0] has constant influence
        splatWeights[0] = 0.5f;

        // Texture[1] is stronger at lower altitudes
        splatWeights[1] = Mathf.Clamp01((terrainData.heightmapHeight - height));

        // Texture[2] stronger on flatter terrain
        // Note "steepness" is unbounded, so we "normalise" it by dividing by the extent of heightmap height and scale factor
        // Subtract result from 1.0 to give greater weighting to flat surfaces
        splatWeights[2] = 1.0f - Mathf.Clamp01(steepness * steepness / (terrainData.heightmapHeight / 5.0f));

        // Texture[3] increases with height but only on surfaces facing positive Z axis 
        splatWeights[3] = height * Mathf.Clamp01(normal.z);

        // Sum of all textures weights must add to 1, so calculate normalization factor from sum of weights
        float z = 0;
        for (int i = 0; i < splatWeights.Length; i++)
        {
            z += splatWeights[i];
        }

        // Loop through each terrain texture
        for (int i = 0; i < terrainData.alphamapLayers; i++)
        {

            // Normalize so that sum of all texture weights = 1
            splatWeights[i] /= z;

            // Assign this point to the splatmap array
            splatmapData[x, y, i] = splatWeights[i];
        }
    }

    public int peopleNum = 3;
    void SpawnPeople()
    {
        for (int i = 0; i< peopleNum; i++){
            int posX, posY;
            int rectX = (int)terrain.terrainData.size.x / 4;
            int rectY = (int)terrain.terrainData.size.y / 4;

            int rectWidth = (int)terrain.terrainData.size.x / 2;
            int rectHeight = (int)terrain.terrainData.size.y / 2;
            /*
            do
            {
                //posX = Random.Range(width / 2-70, width / 2 + 70);
                //posY = Random.Range(height / 2 - 70, height / 2 + 70);
                posX = Random.Range(rectX, rectWidth);
                posY = Random.Range(rectY, rectHeight);

            }
            while (heights[posX, posY] < 30f/600f);
    */
            int heightpersent = (int)( terrainData.heightmapWidth/ terrain.terrainData.size.x);
            posX = Random.Range(rectX, rectWidth);
             
            int posZ = Random.Range(rectY, rectHeight);
            posY = (int)terrainData.GetHeight(posX*5, posZ*5); ;
            //Vector3 position = new Vector3(posX, heights[posX, posY] * 600 + 5, posY);
            Vector3 position = new Vector3(posX, posY, posZ);
            HumanStatus humanStatus = new HumanStatus();
            if ( StartHumanStatusList.Count > i )
            {
                Debug.logger.Log("humanstatus setting error");
                humanStatus = StartHumanStatusList[i];
            }
            humanManager.Create( humanStatus, position );
            //GameObject people = Instantiate(peoplePfb, new Vector3(posX, heights[posX, posY] * 600 + 5, posY),Quaternion.identity) as GameObject;

        }
    }
    public int treeNum = 3;
    void SpawnTrees()
    {
        for (int i = 0; i < treeNum; i++)
        {
            int posX, posY;
            do
            {
                posX = Random.Range(width / 2 - 80, width / 2 + 80);
                posY = Random.Range(height / 2 - 80, height / 2 + 80);
            }
            while (heights[posX, posY] < 30f / 600f);

            GameObject tree = Instantiate(treePfb, new Vector3(posX, heights[posX, posY] * 600+5 , posY), Quaternion.identity) as GameObject;
        }
    }
    void SpawnTitan()
    {
        int posX, posY;
        do
        {
            posX = Random.Range(width / 2 - 50, width / 2 + 50);
            posY = Random.Range(height / 2 - 50, height / 2 + 50);
        }
        while (heights[posX, posY] < 30f / 600f);

        titan = Instantiate(titanPfb, new Vector3(posX, heights[posX, posY] * 600 + 5, posY), Quaternion.identity) as GameObject;
    }
}
