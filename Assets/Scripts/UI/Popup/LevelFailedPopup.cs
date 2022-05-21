using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailedPopup : PopupBase
{
    [SerializeField]
    private Text coinsText, cashText, rewardText, totalText;

    protected override void Start()
    {
        base.Start();
        this._adsManager.Admob_Unity();
        rewardText.text = "50";
        totalText.text = "50";
    }

    public void OnButtonClickEvent(string btn)
    {
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
        switch (btn)
        {
            case "Home":
                {
                    OnHomeButtonPressed();
                    break;
                }

            case "Restart":
                {
                    OnRestartButtonPressed();
                    break;
                }
            case "Energy":
                {
                    break;
                }
            case "IAPStore":
                {
                    break;
                }
            case "Inventory":
                {
                    break;
                }
            case "Profile":
                {
                    break;
                }
        }
    }

    private void OnHomeButtonPressed()
    {
        Utilities.loadingSceneName = Utilities.MAIN_MENU_SCENE_NAME;
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

    private void OnRestartButtonPressed()
    {
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

    public override void OnBackButtonPressed()
    {
        OnRestartButtonPressed();
    }

    public override void UpdateUI()
    {
        coinsText.text = PreferenceManager.Coins.ToString();
        cashText.text = PreferenceManager.Cash.ToString();
    }
}