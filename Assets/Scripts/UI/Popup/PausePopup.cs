using UnityEngine;
using UnityEngine.UI;

public class PausePopup : PopupBase
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    public GameObject[] graphicSettingsCheckMarks;

    private void Start()
    {
        slider.maxValue = 0.5f;
        slider.value = PreferenceManager.touchpadSensitivity;
        UpdateGraphicSettingsMarkers(PreferenceManager.GraphicSettings);
    }

    public void OnButtonClickEvent(string btn)
    {
        switch(btn)
        {
            case "Resume":
                {
                    OnBackButtonPressed();
                    break;
                }
            case "Home":
                {
                    Utilities.loadingSceneName = Utilities.MAIN_MENU_SCENE_NAME;
                    GameManager.Instance.ChangeGameState(GameState.LOADING);
                    break;
                }
            case "Restart":
                {
                    GameManager.Instance.ChangeGameState(GameState.LOADING);
                    break;
                }
            case "Sound":
                {
                    break;
                }
            case "Music":
                {
                    break;
                }
            case "Graphic_Low":
                {
                    UpdateGraphicSettingsMarkers(0);
                    PreferenceManager.GraphicSettings = 0;
                    break;
                }
            case "Graphic_Med":
                {
                    UpdateGraphicSettingsMarkers(1);
                    PreferenceManager.GraphicSettings = 1;
                    break;
                }
            case "Graphic_High":
                {
                    UpdateGraphicSettingsMarkers(2);
                    PreferenceManager.GraphicSettings = 2;
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

    public void OnSensitivityValueChanged()
    {
        PreferenceManager.touchpadSensitivity = slider.value;
    }

    private void UpdateGraphicSettingsMarkers(int index)
    {
        for (int i = 0; i < graphicSettingsCheckMarks.Length; i++)
        {
            if (i == index)
            {
                graphicSettingsCheckMarks[i].SetActive(true);
            }
            else
            {
                graphicSettingsCheckMarks[i].SetActive(false);
            }
        }
    }
}