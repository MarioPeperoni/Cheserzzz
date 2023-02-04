using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    private GameLogic gameLogic;
    private PieceController pieceController;
    void Start()
    {
        gameLogic = GameObject.Find("GameHandler").GetComponent<GameLogic>();
        pieceController = gameObject.GetComponent<PieceController>();
    }
    private void OnMouseDown()
    {
        if (pieceController.thisColor == gameLogic.currentPlayerColor)
            createPath();
        pieceController.currentlySelected = true;
    }

    private void createPath()
    {
        if (pieceController.currentlySelected) return;  //Return is piece is already selected
        if (pieceController.thisColor == GameLogic.PiecesColor.white)
        {
            if (gameLogic.boardVar[pieceController.xIndex, pieceController.yIndex + 1].pieceColor == GameLogic.PiecesColor.empty)
            {
                pieceController.createPatch(0f, 2f, false);

                if (gameLogic.boardVar[pieceController.xIndex, pieceController.yIndex + 2].pieceColor == GameLogic.PiecesColor.empty && pieceController.moveCounter == 0)
                {
                    pieceController.createPatch(0f, 4f, false);
                }
            }
            if (gameLogic.boardVar[pieceController.xIndex - 1, pieceController.yIndex + 1].pieceColor == GameLogic.PiecesColor.black)
            {
                pieceController.createPatch(-2f, 2f, true);
            }
            if (gameLogic.boardVar[pieceController.xIndex + 1, pieceController.yIndex + 1].pieceColor == GameLogic.PiecesColor.black)
            {
                pieceController.createPatch(2f, 2f, true);
            }
        }
        else
        {
            if (gameLogic.boardVar[pieceController.xIndex, pieceController.yIndex - 1].pieceColor == GameLogic.PiecesColor.empty)
            {
                pieceController.createPatch(0f, -2f, false);

                if (gameLogic.boardVar[pieceController.xIndex, pieceController.yIndex - 2].pieceColor == GameLogic.PiecesColor.empty && pieceController.moveCounter == 0)
                {
                    pieceController.createPatch(0f, -4f, false);
                }
            }
            if (gameLogic.boardVar[pieceController.xIndex - 1, pieceController.yIndex - 1].pieceColor == GameLogic.PiecesColor.white)
            {
                pieceController.createPatch(-2f, -2f, true);
            }
            if (gameLogic.boardVar[pieceController.xIndex + 1, pieceController.yIndex - 1].pieceColor == GameLogic.PiecesColor.white)
            {
                pieceController.createPatch(2f, -2f, true);
            }
        }
    }
}
