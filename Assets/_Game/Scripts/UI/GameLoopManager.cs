using UnityEngine;
using DG.Tweening;

public class GameLoopManager : MonoBehaviour
{
    public static GameLoopManager Instance;

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

    public void Revive()
    {
        WheelManager.Instance.EnableSpinButton();
        WheelManager.Instance.EnableCollectButton();
    }

    public void GiveUp()
    {
        InventoryManager.Instance.ClearInventory();
        ZoneManager.Instance.currentZone = 1;
        ZoneManager.Instance.UpdateZoneUI();
        WheelManager.Instance.UpdateWheelForZone(1);
        WheelManager.Instance.EnableSpinButton();
        WheelManager.Instance.DisableCollectButton();
        
    }
    public void CashOut() // works exactly as the give up button for the demo
    {

        InventoryManager.Instance.ClearInventory(); 
        ZoneManager.Instance.currentZone = 1;
        ZoneManager.Instance.UpdateZoneUI();
        WheelManager.Instance.UpdateWheelForZone(1);
        WheelManager.Instance.EnableSpinButton();
        WheelManager.Instance.DisableCollectButton();
    }
}