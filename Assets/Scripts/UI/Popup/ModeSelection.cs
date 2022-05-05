using UnityEngine.UI;

public class ModeSelection : PopupBase
{
    public Text coinsText, cashText;
    public void OnButtonClickEvent(string btn)
    {
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
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
                    Utilities.loadingSceneName = Utilities.FOREST_GAMEPLAY_SCENE_NAME;
                    Utilities.selectedGameplayMode = GameplayMode.FOREST;
                    GameManager.Instance.ChangeGameState(GameState.LEVELSELECTION);
                    break;
                }
            case "Mode2":
                {
                    Utilities.loadingSceneName = Utilities.SNOW_GAMEPLAY_SCENE_NAME;
                    Utilities.selectedGameplayMode = GameplayMode.SNOW;
                    GameManager.Instance.ChangeGameState(GameState.LEVELSELECTION);
                    break;
                }
            case "Mode3":
                {
                    Utilities.loadingSceneName = Utilities.DESERT_GAMEPLAY_SCENE_NAME;
                    Utilities.selectedGameplayMode = GameplayMode.DESERT;
                    GameManager.Instance.ChangeGameState(GameState.LEVELSELECTION);
                    break;
                }
        }
    }

    public override void UpdateUI()
    {
        coinsText.text = PreferenceManager.Coins.ToString();
        cashText.text = PreferenceManager.Cash.ToString();
    }
}