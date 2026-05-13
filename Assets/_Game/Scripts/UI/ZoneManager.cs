using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class ZoneManager : MonoBehaviour
{
    public static ZoneManager Instance;
    
    [Header("Settings")]
    public int currentZone = 1;
    
    [Header("References")]
    public List<ZoneNodeUI> zoneNodes; 
    public RectTransform nodesContainer;

    [Header("Animation Settings")]
    public float slideDuration = 0.4f;
    public float slideDistance = 100f;

    private float originalX;

    private void Awake() => Instance = this;

    private void Start() 
    {
        if (nodesContainer != null)
        {
            originalX = nodesContainer.anchoredPosition.x;
        }
        
        UpdateZoneUI();
        WheelManager.Instance.UpdateWheelForZone(currentZone); 
    }

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

        if (nodesContainer != null)
        {
            nodesContainer.DOKill();
            nodesContainer.anchoredPosition = new Vector2(originalX, nodesContainer.anchoredPosition.y);


            nodesContainer.DOAnchorPosX(originalX - slideDistance, slideDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => 
                {
                    nodesContainer.anchoredPosition = new Vector2(originalX, nodesContainer.anchoredPosition.y);
                    UpdateZoneUI();
                    
                    WheelManager.Instance.UpdateWheelForZone(currentZone);
                });
        }
        else
        {
            UpdateZoneUI();
            WheelManager.Instance.UpdateWheelForZone(currentZone);
        }
    }

    public void UpdateZoneUI()
    {
        for (int i = 0; i < zoneNodes.Count; i++)
        {
            int offset = i - 4; // Ortayı baz al
            int nodeValue = currentZone + offset;

            zoneNodes[i].SetupNode(nodeValue, currentZone);
        }
    }
}