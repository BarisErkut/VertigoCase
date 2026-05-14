using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CashOutPopupUI : MonoBehaviour
{
    public static CashOutPopupUI Instance;

    [Header("UI Elements")]
    [SerializeField] private GameObject ui_panel_cashout_popup_root;
    [SerializeField] private GameObject ui_image_popup_content_bg;
    [SerializeField] private Button ui_button_claim;

    [Header("Rewards Display")]
    [SerializeField] private Transform ui_container_cashout_items;
    
    [Header("Main Screen Button")]
    [SerializeField] private Button ui_button_main_exit;

    private void Awake() => Instance = this;

    private void Start()
    {
        if (ui_button_main_exit != null) ui_button_main_exit.onClick.AddListener(ShowCashOutPopup);
        if (ui_button_claim != null) ui_button_claim.onClick.AddListener(OnClaimClicked);
    }

    private void OnDestroy()
    {
        if (ui_button_main_exit != null) ui_button_main_exit.onClick.RemoveAllListeners();
        if (ui_button_claim != null) ui_button_claim.onClick.RemoveAllListeners();
        if (ui_image_popup_content_bg != null) ui_image_popup_content_bg.transform.DOKill();
    }

    public void ShowCashOutPopup()
    {
        ui_panel_cashout_popup_root.SetActive(true);
        
        foreach (Transform child in ui_container_cashout_items)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform item in InventoryManager.Instance.inventoryContent)
        {
            Instantiate(item.gameObject, ui_container_cashout_items);
        }

        
        ui_image_popup_content_bg.transform.DOKill();
        ui_image_popup_content_bg.transform.localScale = Vector3.zero;
        ui_image_popup_content_bg.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    private void OnClaimClicked()
    {
        ui_image_popup_content_bg.transform.DOKill();
        ui_panel_cashout_popup_root.SetActive(false);
        
        GameLoopManager.Instance.CashOut();
    }
}