using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : TemplatePieceClass
{
    public override void createPath()
    {
        if (pieceController.currentlySelected) return;  //Return if piece is already selected
        if (pieceController.thisColor == GameLogic.PiecesColor.white)
        {
            if (pieceController.sendPathRequest(0, 1, GameLogic.PathRequestTypes.moveOnly))
            {
                if (pieceController.moveCounter == 0)
                {
                    pieceController.sendPathRequest(0, 2, GameLogic.PathRequestTypes.moveOnly);
                }
            }
            pieceController.sendPathRequest(-1, 1, GameLogic.PathRequestTypes.killOnly);
            pieceController.sendPathRequest(1, 1, GameLogic.PathRequestTypes.killOnly);
        }
        else
        {
            if (pieceController.sendPathRequest(0, -1, GameLogic.PathRequestTypes.moveOnly))
            {
                if (pieceController.moveCounter == 0)
                {
                    pieceController.sendPathRequest(0, -2, GameLogic.PathRequestTypes.moveOnly);
                }
            }
            pieceController.sendPathRequest(-1, -1, GameLogic.PathRequestTypes.killOnly);
            pieceController.sendPathRequest(1, -1, GameLogic.PathRequestTypes.killOnly);
        }
    }
    public void checkPromo()
    {
        if (pieceController.yIndex == 0 || pieceController.yIndex == 7)
        {
            gameLogic.InstantiatePiece(pieceController.thisColor == GameLogic.PiecesColor.white ? "w_queen" : "b_queen", pieceController.xCoor, pieceController.yCoor);   //Promote to queen piece
            Destroy(gameObject);    //Destroy pawn piece
        }
    }
}
