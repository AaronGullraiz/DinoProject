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
            return PlayerPrefs.GetFloat(Utilities.TOUCHPAD_SENSITIVITY, 0.5f);
        }
        set
        {
            PlayerPrefs.SetFloat(Utilities.TOUCHPAD_SENSITIVITY, value);
        }
    }

    public static int GraphicSettings
    {
        get
        {
            return PlayerPrefs.GetInt(Utilities.GRAPHIC_SETTINGS, 2);
        }
        set
        {
            PlayerPrefs.SetInt(Utilities.GRAPHIC_SETTINGS, value);
        }
    }
}