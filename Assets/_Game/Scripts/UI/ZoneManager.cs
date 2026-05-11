using UnityEngine;
using System.Collections.Generic;

public class ZoneManager : MonoBehaviour
{
    public static ZoneManager Instance;
    [Header("Settings")]
    public int currentZone = 1;
    
    [Header("References")]
    public List<ZoneNodeUI> zoneNodes; 

    private void Awake() => Instance = this;

    private void Start() => UpdateZoneUI();

    private void Update()
    {
        // test 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextZone();
        }
    }
    public void NextZone()
    {
        currentZone++;
        UpdateZoneUI();
    }

    public void UpdateZoneUI()
    {

        for (int i = 0; i < zoneNodes.Count; i++)
        {
            int offset = i - 4; // Ortayı baz al
            int nodeValue = currentZone + offset;

            zoneNodes[i].SetupNode(nodeValue, currentZone);
            WheelManager.Instance.UpdateWheelForZone(currentZone);
        }
    }
}