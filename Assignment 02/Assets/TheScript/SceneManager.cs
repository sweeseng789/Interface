using UnityEngine;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[2];
    public Player player;
    public GameObject background;
    List<GameObject> worldObj = new List<GameObject>();

    public static int enemyCount = 0;
    int initenemyCount = 0;
    // Use this for initialization
    void Start()
    {
        CSVLoader.Start();
        CSVLoader.ReadFile(1);

        float mapSize = CSVLoader.mapSize;

        for (int y = 1; y < CSVLoader.mapHeight; ++y)
        {
            for (int x = 0; x < CSVLoader.mapWidth; ++x)
            {
                GameObject test = Instantiate(background) as GameObject;
                test.transform.position = new Vector3(x * mapSize, y * mapSize, background.transform.position.z);
            }
        }


        for (int y = 1; y < CSVLoader.mapHeight; ++y)
        {
            for(int x = 0; x < CSVLoader.mapWidth; ++x)
            {
                string csvData = CSVLoader.mapData[x, y];

                if(csvData != "." && csvData != ",")
                {
                    Vector3 newPos = new Vector3();

                    if (csvData == "P")
                    {
                        newPos.x = x * mapSize;
                        newPos.y = y * mapSize;

                        player.transform.position = newPos;
                    }
                    else if (csvData == "T")
                    {
                        GameObject newtree = Instantiate(prefabs[0]) as GameObject;

                        newPos.x = x * CSVLoader.mapSize;
                        newPos.y = y * CSVLoader.mapSize;
                        newPos.z = 120;

                        newtree.transform.position = newPos;
                        newtree.transform.localScale = new Vector3(mapSize * 2.5f, mapSize * 2.5f, mapSize);
                        worldObj.Add(newtree);
                    }
                    else if (csvData == "E")
                    {
                        GameObject newEnemy = Instantiate(prefabs[1]) as GameObject;

                        newPos.x = x * CSVLoader.mapSize;
                        newPos.y = y * CSVLoader.mapSize;
                        newPos.z = 120;

                        newEnemy.transform.position = newPos;
                        worldObj.Add(newEnemy);
                        enemyCount++;
                        initenemyCount = enemyCount;
                        PlayerPrefs.SetInt("EnemyCount", enemyCount);
                    }
                }
            }
        }
    }

    void Update()
    {
        if(enemyCount < 0)
        {
            Application.LoadLevel("Score Scene");
            PlayerPrefs.SetString("Win", "true");
            PlayerPrefs.SetInt("EnemyKilled", initenemyCount);
        }
        else if(player.healthText.text == "0%")
        {
            Application.LoadLevel("Score Scene");
            PlayerPrefs.SetString("Win", "false");
            PlayerPrefs.SetInt("EnemyKilled", initenemyCount - enemyCount);
        }
    }
}
