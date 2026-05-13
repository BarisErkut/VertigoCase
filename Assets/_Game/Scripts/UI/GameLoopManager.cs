using UnityEngine;
using DG.Tweening;

public class GameLoopManager : MonoBehaviour
{
    public static GameLoopManager Instance;

    private void Awake() => Instance = this;

    public void Revive()
    {
        Debug.Log("💎 Canlanıldı! Oyun para düşüldü, aynı zone'dan devam ediliyor.");
        WheelManager.Instance.EnableSpinButton();
    }

    public void GiveUp()
    {
        Debug.Log("💥 Pes edildi! Envanter siliniyor, Zone 1'e dönülüyor.");
        InventoryManager.Instance.ClearInventory();
        ZoneManager.Instance.currentZone = 1;
        ZoneManager.Instance.UpdateZoneUI();
        WheelManager.Instance.UpdateWheelForZone(1);
        WheelManager.Instance.EnableSpinButton();
    }
}