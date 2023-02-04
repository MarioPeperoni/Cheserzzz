using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : TemplatePieceClass
{
    public override void createPath()
    {
        if (pieceController.currentlySelected) return;  //Return if piece is already selected
        pieceController.sendPathRequest(-1, -1);
        pieceController.sendPathRequest(-1, 0);
        pieceController.sendPathRequest(-1, 1);
        pieceController.sendPathRequest(0, 1);
        pieceController.sendPathRequest(0, -1);
        pieceController.sendPathRequest(1, 1);
        pieceController.sendPathRequest(1, 0);
        pieceController.sendPathRequest(1, -1);
    }
}