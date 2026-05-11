using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewWheelConfig", menuName = "Wheel/Wheel Config")]
public class WheelConfig : ScriptableObject
{
    [Header("Type of wheel")]
    public Sprite wheelBaseSprite;
    public Sprite pointerSprite;

    [Header("Rewards (set to 8)")]
    public List<RewardData> rewards = new List<RewardData>();
}