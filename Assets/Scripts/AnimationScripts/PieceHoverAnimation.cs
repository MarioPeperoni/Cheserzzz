using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceHoverAnimation : MonoBehaviour
{
    private float timer;
    private GameLogic gameLogic;
    private PieceController pieceController;
    void Start()
    {
        gameLogic = GameObject.Find("GameHandler").GetComponent<GameLogic>();
        pieceController = gameObject.GetComponent<PieceController>();
    }
    void OnMouseEnter()
    {
        if (gameLogic.currentPlayerColor != pieceController.thisColor) return;
        //timer = 0f;
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime * 20f;
        if (timer < 2f)
        {
            transform.Rotate(Vector3.forward * timer / 2);
        }
        if (timer > 2f)
        {
            transform.Rotate(Vector3.back * timer / 2);
        }
        if (timer > 4f)
        {
            transform.localRotation = Quaternion.identity;
        }
    }
}
