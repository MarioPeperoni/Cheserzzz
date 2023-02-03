using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateNewGame : MonoBehaviour
{
    void Start()
    {
        Initiate();
    }
    public void Initiate()
    {
        //Set pawn positon
        for (int x = -7; x <= 7; x+= 2)
        {
            Instantiate(GameObject.Find("w_pawn"), new Vector2(x, BoardConstsXY.TWO), Quaternion.identity);
            Instantiate(GameObject.Find("b_pawn"), new Vector2(x, BoardConstsXY.SEVEN), Quaternion.identity);
        }
        
        //Set white knights
        Instantiate(GameObject.Find("w_knight"), new Vector2(BoardConstsXY.B, BoardConstsXY.ONE), Quaternion.identity);
        Instantiate(GameObject.Find("w_knight"), new Vector2(BoardConstsXY.G, BoardConstsXY.ONE), Quaternion.identity);

        //Set black knights
        Instantiate(GameObject.Find("b_knight"), new Vector2(BoardConstsXY.B, BoardConstsXY.EIGHT), Quaternion.identity);
        Instantiate(GameObject.Find("b_knight"), new Vector2(BoardConstsXY.G, BoardConstsXY.EIGHT), Quaternion.identity);

        //Set white bishop
        Instantiate(GameObject.Find("w_bishop"), new Vector2(BoardConstsXY.C, BoardConstsXY.ONE), Quaternion.identity);
        Instantiate(GameObject.Find("w_bishop"), new Vector2(BoardConstsXY.F, BoardConstsXY.ONE), Quaternion.identity);

        //Set black bishop
        Instantiate(GameObject.Find("b_bishop"), new Vector2(BoardConstsXY.C, BoardConstsXY.EIGHT), Quaternion.identity);
        Instantiate(GameObject.Find("b_bishop"), new Vector2(BoardConstsXY.F, BoardConstsXY.EIGHT), Quaternion.identity);

        //Set white rook
        Instantiate(GameObject.Find("w_rook"), new Vector2(BoardConstsXY.A, BoardConstsXY.ONE), Quaternion.identity);
        Instantiate(GameObject.Find("w_rook"), new Vector2(BoardConstsXY.H, BoardConstsXY.ONE), Quaternion.identity);

        //Set black rook
        Instantiate(GameObject.Find("b_rook"), new Vector2(BoardConstsXY.A, BoardConstsXY.EIGHT), Quaternion.identity);
        Instantiate(GameObject.Find("b_rook"), new Vector2(BoardConstsXY.H, BoardConstsXY.EIGHT), Quaternion.identity);

        //Set white queen
        Instantiate(GameObject.Find("w_queen"), new Vector2(BoardConstsXY.D, BoardConstsXY.ONE), Quaternion.identity);

        //Set black queen
        Instantiate(GameObject.Find("b_queen"), new Vector2(BoardConstsXY.D, BoardConstsXY.EIGHT), Quaternion.identity);

        //Set white king
        Instantiate(GameObject.Find("w_king"), new Vector2(BoardConstsXY.E, BoardConstsXY.ONE), Quaternion.identity);

        //Set black king
        Instantiate(GameObject.Find("b_king"), new Vector2(BoardConstsXY.E, BoardConstsXY.EIGHT), Quaternion.identity);
    }
}
