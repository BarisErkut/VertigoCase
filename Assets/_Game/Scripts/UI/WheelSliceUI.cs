using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelSliceUI : MonoBehaviour
{
    public Image rewardIcon;
    public TextMeshProUGUI rewardAmountText;

    public void SetupSlice(RewardData data)
    {
        rewardIcon.sprite = data.rewardIcon;
        rewardAmountText.text = data.amountText;
    }
}