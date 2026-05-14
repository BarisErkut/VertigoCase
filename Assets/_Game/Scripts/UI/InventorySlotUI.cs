using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image ui_image_item_icon;
    [SerializeField] private TextMeshProUGUI ui_text_item_amount_value;

    private int currentAmount = 0;

    public void Setup(Sprite icon, int initialAmount)
    {
        ui_image_item_icon.sprite = icon;
        ui_image_item_icon.preserveAspect = true;
        currentAmount = initialAmount;
        ui_text_item_amount_value.text = "x" + currentAmount.ToString();
    }

    public int GetCurrentAmount()
    {
        return currentAmount;
    }

    public void CountUpTo(int startVal, int endVal)
    {
        currentAmount = endVal; 
        
        int tempVal = startVal; 

        DOTween.To(() => tempVal, x => {
            tempVal = x;
            ui_text_item_amount_value.text = "x" + tempVal.ToString();
        }, endVal, 0.4f).SetEase(Ease.OutCubic);

        transform.DOKill(true); 
        transform.DOPunchScale(Vector3.one * 0.15f, 0.3f, 10, 1);
    }
}