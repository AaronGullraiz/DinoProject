using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletePopup : PopupBase
{
    public GameObject nextButton;

    private void Start()
    {
        if (Utilities.currentSelectedLevel >= Utilities.TOTAL_LEVELS)
        {
            nextButton.SetActive(false);
        }
    }

    public void OnHomeButtonPressed()
    {
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
        Utilities.loadingSceneName = Utilities.MAIN_MENU_SCENE_NAME;
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

    public void OnRestartButtonPressed()
    {
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

    public void OnNextButtonPressed()
    {
        Utilities.currentSelectedLevel++;
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

    public void ButtonClickEvent(string buttonName)
    {
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
        switch (buttonName)
        {
            case "IAPStore":
                {
                    GameManager.Instance.ChangeGameState(GameState.IAPSTORE);
                    break;
                }
            case "Inventory":
                {
                    GameManager.Instance.ChangeGameState(GameState.INVENTORY);
                    break;
                }
            case "BackBtn":
                {
                    OnBackButtonPressed();
                    break;
                }
            case "Profile":
                {
                    GameManager.Instance.ChangeGameState(GameState.PROFILE);
                    break;
                }
            case "Energy":
                {
                    GameManager.Instance.ChangeGameState(GameState.IAPSTORE);
                    break;
                }
            default:
                break;
        }
    }

    public override void OnBackButtonPressed()
    {
        OnRestartButtonPressed();
    }
}