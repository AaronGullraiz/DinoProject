using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : PopupBase
{
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
            case "UnlockAllLevels":
                {
                    break;
                }
            default:
                break;
        }
    }

    public void OnLevelButtonClicked(int levelNo)
    {
        Utilities.currentSelectedLevel = levelNo;
        Utilities.loadingSceneName = Utilities.GAMEPLAY_SCENE_NAME;
        GameManager.Instance.ChangeGameState(GameState.LOADING);
    }

}