using UnityEngine;
using TMPro;

public class ZoneIndicatorUI : MonoBehaviour
{
    public static ZoneIndicatorUI Instance;

    [SerializeField] private TextMeshProUGUI ui_text_safe_zone;
    [SerializeField] private TextMeshProUGUI ui_text_super_zone;

    [SerializeField] private int safeZoneInterval = 5;
    [SerializeField] private int superZoneInterval = 30;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateIndicators(1);
    }
    public void UpdateIndicators(int currentLevel)
    {
        int nextSafeZone = (currentLevel / safeZoneInterval) * safeZoneInterval + safeZoneInterval;
        
        int nextSuperZone = (currentLevel / superZoneInterval) * superZoneInterval + superZoneInterval;

        if (nextSafeZone == nextSuperZone)
        {
            nextSafeZone += safeZoneInterval;
        }

        ui_text_safe_zone.text = "<color=#55FF55> NEXT SAFE ZONE \n " + nextSafeZone + "</color>";
        ui_text_super_zone.text = "<color=#FFAA00> NEXT SUPER ZONE \n " + nextSuperZone + "</color>";
    }
}