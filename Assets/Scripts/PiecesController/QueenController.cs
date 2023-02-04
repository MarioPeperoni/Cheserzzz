using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : TemplatePieceClass
{
    public override void createPath()
    {
        if (pieceController.currentlySelected) return;  //Return if piece is already selected
        //Right-UP
        for (int y = pieceController.yIndex + 1; y < 8; y++)
        {
            if (!pieceController.sendPathRequest((y - pieceController.yIndex), (y - pieceController.yIndex))) break;
        }
        //Left DOWN
        for (int y = pieceController.yIndex - 1; y > -1; y--)
        {
            if (!pieceController.sendPathRequest((y - pieceController.yIndex), (y - pieceController.yIndex))) break;
        }
        //Left DOWN
        for (int x = pieceController.xIndex - 1; x > -1; x--)
        {
            if (!pieceController.sendPathRequest((x - pieceController.xIndex), -(x - pieceController.xIndex))) break;
        }
        //Right-UP
        for (int x = pieceController.xIndex + 1; x < 8; x++)
        {
            if (!pieceController.sendPathRequest((x - pieceController.xIndex), -(x - pieceController.xIndex))) break;
        }
        //Up
        for (int y = pieceController.yIndex + 1; y < 8; y++)
        {
            if (!pieceController.sendPathRequest(0, y - pieceController.yIndex)) break;
        }
        //Down
        for (int y = pieceController.yIndex - 1; y >= 0; y--)
        {
            if (!pieceController.sendPathRequest(0, (y - pieceController.yIndex))) break;
        }
        //Left
        for (int x = pieceController.xIndex - 1; x >= 0; x--)
        {
            if (!pieceController.sendPathRequest((x - pieceController.xIndex), 0)) break;
        }
        //Right
        for (int x = pieceController.xIndex + 1; x < 8; x++)
        {
            if (!pieceController.sendPathRequest(x - pieceController.xIndex, 0)) break;
        }

    }
}
