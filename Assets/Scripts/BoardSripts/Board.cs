using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] public BoardTheme[] boardThemes;
    private float boardSize = 2;
    [SerializeField] private int boardThemeID;

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

                var squareColour = (isLightSquare) ? boardThemes[boardThemeID].lightColor : boardThemes[boardThemeID].darkColor;
                var position = new Vector2(-3.5f * boardSize + (file * boardSize), -3.5f * boardSize + (rank * boardSize));

                DrawSquare(squareColour, position);
            }
        }
    }
    private void DrawSquare(Color color, Vector2 position)
    {
        GameObject square = GameObject.CreatePrimitive(PrimitiveType.Quad);
        square.transform.position = position;
        square.transform.parent = this.transform;
        square.transform.localScale = new Vector2(boardSize, boardSize);
        square.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Color");
        square.GetComponent<Renderer>().material.color = color;
    }
}
