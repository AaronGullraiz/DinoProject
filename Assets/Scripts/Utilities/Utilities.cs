using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static float BULLET_HIT_HEALTH_DECREASE = 35;

    public static string loadingSceneName = GAMEPLAY_SCENE_NAME;

    public const string MAIN_MENU_SCENE_NAME = "MainMenu";
    public const string GAMEPLAY_SCENE_NAME = "Dino Hunter 2";

    public static GameplayMode selectedGameplayMode = GameplayMode.FOREST;
    public static int currentSelectedLevel = 1;

    public static string RateUsUrl
    {
        get
        {
#if UNITY_ANDROID
            return "";
#endif
        }
    }

    public static string MoreGameUrl
    {
        get
        {
#if UNITY_ANDROID
            return "";
#endif
        }
    }

    #region PlayerPrefs
    public const string TOUCHPAD_SENSITIVITY = "TOUCHPAD_SENSITIVITY";
    public const string GRAPHIC_SETTINGS = "GRAPHIC_SETTINGS";
    #endregion
}

[System.Serializable]
public class MenusData
{
    public GameState menuState;
    public string menuName;
}

public enum GameplayMode
{
    FOREST,SNOW,DESERT
}

public enum Tags
{
    Bullets,
    Dino,
    Player
}

public enum DinoAnimState
{
    IDLE = 0,
    WALK = 1,
    RUN = 2,
    BITE = 3,
    DEATH = 4,
}

public enum GameState
{
    MAINMENU,
    SETTINGS,
    LEVELSELECTION,
    GAMEPLAY,
    LEVEL_COMPLETE,
    LEVEL_FAIL,
    GAMEQUIT,
    PAUSED,
    IAPSTORE,
    INVENTORY,
    LOADING,
    PROFILE,
    MODESELECTION,
}