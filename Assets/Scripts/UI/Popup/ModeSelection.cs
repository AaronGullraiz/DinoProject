using UnityEngine;

public class ModeSelection : PopupBase
{
    public void OnButtonClickEvent(string btn)
    {
        switch (btn)
        {
            case "Energy":
                {
                    GameManager.Instance.ChangeGameState(GameState.IAPSTORE);
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
            case "Profile":
                {
                    GameManager.Instance.ChangeGameState(GameState.PROFILE);
                    break;
                }
            case "Mode1":
                {
                    Utilities.selectedGameplayMode = GameplayMode.FOREST;
                    GameManager.Instance.ChangeGameState(GameState.LEVELSELECTION);
                    break;
                }
            case "Mode2":
                {
                    Utilities.selectedGameplayMode = GameplayMode.SNOW;
                    GameManager.Instance.ChangeGameState(GameState.LEVELSELECTION);
                    break;
                }
            case "Mode3":
                {
                    Utilities.selectedGameplayMode = GameplayMode.DESERT;
                    GameManager.Instance.ChangeGameState(GameState.LEVELSELECTION);
                    break;
                }
        }
    }
}