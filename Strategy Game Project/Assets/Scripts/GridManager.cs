using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile grass_tile, mountain_tile;
    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> tiles;

    void Start()
    {
        generateGrid();
    }

    void generateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width*2; x=x+2)
        {
            for (int z = 0; z <height*2; z=z+2)
            {
                var random_tile = Random.Range(0, 6) == 3 ? mountain_tile : grass_tile;
                var spawned_Tile = Instantiate(random_tile, new Vector3(x, 0, z), Quaternion.identity);
                spawned_Tile.name = $"Tile {x/2}{z/2}";

                tiles[new Vector2(x / 2, z / 2)] = spawned_Tile;
            }
        }

        cam.transform.position = new Vector3((float)width-1f, 20, (float)height-1f);
    }

    public Tile Get_Tile_At_Position(Vector2 pos)
    {
        if(tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
}
