using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    public MenusData[] menuDataList;

    public static MenusManager Instance;

    private PopupBase activePopup;

    private void OnEnable()
    {
        Instance = this;
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
            if (menu.menuState == state)
            {
                if(activePopup)
                    activePopup.ClosePopup();
                activePopup = (Instantiate(Resources.Load("Popups/" + menu.menuName)) as GameObject).GetComponent<PopupBase>();
            }
        }
    }

    public void OnPopupClosed()
    {
        activePopup = null;
    }

    public void UpdateUI()
    {
        activePopup.UpdateUI();
    }
}