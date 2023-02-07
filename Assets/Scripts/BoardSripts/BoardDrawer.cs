using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDrawer : MonoBehaviour
{
    public Color lightColor;
    public Color darkColor;
    public bool drawFrame;

    void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        for (int file = 0; file < 8; file++)
        {
            for (int rank = 0; rank < 8; rank++)
            {
                bool isLightSquare = (file + rank) % 2 != 0;

                var squareColour = (isLightSquare) ? lightColor : darkColor;
                var position = new Vector2(-3.5f * 2f + (file * 2f), -3.5f * 2f + (rank * 2f));

                DrawSquare(squareColour, position, 2f); //Draw all board squares, all board squares have size of 2
            }
        }
        if (drawFrame) DrawSquare(lightColor, Vector2.zero, 16.5f);
    }
    private void DrawSquare(Color color, Vector2 position, float size)
    {
        GameObject square = GameObject.CreatePrimitive(PrimitiveType.Quad);
        square.transform.position = position;
        square.transform.parent = this.transform;
        square.transform.localScale = new Vector2(size, size);
        square.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Color");
        square.GetComponent<Renderer>().material.color = color;
    }
}
