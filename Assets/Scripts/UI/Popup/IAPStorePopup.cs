using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPStorePopup : PopupBase
{
    public void ButtonClickEvent(string buttonName)
    {
        switch (buttonName)
        {
            case "IAPStore":
                {
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
            case "UnlockAll":
                {
                    break;
                }
            case "UnlockAllLevels":
                {
                    break;
                }
            case "UnlockAllGuns":
                {
                    break;
                }
            case "RemoveAds":
                {
                    break;
                }
            default:
                break;
        }
    }
}