using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : PopupBase
{
    [SerializeField]
    private GameObject soundOn, soundOff, musicOn, musicOff;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject[] graphicSettingsCheckMarks;

    private void Start()
    {
        slider.maxValue = 0.5f;
        slider.value = PreferenceManager.touchpadSensitivity;
        UpdateGraphicSettingsMarkers(PreferenceManager.GraphicSettings);
        UpdateSoundMusicButtonStatus();
    }

    public void OnButtonClickEvent(string btn)
    {
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
        switch(btn)
        {
            case "Sound":
                {
                    PreferenceManager.isSoundOn = !PreferenceManager.isSoundOn;
                    UpdateSoundMusicButtonStatus();
                    SoundsManager.Instance.UpdateSoundMusicStatus();
                    break;
                }
            case "Music":
                {
                    PreferenceManager.isMusicOn = !PreferenceManager.isMusicOn;
                    UpdateSoundMusicButtonStatus();
                    SoundsManager.Instance.UpdateSoundMusicStatus();
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

    private void UpdateSoundMusicButtonStatus()
    {
        soundOn.SetActive(PreferenceManager.isSoundOn);
        soundOff.SetActive(!PreferenceManager.isSoundOn);
        musicOn.SetActive(PreferenceManager.isMusicOn);
        musicOff.SetActive(!PreferenceManager.isMusicOn);
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