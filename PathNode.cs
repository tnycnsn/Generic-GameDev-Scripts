using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode {
    
    private GridSystem<PathNode> grid;
    public int x;
    //private int x;
    public int y;
    //private int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode prevNode;

    public PathNode(GridSystem<PathNode> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }


    public void CalculateFCost(){
        fCost = gCost + hCost;
    }


    //Not sure
    public override string ToString(){
        return x + "," + y;
    }
}
