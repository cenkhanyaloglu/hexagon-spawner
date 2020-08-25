using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject hexPrefab;

    // This is the number of hex tiles in the map
    [SerializeField]
    private int width = 8;
    [SerializeField]
    private int height = 9;

    //Odd numbers have an offset to create Hex grid
    float XOffset = 0.775f;
    float YOffset = 0.9f;

    Color[] colors = { Color.green, Color.red, Color.blue, Color.yellow, Color.magenta, Color.cyan };

    void Start()
    {
        CreateHexGrid();
    }

    void CreateHexGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float yPos = y * YOffset;

                //If y is on an odd number, add Y offset to create the true Hex grid
                if (x % 2 == 1)
                {
                    yPos += YOffset / 2;
                }
                //Create every Hex with its x and y index value
                GameObject hexGameObject = Instantiate(hexPrefab, new Vector2(x * XOffset, yPos), Quaternion.identity);
                hexGameObject.name = "Hex_" + x + "_" + y;
                hexGameObject.GetComponentInChildren<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                //Game Objects appear under the Map GameObject for clear Hierarchy window
                hexGameObject.transform.SetParent(this.transform);
            }
        }
    }
}
