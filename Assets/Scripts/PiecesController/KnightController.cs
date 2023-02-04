using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : TemplatePieceClass
{
    public override void createPath()
    {
        if (pieceController.currentlySelected) return;  //Return if piece is already selected
        pieceController.sendPathRequest(-1, 2);
        pieceController.sendPathRequest(-2, 1);
        pieceController.sendPathRequest(-2, -1);
        pieceController.sendPathRequest(-1, -2);
        pieceController.sendPathRequest(1, -2);
        pieceController.sendPathRequest(2, -1);
        pieceController.sendPathRequest(2, 1);
        pieceController.sendPathRequest(1, 2);
    }
}
