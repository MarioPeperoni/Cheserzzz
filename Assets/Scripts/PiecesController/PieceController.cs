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
    private GameLogic gameLogic;
    private void Start()
    {
        gameLogic = GameObject.Find("GameHandler").GetComponent<GameLogic>();
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
    private void FixedUpdate()
    {
        if (!movePieceAnimation) return;
        animationTimer += Time.deltaTime;
        gameObject.transform.position = Vector2.Lerp(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(xCoor, yCoor), animationTimer);
    }
    public void createPatch(float xOffset, float yOffset, bool killPatch)
    {
        GameObject moveIndicator = Instantiate(GameObject.Find("MoveIndicator"), new Vector2(xCoor + xOffset, yCoor + yOffset), Quaternion.identity);
        moveIndicator.GetComponent<MoveIndicatorController>().pieceController = this;
        if (killPatch) moveIndicator.GetComponent<MoveIndicatorController>().isKillIndicator = true;
        pathIndicators.Add(moveIndicator.GetComponent<MoveIndicatorController>());
    }
    public void movePiece(float xCoorGoTo, float yCoorGoTo, bool kill)
    {
        movePieceAnimation = true;
        animationTimer = 0f;
        gameLogic.boardVar[xIndex, yIndex].pieceType = GameLogic.PiecesTypes.empty;
        gameLogic.boardVar[xIndex, yIndex].pieceColor = GameLogic.PiecesColor.empty;
        xCoor = xCoorGoTo;
        yCoor = yCoorGoTo;
        xIndex = gameLogic.translateFromXY(xCoor);
        yIndex = gameLogic.translateFromXY(yCoor);
        gameLogic.boardVar[xIndex, yIndex].pieceType = thisType;
        gameLogic.boardVar[xIndex, yIndex].pieceColor = thisColor;
        moveCounter++;
        gameLogic.changePlayer();
    }
}
