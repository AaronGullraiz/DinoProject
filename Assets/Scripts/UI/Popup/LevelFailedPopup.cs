using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailedPopup : PopupBase
{
    public void OnButtonClickEvent(string btn)
    {
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
}