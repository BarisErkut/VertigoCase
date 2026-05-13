using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DeathPopupUI : MonoBehaviour
{
    public static DeathPopupUI Instance;

    [Header("UI Elements")]
    [SerializeField] private GameObject ui_panel_death_popup_root;
    [SerializeField] private GameObject ui_image_popup_content_bg; 

    [Header("Buttons")]
    [SerializeField] private Button ui_button_give_up;
    [SerializeField] private Button ui_button_revive;
    [SerializeField] private Button ui_button_watch_ad;

    private void Awake() => Instance = this;

    private void OnValidate()
    {
        if (ui_button_give_up == null || ui_button_revive == null || ui_button_watch_ad == null)
        {
            Button[] buttons = GetComponentsInChildren<Button>(true);
            foreach (var btn in buttons)
            {
                if (btn.name.Contains("give_up")) ui_button_give_up = btn;
                else if (btn.name.Contains("revive")) ui_button_revive = btn;
                else if (btn.name.Contains("watch_ad")) ui_button_watch_ad = btn;
            }
        }
    }

    private void Start()
    {
        if (ui_button_give_up != null) ui_button_give_up.onClick.AddListener(OnGiveUpClicked);
        if (ui_button_revive != null) ui_button_revive.onClick.AddListener(OnReviveClicked);
        if (ui_button_watch_ad != null) ui_button_watch_ad.onClick.AddListener(OnWatchAdClicked);
    }

    private void OnDestroy()
    {
        if (ui_button_give_up != null) ui_button_give_up.onClick.RemoveAllListeners();
        if (ui_button_revive != null) ui_button_revive.onClick.RemoveAllListeners();
        
        if (ui_image_popup_content_bg != null) ui_image_popup_content_bg.transform.DOKill();
    }

    public void ShowDeathPopup(RewardData representativeReward)
    {
        ui_panel_death_popup_root.SetActive(true);

        ui_button_give_up.interactable = true;
        ui_button_revive.interactable = true;
        ui_button_watch_ad.interactable = true;

        ui_image_popup_content_bg.transform.DOKill();
        ui_image_popup_content_bg.transform.localScale = Vector3.zero;
        ui_image_popup_content_bg.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    private void OnGiveUpClicked()
    {
        ui_image_popup_content_bg.transform.DOKill();
        ui_panel_death_popup_root.SetActive(false);

        GameLoopManager.Instance.GiveUp();
    }

    private void OnReviveClicked()
    {
        ui_image_popup_content_bg.transform.DOKill();
        ui_panel_death_popup_root.SetActive(false);

        GameLoopManager.Instance.Revive();
    }
    private void OnWatchAdClicked()
    {
        ui_button_give_up.interactable = false;
        ui_button_revive.interactable = false;
        ui_button_watch_ad.interactable = false;

        Debug.Log("📺 Reklam API'si çağrıldı... Reklam izleniyor (Simülasyon)");
        
        CompleteAdSimulation();
    }

    private void CompleteAdSimulation()
    {
        Debug.Log("📺 Reklam başarıyla izlendi! Oyuncu ödüllendirildi.");

        ui_image_popup_content_bg.transform.DOKill();
        ui_panel_death_popup_root.SetActive(false);

        GameLoopManager.Instance.Revive();
    }
}