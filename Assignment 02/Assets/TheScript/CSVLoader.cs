using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class CSVLoader : MonoBehaviour
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    public static string[,] mapData;
    public static int mapWidth, mapHeight, mapSize;
    public static Dictionary<int, string> levelName = new Dictionary<int, string>();

    static public void Start()
    {
        mapData = null;
        mapWidth = mapHeight = mapSize = 0;

        var allResource = Resources.LoadAll("Level");
        for(int a = 0; a < allResource.Length; ++a)
        {
            Object filenames = allResource[a];
            levelName.Add(a + 1, filenames.name);
        }
    }

    static public void getWorldSize(string[] width, string[] height)
    {
        string text = "";
        for (int a = 0; a < width.Length; ++a)
        {
            if (height[0][a].ToString() != "." && height[0][a].ToString() != ",")
            {
                text += height[0][a];
            }
            else
                break;
        }

        mapSize =  int.Parse(text);
        Debug.Log("worldSize: " + mapSize);
    }

    //Check whether the level exist in the foler
    static string verifyLevel(int level)
    {
        foreach(KeyValuePair<int, string> data in levelName)
        {
            if (data.Key == level)
            {
                return data.Value;
            }
        }

        return "";
    }

    //Read File
    static public void ReadFile(int level)
    {
        string verify = verifyLevel(level);

        //Level Does not exist
        if (verify == "")
            return;

        TextAsset data = Resources.Load("Level/" + verify) as TextAsset;

        if (mapData != null)
            Start();

        //Getting the number of rows(y - axis)
        var height = Regex.Split(data.text, LINE_SPLIT_RE);

        //Getting the number of column(x - axis)
        var width = Regex.Split(height[0], SPLIT_RE);

        //Setting Variables
        getWorldSize(width, height);
        mapWidth = width.Length;
        mapHeight = height.Length - 1;
        mapData = new string[mapWidth, mapHeight];

        //Show Debug information
        Debug.Log("Width: " + mapWidth + ", Height: " + mapHeight);

        for (var y = 1; y < height.Length; ++y)
        {
            var values = Regex.Split(height[y], SPLIT_RE);
            if (values.Length == 0 || values[0] == "")
                continue;

            for (var x = 0; x < width.Length && x < values.Length; ++x)
            {
                string value = values[x];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                mapData[x, y] = value;
            }
        }

        //Indicate Success
        Debug.Log("Loading Successful");
    }
}