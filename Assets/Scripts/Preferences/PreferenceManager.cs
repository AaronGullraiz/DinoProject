using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PreferenceManager
{
    #region Save

    public static void SavePrefs()
    {
        PlayerPrefs.Save();
    }

    #endregion

    public static float touchpadSensitivity
    {
        get
        {
            return PlayerPrefs.GetFloat("TOUCHPAD_SENSITIVITY", 0.5f);
        }
        set
        {
            PlayerPrefs.SetFloat("TOUCHPAD_SENSITIVITY", value);
        }
    }

    public static int GraphicSettings
    {
        get
        {
            return PlayerPrefs.GetInt("GRAPHIC_SETTINGS", 2);
        }
        set
        {
            PlayerPrefs.SetInt("GRAPHIC_SETTINGS", value);
        }
    }

    public static int UnlockedLevels
    {
        get
        {
            return PlayerPrefs.GetInt("Levels", 1);
        }
        set
        {
            PlayerPrefs.SetInt("Levels", value);
        }
    }

    public static bool isSoundOn
    {
        get
        {
            return PlayerPrefs.GetInt("SOUND", 1) == 1;
        }
        set
        {
            PlayerPrefs.SetInt("SOUND", value?1:0);
        }
    }

    public static bool isMusicOn
    {
        get
        {
            return PlayerPrefs.GetInt("MUSIC", 1) == 1;
        }
        set
        {
            PlayerPrefs.SetInt("MUSIC", value ? 1 : 0);
        }
    }
}