using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    //Coordinates on board
    public float xCoor;
    public float yCoor;

    //Indexes in board variable
    public int xIndex;
    public int yIndex;
    public GameLogic.PiecesColor thisColor; //Color of piece
    public GameLogic.PiecesTypes thisType;  //Type of piece
    public bool currentlySelected = false;
    private BoxCollider2D hitbox;
    private List<MoveIndicatorController> pathIndicators;   //List of pathIndicators shown
    public int moveCounter;
    private bool movePieceAnimation;    //Move animation
    private float animationTimer;
    private AudioSource audioSource;
    private GameLogic gameLogic;
    private void Start()
    {
        gameLogic = GameObject.Find("GameHandler").GetComponent<GameLogic>();
        audioSource = GameObject.Find("GameHandler").GetComponent<AudioSource>();
        hitbox = GetComponent<BoxCollider2D>();
        pathIndicators = new List<MoveIndicatorController>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))    //If button clicked
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get mouse position on screen

            if (!hitbox.bounds.Contains(mousePos))  // Check if mouse is not in hitbox
            {
                foreach (MoveIndicatorController indicator in pathIndicators)   // Destory every indicator in list
                {
                    indicator.DestoryObject();
                }
                currentlySelected = false;  // Unselect piece
                pathIndicators.Clear(); // Clear list
            }
        }
        // Check if piece is in right spot in code, used for checking if piece has been killed
        if (gameLogic.boardVar[xIndex, yIndex].pieceColor != thisColor)
        {
            Destroy(gameObject);
        }
    }
    //Used only for move animation
    private void FixedUpdate()
    {
        if (!movePieceAnimation) return;    //If move animation is not playing then return
        animationTimer += Time.deltaTime;
        gameObject.transform.position = Vector2.Lerp(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(xCoor, yCoor), animationTimer);
    }

    //Create path for moving piece
    public void createPatch(float xOffset, float yOffset, bool killPatch)
    {
        GameObject moveIndicator = Instantiate(GameObject.Find("MoveIndicator"), new Vector2(xCoor + xOffset, yCoor + yOffset), Quaternion.identity);   //Set indicator
        moveIndicator.GetComponent<MoveIndicatorController>().pieceController = this;
        if (killPatch) moveIndicator.GetComponent<MoveIndicatorController>().isKillIndicator = true;    //Set property if kill indicator
        pathIndicators.Add(moveIndicator.GetComponent<MoveIndicatorController>());  //Add path indicator to list for later destroying
    }
    public void movePiece(float xCoorGoTo, float yCoorGoTo, bool kill)
    {
        audioSource.Play(); //Play move sound
        movePieceAnimation = true;  //Set animation
        animationTimer = 0f;
        gameLogic.boardVar[xIndex, yIndex].pieceType = GameLogic.PiecesTypes.empty; //Clear square of piece
        gameLogic.boardVar[xIndex, yIndex].pieceColor = GameLogic.PiecesColor.empty;
        xCoor = xCoorGoTo;  //Change coordinates
        yCoor = yCoorGoTo;
        xIndex = gameLogic.translateFromXY(xCoor);
        yIndex = gameLogic.translateFromXY(yCoor);
        gameLogic.boardVar[xIndex, yIndex].pieceType = thisType;    //Set piece to new squar
        gameLogic.boardVar[xIndex, yIndex].pieceColor = thisColor;
        moveCounter++;  //Add move to move counter
        gameLogic.changePlayer();   //Change player turn
    }
    public bool sendPathRequest(int xIndexOffset, int yIndexOffset, bool killOnly = false, bool moveOnly = false)
    {
        GameLogic.PiecesColor enemyColor;   //Get color of enemy
        enemyColor = (thisColor == GameLogic.PiecesColor.white) ? GameLogic.PiecesColor.black : GameLogic.PiecesColor.white;
        if ((xIndex + xIndexOffset) > 7 || (xIndex + xIndexOffset) < 0) return false;   //Checks if x location is not out of bounds
        if ((yIndex + yIndexOffset) > 7 || (yIndex + yIndexOffset) < 0) return false;   //Checks if y location is not out of bounds
        if (gameLogic.boardVar[xIndex + xIndexOffset, yIndex + yIndexOffset].pieceColor == GameLogic.PiecesColor.empty && !killOnly)    //Create path if square is empty and path is not kill only
        {
            createPatch(xIndexOffset * 2f, yIndexOffset * 2f, false);   //Create path
            return true;
        }
        else
        {
            if (gameLogic.boardVar[xIndex + xIndexOffset, yIndex + yIndexOffset].pieceColor == enemyColor && !moveOnly) //Create kill path if enemy stands in square and path is not move only
            {
                createPatch(xIndexOffset * 2f, yIndexOffset * 2f, true);    //Create kill path
                return false;
            }
        }
        return false;
    }
}
