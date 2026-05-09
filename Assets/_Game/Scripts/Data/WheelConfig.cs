using System;
using System.Collections.Generic;
using UnityEngine;

namespace VertigoCase.Data
{
    // It is going to show the quantity and type of the reward. 
    // Boolean will help with the bomb case.
    [Serializable]
    public struct WheelSlice 
    {
        public RewardData reward;
        public int amount;
        public bool isBomb;
    }

    [CreateAssetMenu(fileName = "NewWheelConfig", menuName = "VertigoCase/Data/Wheel Config")]
    public class WheelConfig : ScriptableObject
    {
        // This will help decide what kind of a stage the player has reached at a time. Also has a slice count which we will set to 8.
        public enum WheelType { Standard, Silver, Golden }
        public WheelType wheelType;
        public List<WheelSlice> slices; 
    }
}