using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PopupBase : MonoBehaviour
{
    public GameState popupState;

    private void Update()
    {
        // Back pressed
        if (GameManager.Instance.GetCurrentState() == popupState && Input.GetKeyUp(KeyCode.Escape))
        {
            OnBackButtonPressed();
        }
    }

    public virtual void OnBackButtonPressed()
    {
        SoundsManager.Instance.PlaySound(SoundClip.BUTTONCLICK);
        GameManager.Instance.BackState();
        Destroy(gameObject);
    }
}