using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PopupBase : MonoBehaviour
{
    public GameState popupState;

    private bool isPopupClosed;

    protected AdCalls _adsManager;

    protected virtual void Start()
    {
        this._adsManager = AdCalls.instance;
        UpdateUI();
    }

    private void Update()
    {
        // Back pressed
        if (GameManager.Instance.GetCurrentState() == popupState && Input.GetKeyUp(KeyCode.Escape))
        {
            OnBackButtonPressed();
        }
    }

    private void OnDisable()
    {
        if(!isPopupClosed)
            MenusManager.Instance.OnPopupClosed();
    }

    public virtual void OnBackButtonPressed()
    {
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
        GameManager.Instance.BackState();
        Destroy(gameObject);
    }

    public void ClosePopup()
    {
        isPopupClosed = true;
        Destroy(gameObject);
    }

    public abstract void UpdateUI();
}