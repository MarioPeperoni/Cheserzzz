using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIndicatorController : MonoBehaviour
{
    private bool animateIN;
    private float timer;
    private bool destroying = false;
    private Animations currentAnimation;
    public PieceController pieceController;
    public GameLogic.PathType pathType;
    private enum Animations
    {
        Hover,
        Appear,
        Leave
    }
    // Start the hover animation when the mouse enters the hitbox
    private void OnMouseEnter()
    {
        if (destroying) return; //Check if object is running destroy animation

        animateIN = true;
        currentAnimation = Animations.Hover;
        timer = 0f;
    }
    // Start the leave animation when the mouse exits the hitbox
    private void OnMouseExit()
    {
        if (destroying) return; //Check if object is running destroy animation

        animateIN = false;
        currentAnimation = Animations.Hover;
        timer = 1f;
    }
    //Send coordinates for piece to move
    private void OnMouseDown()
    {
        if (pathType == GameLogic.PathType.castle)  //If indicator is for castle action
        {
            pieceController.gameObject.GetComponent<KingController>().castlePiece(gameObject.transform.position.x, gameObject.transform.position.y);    //Castle pieces
        }
        pieceController.movePiece(gameObject.transform.position.x, gameObject.transform.position.y);    //Move piece to pos of the indicator
    }
    // Destroy object animation when destroying object
    public void DestoryObject()
    {
        destroying = true;  //Set destroying flag (stops other animations)
        timer = 0f;
        currentAnimation = Animations.Leave;
    }
    // Start the appear animation when the object is created
    public void Start()
    {
        if (pathType == GameLogic.PathType.kill) gameObject.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0f, 0f, 0.8f);   //Change path color to red if kill path
        currentAnimation = Animations.Appear;
        transform.localScale = Vector3.zero;
    }

    private void FixedUpdate()
    {
        switch (currentAnimation)
        {
            case Animations.Hover:
                //Makes indicator bigger when hovered
                transform.localScale = Vector3.one * Mathf.Lerp(0.7f, 1f, timer);
                timer += Time.deltaTime * (animateIN ? 10f : -12f);
                timer = Mathf.Clamp(timer, 0f, 1f);
                break;
            case Animations.Appear:
                timer += Time.deltaTime * 15f;
                // Pops out the indicator
                transform.localScale = Vector3.one * Mathf.Lerp(0f, 0.7f, timer);
                // Check if the animation is finished
                if (timer > 1f)
                {
                    // Start the hover animation
                    currentAnimation = Animations.Hover;
                }
                break;
            case Animations.Leave:
                timer += Time.deltaTime * 15f;
                // Hides the indicator
                transform.localScale = Vector3.one * Mathf.Lerp(0.7f, 0f, timer);
                // Check if the animation is finished
                if (timer > 1f)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}