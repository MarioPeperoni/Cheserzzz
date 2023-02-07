using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeApplier : MonoBehaviour
{
    private SpriteRenderer w_pawn, w_knight, w_bishop, w_rook, w_queen, w_king;
    private SpriteRenderer b_pawn, b_knight, b_bishop, b_rook, b_queen, b_king;
    [SerializeField] private int boardThemeSelected = 0;
    [SerializeField] private int piecesThemeSelected = 0;
    [SerializeField] private int themeSetsSelected = 0;
    [SerializeField] public BoardTheme[] boardThemes;
    [SerializeField] public PiecesTheme[] piecesThemes;
    [SerializeField] public ThemeSets[] themeSets;

    void Awake()
    {
        drawFrame(themeSetsSelected == 0 ? boardThemes[boardThemeSelected] : themeSets[themeSetsSelected].boardTheme);
        changeBGColor(themeSetsSelected == 0 ? boardThemes[boardThemeSelected] : themeSets[themeSetsSelected].boardTheme);
        changeBoardColor(themeSetsSelected == 0 ? boardThemes[boardThemeSelected] : themeSets[themeSetsSelected].boardTheme);
        changePiecesSprites(themeSetsSelected == 0 ? piecesThemes[piecesThemeSelected] : themeSets[themeSetsSelected].piecesTheme);
    }

    void drawFrame(BoardTheme boardTheme)
    {
        GameObject.Find("GameHandler").GetComponent<BoardDrawer>().drawFrame = boardTheme.drawFrame;
    }

    void changeBGColor(BoardTheme boardTheme)
    {
        GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = boardTheme.customBG;
    }
    void changeBoardColor(BoardTheme boardTheme)
    {
        GameObject.Find("GameHandler").GetComponent<BoardDrawer>().lightColor = boardTheme.lightColor;
        GameObject.Find("GameHandler").GetComponent<BoardDrawer>().darkColor = boardTheme.darkColor;
    }

    void changePiecesSprites(PiecesTheme piecesTheme)
    {
        GameObject.Find("w_pawn").GetComponent<SpriteRenderer>().sprite = piecesTheme.w_pawnSprite;
        GameObject.Find("w_knight").GetComponent<SpriteRenderer>().sprite = piecesTheme.w_knightSprite;
        GameObject.Find("w_bishop").GetComponent<SpriteRenderer>().sprite = piecesTheme.w_bishopSprite;
        GameObject.Find("w_rook").GetComponent<SpriteRenderer>().sprite = piecesTheme.w_rookSprite;
        GameObject.Find("w_queen").GetComponent<SpriteRenderer>().sprite = piecesTheme.w_queenSprite;
        GameObject.Find("w_king").GetComponent<SpriteRenderer>().sprite = piecesTheme.w_kingSprite;

        GameObject.Find("b_pawn").GetComponent<SpriteRenderer>().sprite = piecesTheme.b_pawnSprite;
        GameObject.Find("b_knight").GetComponent<SpriteRenderer>().sprite = piecesTheme.b_knightSprite;
        GameObject.Find("b_bishop").GetComponent<SpriteRenderer>().sprite = piecesTheme.b_bishopSprite;
        GameObject.Find("b_rook").GetComponent<SpriteRenderer>().sprite = piecesTheme.b_rookSprite;
        GameObject.Find("b_queen").GetComponent<SpriteRenderer>().sprite = piecesTheme.b_queenSprite;
        GameObject.Find("b_king").GetComponent<SpriteRenderer>().sprite = piecesTheme.b_kingSprite;

        resizeSprite("w_pawn");
        resizeSprite("w_knight");
        resizeSprite("w_bishop");
        resizeSprite("w_rook");
        resizeSprite("w_queen");
        resizeSprite("w_king");

        resizeSprite("b_pawn");
        resizeSprite("b_knight");
        resizeSprite("b_bishop");
        resizeSprite("b_rook");
        resizeSprite("b_queen");
        resizeSprite("b_king");
    }

    void resizeSprite(string pieceName)
    {
        SpriteRenderer spriteRenderer = GameObject.Find(pieceName).GetComponent<SpriteRenderer>();

        float width = spriteRenderer.sprite.rect.width;
        float height = spriteRenderer.sprite.rect.height;

        float scale = 166 / Mathf.Max(width, height);
        GameObject.Find(pieceName).transform.localScale = new Vector3(scale, scale, 1);
        GameObject.Find(pieceName).GetComponent<BoxCollider2D>().size = new Vector2(1 / (GameObject.Find(pieceName).transform.localScale.x / 2), 1 / (GameObject.Find(pieceName).transform.localScale.y / 2));

    }
}
