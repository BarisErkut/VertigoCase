using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private Transform inventoryContent; 
    [SerializeField] private GameObject inventorySlotPrefab;

    private Dictionary<int, InventorySlotUI> collectedItems = new Dictionary<int, InventorySlotUI>();

    private void Awake() => Instance = this;

    public void AddReward(RewardData reward)
    {
        int amount = ExtractNumber(reward.amountText);
        int itemID = reward.rewardIcon.GetInstanceID();

        if (collectedItems.ContainsKey(itemID))
        {
            collectedItems[itemID].AddAmount(amount);
        }
        else
        {
            GameObject newSlot = Instantiate(inventorySlotPrefab, inventoryContent);
            InventorySlotUI slotUI = newSlot.GetComponent<InventorySlotUI>();
            slotUI.Setup(reward.rewardIcon, amount);
            collectedItems.Add(itemID, slotUI);
        }
    }

    private int ExtractNumber(string text)
    {
        string numberOnly = Regex.Replace(text, "[^0-9]", "");
        if (int.TryParse(numberOnly, out int result)) return result;
        return 1; 
    }
    public void ClearInventory()
    {
        foreach (Transform child in inventoryContent)
        {
            Destroy(child.gameObject);
        }
        collectedItems.Clear();
    }
}