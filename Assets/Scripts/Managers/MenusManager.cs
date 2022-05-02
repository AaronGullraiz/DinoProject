using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    public MenusData[] menuDataList;

    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        GameManager.OnStateChangedEvent += GameManager_OnStateChangedEvent;
    }

    private void OnDisable()
    {
        GameManager.OnStateChangedEvent -= GameManager_OnStateChangedEvent;
    }

    private void GameManager_OnStateChangedEvent(GameState state)
    {
        foreach (var menu in menuDataList)
        {
            if(menu.menuState == state)
            {
                Instantiate(Resources.Load("Popups/" + menu.menuName));
            }
        }
    }
}