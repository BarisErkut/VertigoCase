using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image ui_image_item_icon;
    [SerializeField] private TextMeshProUGUI ui_text_item_amount_value;

    private int currentAmount = 0;

    public void Setup(Sprite icon, int initialAmount)
    {
        ui_image_item_icon.sprite = icon;
        ui_image_item_icon.preserveAspect = true;
        AddAmount(initialAmount);
    }

    public void AddAmount(int amount)
    {
        currentAmount += amount;
        ui_text_item_amount_value.text = "x" + currentAmount.ToString();
    }
}