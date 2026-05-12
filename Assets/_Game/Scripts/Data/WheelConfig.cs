using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewWheelConfig", menuName = "Wheel/Wheel Config")]
public class WheelConfig : ScriptableObject
{
    [Header("Type of wheel")]
    public Sprite wheelBaseSprite;
    public Sprite pointerSprite;

    [Header("Dynamic Reward Pool")]
    public List<RewardData> standardRewardsPool = new List<RewardData>(); 
    public RewardData bombReward;
}