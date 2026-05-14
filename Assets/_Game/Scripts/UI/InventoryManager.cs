using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DG.Tweening;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("Inventory Settings")]
    [SerializeField] public Transform inventoryContent; 
    [SerializeField] private GameObject inventorySlotPrefab;

    [Header("Animation Settings")]
    [SerializeField] private GameObject flyingItemPrefab;
    [SerializeField] private Transform wheelCenter;      
    [SerializeField] private Transform canvasTransform;  

    private Dictionary<int, InventorySlotUI> collectedItems = new Dictionary<int, InventorySlotUI>();

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
        }
    }

    public void AddReward(RewardData reward)
    {
        int amountToAdd = ExtractNumber(reward.amountText);
        int itemID = reward.rewardIcon.GetInstanceID();

        InventorySlotUI targetSlot;
        int currentAmount = 0;

        if (collectedItems.ContainsKey(itemID))
        {
            targetSlot = collectedItems[itemID];
            currentAmount = targetSlot.GetCurrentAmount();
        }
        else
        {
            GameObject newSlot = Instantiate(inventorySlotPrefab, inventoryContent);
            targetSlot = newSlot.GetComponent<InventorySlotUI>();
            targetSlot.Setup(reward.rewardIcon, 0); 
            collectedItems.Add(itemID, targetSlot);

            Canvas.ForceUpdateCanvases();
        }

        int targetAmount = currentAmount + amountToAdd;

        AnimateFlyingItem(reward.rewardIcon, targetSlot, currentAmount, targetAmount);
    }

    private void AnimateFlyingItem(Sprite icon, InventorySlotUI targetSlot, int startAmount, int endAmount)
    {
        GameObject flyingObj = Instantiate(flyingItemPrefab, wheelCenter.position, Quaternion.identity, canvasTransform);
        flyingObj.GetComponent<Image>().sprite = icon;

        flyingObj.transform.DOMove(targetSlot.transform.position, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            Destroy(flyingObj);
            targetSlot.CountUpTo(startAmount, endAmount);
        });
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