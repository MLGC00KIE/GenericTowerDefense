using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    private TileTypes TileType;
    private int xLoc;
    private int yLoc;

    public Tile(int x, int y,  TileTypes tileType)
    {
        TileType = tileType;
        xLoc = x;
        yLoc = y;
    }

    public TileTypes GetTileType()
    {
        return TileType;
    }

    //public int[] GetLocation()
    //{

    //}

    public void DebugDraw()
    {
        // draw tile for debugging stuffs
    }
	
}
