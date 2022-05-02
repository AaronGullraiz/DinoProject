using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPopup : PopupBase
{
    public void ButtonClickEvent(string buttonName)
    {
        switch (buttonName)
        {
            case "PlayBtn":
                {
                    GameManager.Instance.ChangeGameState(GameState.MODESELECTION);
                    break;
                }
            case "Settings":
                {
                    GameManager.Instance.ChangeGameState(GameState.SETTINGS);
                    break;
                }
            case "MoreGames":
                {
                    Application.OpenURL(Utilities.MoreGameUrl);
                    break;
                }
            case "RateUs":
                {
                    // RateUs url
                    Application.OpenURL(Utilities.RateUsUrl);
                    break;
                }
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
        GameManager.Instance.ChangeGameState(GameState.GAMEQUIT);
    }
}