using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemplatePieceClass : MonoBehaviour
{
    public GameLogic gameLogic;
    public PieceController pieceController;
    public void Start()
    {
        gameLogic = GameObject.Find("GameHandler").GetComponent<GameLogic>();
        pieceController = gameObject.GetComponent<PieceController>();
    }
    public void OnMouseDown()
    {
        if (pieceController.thisColor == gameLogic.currentPlayerColor)
            createPath();
        pieceController.currentlySelected = true;
    }
    public abstract void createPath();
}
