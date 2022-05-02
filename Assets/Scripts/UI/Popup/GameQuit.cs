using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : PopupBase
{
    public void OnButtonPressed(string btn)
    {
        switch (btn)
        {
            case "Yes":
                {
                    Application.Quit();
                    break;
                }
            case "No":
                {
                    OnBackButtonPressed();
                    break;
                }
        }
    }
}