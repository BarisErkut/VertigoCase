using UnityEngine;

namespace VertigoCase.Data
{
    [CreateAssetMenu(fileName = "NewRewardData", menuName = "VertigoCase/Data/Reward Data")]
    public class RewardData : ScriptableObject
    {
        public string rewardName;
        public Sprite rewardIcon;
    }
}