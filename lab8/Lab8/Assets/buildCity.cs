using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{

    public GameObject[] buildings;
    public int mapWidth = 15;
    public int mapHeight = 15;
    public int buildingSpacing = 3;
    public float noiseDivider = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        float seed = 256;//Random.Range(0, 1024);
        for(int height = 0; height < mapHeight; height++)
        {
            for(int width = 0; width < mapWidth; width++)
            {
                Vector3 position = new Vector3(width * buildingSpacing, 0, height * buildingSpacing);
                int randomBuildingNoise = (int)(Mathf.PerlinNoise(width/noiseDivider + seed, height/noiseDivider + seed) * 10);

                if (randomBuildingNoise < 2) CreateBuilding(0, position);
                else if (randomBuildingNoise < 4) CreateBuilding(1, position);
                else if (randomBuildingNoise < 5) CreateBuilding(2, position);
                else if (randomBuildingNoise < 7) CreateBuilding(3, position);
                else if (randomBuildingNoise < 8)  CreateBuilding(4, position);
                else if (randomBuildingNoise < 10) CreateBuilding(5, position);
            }
        }
    }


    void CreateBuilding(int index, Vector3 localPosition)
    {      
        Instantiate(buildings[index], localPosition, Quaternion.identity);
    }


}
