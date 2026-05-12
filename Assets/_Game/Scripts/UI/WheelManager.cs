using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class WheelManager : MonoBehaviour
{
    public static WheelManager Instance;

    [Header("Wheel reference")]
    public Image wheelBaseImage; 
    public Image pointerImage;   

    [Header("Slices")]
    public List<WheelSliceUI> slices; 

    [Header("Wheel Configs")]
    public WheelConfig bronzeConfig;
    public WheelConfig silverConfig;
    public WheelConfig goldConfig;

    [Header("Spin Animation Settings")]
    [SerializeField] private Transform wheelSlicesContainer;
    [SerializeField] private Button spinButton;
    [SerializeField] private float spinDuration = 3f;
    [SerializeField] private int extraSpins = 5;
    [SerializeField] private Ease spinEase = Ease.OutCirc;

    private bool isSpinning = false;
    private Tween currentSpinTween;
    
    private List<RewardData> activeRewards = new List<RewardData>();

    private void Awake() => Instance = this;

    private void Start()
    {
        spinButton.onClick.AddListener(SpinWheel);
    }

    private void OnDestroy()
    {
        spinButton.onClick.RemoveAllListeners();

        if (currentSpinTween != null && currentSpinTween.IsActive())
        {
            currentSpinTween.Kill();
        }
        
        wheelBaseImage.transform.DOKill();
    }

    public void UpdateWheelForZone(int zone)
    {
        WheelConfig targetConfig;

        if (zone % 30 == 0) targetConfig = goldConfig;
        else if (zone % 5 == 0) targetConfig = silverConfig;
        else targetConfig = bronzeConfig;

        LoadWheelConfig(targetConfig, zone);
    }

    private void LoadWheelConfig(WheelConfig config, int currentZone)
    {
        if (config == null) return;

        wheelBaseImage.sprite = config.wheelBaseSprite;
        pointerImage.sprite = config.pointerSprite;

        activeRewards.Clear();

        bool isSafeZone = (currentZone % 5 == 0);
        int neededStandardRewards = isSafeZone ? 8 : 7;

        List<RewardData> tempPool = new List<RewardData>(config.standardRewardsPool);

        for (int i = 0; i < neededStandardRewards; i++)
        {
            if (tempPool.Count > 0)
            {
                int randomIndex = Random.Range(0, tempPool.Count);
                activeRewards.Add(tempPool[randomIndex]);
                tempPool.RemoveAt(randomIndex);
            }
            else if (config.standardRewardsPool.Count > 0)
            {
                tempPool = new List<RewardData>(config.standardRewardsPool);
                int randomIndex = Random.Range(0, tempPool.Count);
                activeRewards.Add(tempPool[randomIndex]);
                tempPool.RemoveAt(randomIndex);
            }
        }

        if (!isSafeZone && config.bombReward != null && config.bombReward.isBomb)
        {
            activeRewards.Add(config.bombReward);
        }

        for (int i = 0; i < activeRewards.Count; i++)
        {
            RewardData temp = activeRewards[i];
            int randomIndex = Random.Range(i, activeRewards.Count);
            activeRewards[i] = activeRewards[randomIndex];
            activeRewards[randomIndex] = temp;
        }

        for (int i = 0; i < slices.Count; i++)
        {
            if (i < activeRewards.Count)
            {
                slices[i].SetupSlice(activeRewards[i]);
            }
        }
    }

    private void SpinWheel()
    {
        if (isSpinning) return;
        
        isSpinning = true;
        spinButton.interactable = false;

        int totalSlices = slices.Count; 
        int winningIndex = Random.Range(0, totalSlices);

        float sliceAngle = 360f / totalSlices;
        float targetZRotation = -(360f * extraSpins) - (360f - (winningIndex * sliceAngle));

        wheelBaseImage.transform.DORotate(new Vector3(0, 0, targetZRotation), spinDuration, RotateMode.FastBeyond360)
            .SetEase(spinEase);

        currentSpinTween = wheelSlicesContainer.DORotate(new Vector3(0, 0, targetZRotation), spinDuration, RotateMode.FastBeyond360)
            .SetEase(spinEase)
            .OnComplete(() => OnSpinComplete(winningIndex));
    }

    private void OnSpinComplete(int winningIndex)
    {
        isSpinning = false;
        
        RewardData wonReward = activeRewards[winningIndex];

        if (wonReward.isBomb)
        {
            Debug.Log("BOMBA GELDİ!");
        }
        else
        {
            Debug.Log($"ÖDÜL KAZANILDI: {wonReward.amountText}");
            RewardPopupUI.Instance.ShowReward(wonReward);
            spinButton.interactable = true; 
        }
    }
}