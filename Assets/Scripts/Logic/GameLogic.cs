using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public OnePiece[,] boardVar;
    public PiecesColor currentPlayerColor;
    void Start()
    {
        boardVar = new OnePiece[8, 8];  //Board with data for all pieces currently in game
        for (int i = 0; i < 8; i++) //Setup variable
        {
            for (int j = 0; j < 8; j++)
            {
                boardVar[i, j] = new OnePiece();
            }
        }
        currentPlayerColor = PiecesColor.white; //Start with player white
        InitiateNewBoard();
    }
    public class OnePiece
    {
        public PiecesTypes pieceType = PiecesTypes.empty;
        public PiecesColor pieceColor = PiecesColor.empty;
        public GameObject pieceGameObject = null;
    }

    public enum PiecesTypes
    {
        pawn,
        knight,
        bishop,
        rook,
        queen,
        king,
        empty
    }

    public enum PiecesColor
    {
        white,
        black,
        empty
    }

    public void InstantiatePiece(string pieceName, float x, float y)
    {
        GameObject piece = Instantiate(GameObject.Find(pieceName), new Vector2(x, y), Quaternion.identity); //Instantiate piece with variables specified
        PieceController pieceController = piece.GetComponent<PieceController>();    //Get piece controller

        //Set coordinates inside the pieceController function
        pieceController.xCoor = x;
        pieceController.yCoor = y;
        pieceController.xIndex = translateFromXY(x);
        pieceController.yIndex = translateFromXY(y);

        //Fix the offset
        x = translateFromXY(x);
        y = translateFromXY(y);

        switch (pieceName.Split("_")[0]) //Splits string to get color and piece name - color switch
        {
            case "w":
                {
                    boardVar[(int)x, (int)y].pieceColor = PiecesColor.white; //Set variables in board variable
                    pieceController.thisColor = PiecesColor.white;  //Set variable inside piece
                    break;
                }
            case "b":
                {
                    boardVar[(int)x, (int)y].pieceColor = PiecesColor.black;
                    pieceController.thisColor = PiecesColor.black;
                    break;
                }
        }
        switch (pieceName.Split("_")[1]) //Splits string to get color and piece name - piece type switch
        {
            case "pawn":
                {
                    boardVar[(int)x, (int)y].pieceType = PiecesTypes.pawn;
                    pieceController.thisType = PiecesTypes.pawn;
                    break;
                }
            case "knight":
                {
                    boardVar[(int)x, (int)y].pieceType = PiecesTypes.knight;
                    pieceController.thisType = PiecesTypes.knight;
                    break;
                }
            case "bishop":
                {
                    boardVar[(int)x, (int)y].pieceType = PiecesTypes.bishop;
                    pieceController.thisType = PiecesTypes.bishop;
                    break;
                }
            case "rook":
                {
                    boardVar[(int)x, (int)y].pieceType = PiecesTypes.rook;
                    pieceController.thisType = PiecesTypes.rook;
                    break;
                }
            case "queen":
                {
                    boardVar[(int)x, (int)y].pieceType = PiecesTypes.queen;
                    pieceController.thisType = PiecesTypes.queen;
                    break;
                }
            case "king":
                {
                    boardVar[(int)x, (int)y].pieceType = PiecesTypes.king;
                    pieceController.thisType = PiecesTypes.king;
                    break;
                }
        }

        boardVar[(int)x, (int)y].pieceGameObject = piece;   //Add reference to gameobject in boardVarArray
    }

    //Calls new game
    public void InitiateNewBoard()
    {
        //Set pawn positon
        for (int x = -7; x <= 7; x += 2)
        {
            InstantiatePiece("w_pawn", x, BoardConstsXY.TWO);
            InstantiatePiece("b_pawn", x, BoardConstsXY.SEVEN);
        }

        //Set white knights
        InstantiatePiece("w_knight", BoardConstsXY.B, BoardConstsXY.ONE);
        InstantiatePiece("w_knight", BoardConstsXY.G, BoardConstsXY.ONE);

        //Set black knights
        InstantiatePiece("b_knight", BoardConstsXY.B, BoardConstsXY.EIGHT);
        InstantiatePiece("b_knight", BoardConstsXY.G, BoardConstsXY.EIGHT);

        //Set white bishop
        InstantiatePiece("w_bishop", BoardConstsXY.C, BoardConstsXY.ONE);
        InstantiatePiece("w_bishop", BoardConstsXY.F, BoardConstsXY.ONE);

        //Set black bishop
        InstantiatePiece("b_bishop", BoardConstsXY.C, BoardConstsXY.EIGHT);
        InstantiatePiece("b_bishop", BoardConstsXY.F, BoardConstsXY.EIGHT);

        //Set white rook
        InstantiatePiece("w_rook", BoardConstsXY.A, BoardConstsXY.ONE);
        InstantiatePiece("w_rook", BoardConstsXY.H, BoardConstsXY.ONE);

        //Set black rook
        InstantiatePiece("b_rook", BoardConstsXY.A, BoardConstsXY.EIGHT);
        InstantiatePiece("b_rook", BoardConstsXY.H, BoardConstsXY.EIGHT);

        //Set white queen
        InstantiatePiece("w_queen", BoardConstsXY.D, BoardConstsXY.ONE);

        //Set black queen
        InstantiatePiece("b_queen", BoardConstsXY.D, BoardConstsXY.EIGHT);

        //Set white king
        InstantiatePiece("w_king", BoardConstsXY.E, BoardConstsXY.ONE);

        //Set black king
        InstantiatePiece("b_king", BoardConstsXY.E, BoardConstsXY.EIGHT);
    }

    //Translates from coordinates in board to indexes used in variables
    public int translateFromXY(float coordinate) => (((int)coordinate + 7) / 2);

    public float translateToXY(int index) => (((float)index - 7) * 2);

    //Change player
    public void changePlayer()
    {
        currentPlayerColor = (currentPlayerColor == GameLogic.PiecesColor.white) ? GameLogic.PiecesColor.black : GameLogic.PiecesColor.white;   //Toggle player
    }
}
