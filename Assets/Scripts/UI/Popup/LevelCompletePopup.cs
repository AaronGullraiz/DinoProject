using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletePopup : PopupBase
{
    public void OnHomeButtonPressed()
    {
        Utilities.loadingSceneName = Utilities.MAIN_MENU_SCENE_NAME;
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

    public void OnRestartButtonPressed()
    {
        Utilities.loadingSceneName = Utilities.GAMEPLAY_SCENE_NAME;
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

    public void OnNextButtonPressed()
    {
        Utilities.loadingSceneName = Utilities.GAMEPLAY_SCENE_NAME;
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

    public void ButtonClickEvent(string buttonName)
    {
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