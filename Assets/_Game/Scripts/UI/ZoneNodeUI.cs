using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoneNodeUI : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI zoneText;
    public Image nodeBackgroundImage;

    [Header("Theme Sprites")]
    public Sprite spriteCurrent;
    public Sprite spriteCurrentWhite;
    public Sprite spriteSuper;

    public void SetupNode(int nodeValue, int currentZone)
    {
        if (nodeValue < 1)
        {
            zoneText.text = "";
            nodeBackgroundImage.enabled = false;
            return;
        }

        zoneText.text = nodeValue.ToString();

        if (nodeValue < currentZone)
        {
            nodeBackgroundImage.enabled = false;
            
            if (nodeValue % 30 == 0) zoneText.color = new Color(0.6f, 0.5f, 0f);
            else if (nodeValue % 5 == 0) zoneText.color = new Color(0f, 0.4f, 0f);
            else zoneText.color = Color.gray; 
        }
        else if (nodeValue == currentZone)
        {
            nodeBackgroundImage.enabled = true;

            if (nodeValue % 30 == 0)
            {
                nodeBackgroundImage.sprite = spriteSuper;
                zoneText.color = Color.white;
            }
            else if (nodeValue % 5 == 0)
            {
                nodeBackgroundImage.sprite = spriteCurrent;
                zoneText.color = Color.white;
            }
            else
            {
                nodeBackgroundImage.sprite = spriteCurrentWhite;
                zoneText.color = Color.black;
            }
        }
        else
        {
            nodeBackgroundImage.enabled = false;
            
            if (nodeValue % 30 == 0) zoneText.color = Color.yellow;
            else if (nodeValue % 5 == 0) zoneText.color = Color.green;
            else zoneText.color = Color.white;
        }
    }
}