using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{

    public GameObject[] buildings;
    public int mapWidth = 15;
    public int mapHeight = 15;
    public int buildingSpacing = 3;
    int[,] mapgrid;
    public float noiseDivider = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        float seed = Random.Range(0, 1024);
        mapgrid = new int[mapWidth, mapHeight];
        for (int height = 0; height < mapHeight; height++)
        {
            for (int width = 0; width < mapWidth; width++)
            {

                mapgrid[width, height] = (int)(Mathf.PerlinNoise(width / noiseDivider + seed, height / noiseDivider + seed) * 15);


            }
        }



        for (int height = 0; height < mapHeight; height++)
        {
            for (int width = 0; width < mapWidth; width++)
            {
                Vector3 position = new Vector3(width * buildingSpacing, 0, height * buildingSpacing);
                if (mapgrid[width, height] < 2) Instantiate(buildings[0], position, Quaternion.identity);
                else if (mapgrid[width, height] < 4) Instantiate(buildings[1], position, Quaternion.identity);
                else if (mapgrid[width, height] < 5) Instantiate(buildings[2], position, Quaternion.identity);
                else if (mapgrid[width, height] < 7) Instantiate(buildings[3], position, Quaternion.identity);
                else if (mapgrid[width, height] < 8) Instantiate(buildings[4], position, Quaternion.identity);
                else if (mapgrid[width, height] < 9) Instantiate(buildings[5], position, Quaternion.identity);
                else if (mapgrid[width, height] < 15) Instantiate(buildings[6], position, Quaternion.identity);
            }
        }
    }
}
