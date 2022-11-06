using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTest : MonoBehaviour
{
    [SerializeField] public Tilemap tilemap;

    // Use this for initialization
    void Start()
    {
        /* assuming 2d (ignoring z)*/
        BoundsInt _area = tilemap.cellBounds;
        TileBase[] _allTiles = tilemap.GetTilesBlock(_area); // okay, offset [0] is representing (Tile) of area.yMin,xMin
        print($"CellBounds xMin={_area.xMin},yMin={_area.yMin},(zMin={_area.zMin}),xMax={_area.xMax},yMax={_area.yMax},(zMax={_area.zMax}),width={_area.size.x},height={_area.size.y}");
        print($"CellBounds origin/center={_area.center.x},{_area.center.y},({_area.center.z})");
        print($"GetTilesBlock size={_allTiles.Length}");
        int _xDelay = Math.Abs(Convert.ToInt32(_area.center.x) - _area.xMin); // to be added to each local x position to ensure an x value between 0..area.size.x
        int _yDelay = Math.Abs(Convert.ToInt32(_area.center.x) - _area.yMin); // to be added to each local y position to ensure an y value between 0..area.size.y
        int _modulo = _area.size.x; // to be added or subtracted to the current offset position to keep the x position in the array but jump to the next or previous line of the array matrix.
        foreach (var pos in _area.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(localPlace))
            {
                int offset = (localPlace.y + _yDelay) * _modulo + localPlace.x + _xDelay;
                Tile tile = (Tile)_allTiles[offset];
                print($"x={localPlace.x}, y={localPlace.y}  ->  offset[{offset}]  ->  tile name={tile.name}");
            }
        }
    }
}
