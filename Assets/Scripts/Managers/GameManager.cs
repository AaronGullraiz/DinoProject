using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Stack<GameState> gameStateStack;

    public delegate void OnStateChanged(GameState state);
    public static event OnStateChanged OnStateChangedEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            gameStateStack = new Stack<GameState>();
            gameStateStack.Push(GameState.MAINMENU);
        }
    }

    public void ChangeGameState(GameState state)
    {
        OnStateChangedEvent(state);
        gameStateStack.Push(state);
    }

    public GameState GetCurrentState()
    {
        return gameStateStack.Peek();
    }

    public void BackState()
    {
        var currentState = GetCurrentState();
        if (currentState == GameState.MAINMENU)
        {
            ChangeGameState(GameState.GAMEQUIT);
        }
        else if (currentState == GameState.GAMEPLAY)
        {
            ChangeGameState(GameState.PAUSED);
        }
        else if (gameStateStack.Count > 0)
        {
            gameStateStack.Pop();
            OnStateChangedEvent(GetCurrentState());
        }
    }

    public AsyncOperation LoadScene(string sceneName)
    {
        return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
    }

    private void OnApplicationQuit()
    {
        PreferenceManager.SavePrefs();
    }
}