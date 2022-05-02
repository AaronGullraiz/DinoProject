using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : PopupBase
{
    public void ButtonClickEvent(string buttonName)
    {
        switch (buttonName)
        {
            case "Equip":
                {
                    break;
                }
            case "Purchase":
                {
                    break;
                }
            case "Left":
                {
                    break;
                }
            case "Right":
                {
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
}