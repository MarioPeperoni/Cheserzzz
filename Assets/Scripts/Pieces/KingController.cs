using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : TemplatePieceClass
{
    public bool castlingAlowed = true;
    public override void createPath()
    {
        #region basicMoves
        if (pieceController.currentlySelected) return;  //Return if piece is already selected
        pieceController.sendPathRequest(-1, -1);
        pieceController.sendPathRequest(-1, 0);
        pieceController.sendPathRequest(-1, 1);
        pieceController.sendPathRequest(0, 1);
        pieceController.sendPathRequest(0, -1);
        pieceController.sendPathRequest(1, 1);
        pieceController.sendPathRequest(1, 0);
        pieceController.sendPathRequest(1, -1);
        #endregion

        #region castling
        if (castlingAlowed)
        {
            if (gameLogic.boardVar[0, pieceController.yIndex].pieceGameObject.GetComponent<PieceController>().thisType == GameLogic.PiecesTypes.rook)
            {
                if (gameLogic.boardVar[0, pieceController.yIndex].pieceGameObject.GetComponent<RookController>().castlingAlowed)
                {
                    if (gameLogic.boardVar[1, pieceController.yIndex].pieceGameObject == null && gameLogic.boardVar[2, pieceController.yIndex].pieceGameObject == null && gameLogic.boardVar[3, pieceController.yIndex].pieceGameObject == null)
                    {
                        pieceController.sendPathRequest(-2, 0, false, true);
                    }
                }
            }
            if (gameLogic.boardVar[7, pieceController.yIndex].pieceGameObject.GetComponent<PieceController>().thisType == GameLogic.PiecesTypes.rook)
            {
                if (gameLogic.boardVar[7, pieceController.yIndex].pieceGameObject.GetComponent<RookController>().castlingAlowed)
                {
                    if (gameLogic.boardVar[5, pieceController.yIndex].pieceGameObject == null && gameLogic.boardVar[6, pieceController.yIndex].pieceGameObject == null)
                    {
                        pieceController.sendPathRequest(2, 0, false, true);
                    }
                }
            }
        }
        #endregion
    }
}