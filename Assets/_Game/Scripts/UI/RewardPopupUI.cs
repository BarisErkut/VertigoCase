using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class RewardPopupUI : MonoBehaviour
{
    public static RewardPopupUI Instance;

    [Header("UI Elements")]
    [SerializeField] private GameObject ui_panel_reward_popup;
    [SerializeField] private Image ui_image_vfx_shine;
    
    [SerializeField] private Image ui_image_reward_icon_value; 
    [SerializeField] private TextMeshProUGUI ui_text_reward_amount_value; 
    
    [SerializeField] private Button ui_button_collect;

    [Header("Animation Settings")]
    [SerializeField] private float shineRotateSpeed = -50f;
    private RewardData currentReward;

    private void Awake()
    {
        Instance = this;
    }


    private void OnValidate()
    {
        if (ui_button_collect == null)
        {
            ui_button_collect = GetComponentInChildren<Button>(true);
        }
    }

    private void Start()
    {
        if (ui_button_collect != null)
        {
            ui_button_collect.onClick.AddListener(OnCollectClicked);
        }
    }

    private void OnDestroy()
    {
        if (ui_button_collect != null)
        {
            ui_button_collect.onClick.RemoveAllListeners();
        }
        
        if (ui_image_vfx_shine != null)
        {
            ui_image_vfx_shine.transform.DOKill();
        }
    }

    public void ShowReward(RewardData wonReward)
    {
        ui_image_reward_icon_value.sprite = wonReward.rewardIcon;
        ui_text_reward_amount_value.text = wonReward.amountText;

        ui_panel_reward_popup.SetActive(true);

        ui_image_reward_icon_value.transform.localScale = Vector3.zero;
        ui_image_reward_icon_value.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

        ui_image_vfx_shine.transform.DORotate(new Vector3(0, 0, 360), 360f / Mathf.Abs(shineRotateSpeed), RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);

        currentReward = wonReward;
    }

    private void OnCollectClicked()
    {
        ui_image_vfx_shine.transform.DOKill();
        ui_panel_reward_popup.SetActive(false);

        InventoryManager.Instance.AddReward(currentReward);
        ZoneManager.Instance.NextZone();
    }
}