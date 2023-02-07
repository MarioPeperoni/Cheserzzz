using UnityEngine;
[CreateAssetMenu(menuName = "Theme/Board")]
public class BoardTheme : ScriptableObject
{
    public Color lightColor = Color.white;
    public Color darkColor = Color.black;
    public Color customBG = new Color32(35, 35, 35, 255);
    public bool drawFrame = false;
}
