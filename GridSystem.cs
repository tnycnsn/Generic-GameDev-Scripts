﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridMatrix;

    public Grid (int width, int height, float cellSize){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridMatrix = new int[width, height];    //create the matrix

        for (int x = 0; x < gridMatrix.GetLength(0); x++){
            for (int y = 0; y < gridMatrix.GetLength(1); y++){
                CreateWorldText(gridMatrix[x, y].ToString(), Color.white, null, GetWorldPosition(x, y )+ new Vector3(cellSize, cellSize) * .5f, 6, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }


    private Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x, y) * cellSize;
    }


    public void SetValue(int x, int y, int value) {
        
        if (x >= 0 && x < width && y >= 0 && y < height){
            gridMatrix[x, y] = value;
        }
    }


    public static TextMesh CreateWorldText(string text, Color color, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 6, TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = -1){
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;

        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        if (color == null) textMesh.color = Color.white;
        else textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

}