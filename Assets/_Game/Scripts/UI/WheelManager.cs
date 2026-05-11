using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WheelManager : MonoBehaviour
{
    public static WheelManager Instance;

    [Header("Wheel reference")]
    public Image wheelBaseImage; 
    public Image pointerImage;   

    [Header("Slices")]
    public List<WheelSliceUI> slices; 

    [Header("Wheel Configs")]
    public WheelConfig bronzeConfig;
    public WheelConfig silverConfig;
    public WheelConfig goldConfig;

    private void Awake() => Instance = this;

    public void UpdateWheelForZone(int zone)
    {
        WheelConfig targetConfig;

        if (zone % 30 == 0) 
        {
            targetConfig = goldConfig;
        }
        else if (zone % 5 == 0) 
        {
            targetConfig = silverConfig;
        }
        else 
        {
            targetConfig = bronzeConfig;
        }

        LoadWheelConfig(targetConfig);
    }

    private void LoadWheelConfig(WheelConfig config)
    {
        if (config == null) return;

        wheelBaseImage.sprite = config.wheelBaseSprite;
        pointerImage.sprite = config.pointerSprite;

        for (int i = 0; i < slices.Count; i++)
        {
            if (i < config.rewards.Count)
            {
                slices[i].SetupSlice(config.rewards[i]);
            }
        }
    }
}