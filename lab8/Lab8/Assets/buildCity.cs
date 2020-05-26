using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{

    public GameObject[] buildings;
    public GameObject CrossRoad;
    public GameObject XRoad;
    public GameObject YRoad;
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

                mapgrid[width, height] = (int)(Mathf.PerlinNoise(width / noiseDivider + seed, height / noiseDivider + seed) * 10);


            }
        }
        int x = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int height = 0; height < mapHeight; height++)
            {
                mapgrid[x, height] = -1;
            }
            x += 3;
            if (x >= mapWidth) break;
        }

        int y = 0;
        for (int n = 0; n < 10; n++)
        {
            for (int width = 0; width < mapWidth; width++)
            {
                if (mapgrid[width, y] == -1) mapgrid[width, y] = -3;
                else mapgrid[width, y] = -2;

            }
            y += Random.Range(3, 8);
            if (y >= mapHeight) break;
        }



        for (int height = 0; height < mapHeight; height++)
        {
            for (int width = 0; width < mapWidth; width++)
            {
                Vector3 position = new Vector3(width * buildingSpacing, 0, height * buildingSpacing);
                if (mapgrid[width, height] < -2) Instantiate(CrossRoad, position, CrossRoad.transform.rotation);
                else if (mapgrid[width, height] < -1) Instantiate(XRoad, position, XRoad.transform.rotation);
                else if (mapgrid[width, height] < 0) Instantiate(YRoad, position, YRoad.transform.rotation);
                else if (mapgrid[width, height] < 2) Instantiate(buildings[0], position, Quaternion.identity);
                else if (mapgrid[width, height] < 4) Instantiate(buildings[1], position, Quaternion.identity);
                else if (mapgrid[width, height] < 5) Instantiate(buildings[2], position, Quaternion.identity);
                else if (mapgrid[width, height] < 7) Instantiate(buildings[3], position, Quaternion.identity);
                else if (mapgrid[width, height] < 8) Instantiate(buildings[4], position, Quaternion.identity);
                else if (mapgrid[width, height] < 10) Instantiate(buildings[5], position, Quaternion.identity);
            }
        }
    }
}
