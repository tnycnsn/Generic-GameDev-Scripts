using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pathfinding {

    private const int STR_COST = 10;
    private const int DIAG_COST = 14;

    private GridSystem<PathNode> grid;
    private List<PathNode> openList;    //queue for the search
    private List<PathNode> closedList;  //already searched nodes

    public  Pathfinding(int width, int height){
        // this.transform.position
        grid = new GridSystem<PathNode>(width, height, 1f, Vector3.zero, (GridSystem<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }

    //A* algorithm
    private List<PathNode> FindPath(int startX, int startY, int endX, int endY){

        PathNode startNode = grid.GetGridObject(startX, startY);
        PathNode endNode = grid.GetGridObject(endX, endY);

        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode> {};

        for (int x = 0; x < grid.GetWidth(); x++) {
            for (int y = 0; y < grid.GetHeight(); y++) {
                PathNode pathNode = grid.GetGridObject(x, y);
                pathNode.gCost = int.MaxValue; // initialize it with INFINITE
                pathNode.CalculateFCost();
                pathNode.prevNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateHCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0){
            PathNode currentNode = GetMinFCostNode(openList);
            if (currentNode == endNode) return CalculatePath(endNode);  //target is reached
            
            openList.Remove(currentNode);
            closedList.Add(currentNode);


        }

    }

    private int CalculateHCost(PathNode a, PathNode b){
        int xDist = Mathf.Abs(a.x - b.x);
        int yDist = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDist - yDist);

        return DIAG_COST * Mathf.Min(xDist, yDist) + STR_COST * remaining;
    }


    private PathNode GetMinFCostNode(List<PathNode> pathNodeList){
        PathNode minFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++) {
            if (pathNodeList[i].fCost < minFCostNode.fCost) minFCostNode = pathNodeList[i];
        }
        return minFCostNode;
    }

    private List<PathNode> CalculatePath(PathNode endNode){
        List<PathNode> path = new List<PathNode>();
        return null;
    }

    private List<PathNode> GetNeighbors(PathNode currentNode){
        List<PathNode> neighborList = new List<PathNode>();

        if (currentNode.x - 1 >= 0){
            neighborList.Add(GetNode(currentNode.x - 1, currentNode.y));    //Left
            if (currenNode.y - 1 >= 0){
                neighborList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));    //Left Down
                neighborList.Add(GetNode(currentNode.x, currentNode.y - 1));    //Down
            }
            if (currentNode.y + 1 <grid.GetHeight()){
                neighborList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));    //Left Up
                neighborList.Add(GetNode(currentNode.x - 1, currentNode.y));    //Up
            }
        }
        if (currentNode.x + 1 < grid.GetWidth()){
            neighborList.Add(GetNode(currentNode.x + 1, currentNode.y));    //Right
            if (currenNode.y - 1 >= 0) neighborList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));    //Right Down
            if (currenNode.y + 1 < grid.GetHeight()) neighborList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));    //Right Up
        }
    }
}
