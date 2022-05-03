using UnityEditor;
using UnityEditor.SceneManagement;

public class EditorSceneHandler
{
    private static string splashScenePath = "Assets/Scenes/Splash.unity";
    private static string mainmenuScenePath = "Assets/Scenes/MainMenu.unity";
    private static string gameplayScenePath = "Assets/Scenes/DinoScene/Dino Hunter 2.unity";

    [MenuItem("SceneHandler/Open Splash Scene _F1")]
    static void OpenSplashScene()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(splashScenePath);
        }
    }

    [MenuItem("SceneHandler/Open MainMenu Scene _F3")]
    static void OpenMainMenuScene()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(mainmenuScenePath);
        }
    }

    [MenuItem("SceneHandler/Open Gameplay Scene _F4")]
    static void OpenGameplayScene()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(gameplayScenePath);
        }
    }

    [MenuItem("SceneHandler/Play _F5")]
    static void Play()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            
        }
    }
}