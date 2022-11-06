using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCode : MonoBehaviour
{
    GameObject[,] grid = new GameObject[10, 10];
    // player units
    // enemy units
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 10; ++x)
        {
            for(int y = 0; y < 10; ++y)
            {
                var newTile = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newTile.transform.position = new Vector3(x, 0, y);
                var renderer = newTile.GetComponent<Renderer>();
                renderer.material.SetColor("_Color", Color.green);

                grid[x, y] = newTile;

                // add grid script 
            }
        }
    }

    // callback for tile clicking
    void tileInteract()
    {
        // if tile has player unit
            // toggle select unit
        // if tile has enemy unit
            // if player has unit selected
                // if player unit in range
                    // attack
        // if tile has no unit
            // if player has unit selected
                // if player unit in range
                    // move
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
