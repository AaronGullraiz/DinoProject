using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    #region Attributes
    [SerializeField]
    private ETCJoystick joystick;
    [SerializeField]
    private ETCTouchPad touchpad;

    // Dino health bar
    public GameObject dinoHealthBar;
    public Image dinoHealthbarFiller;

    // Dino target count
    public Text dinoTargetCountTxt;

    public GameObject playerDeadOvelay;

    public Image aimButton;
    public Image flashButton;

    // Croutch
    [Header("---------- Crouch Button ----------")]
    public Image crouchButton;
    public Sprite crouchSprite, standSprite;

    #endregion

    private bool isCrouch = false;
    private bool isAiming = false;
    private bool isFlashing = false;

    private NeoFPS.InputFirearm gun;

    void Awake()
    {
        Instance = this;
    }

    #region Utilities

    public void UpdateDinoTargetCount(int count)
    {
        dinoTargetCountTxt.text = count.ToString();
    }

    public void UpdateDinoFillerValue(float val)
    {
        if (!dinoHealthBar.activeInHierarchy)
        {
            dinoHealthBar.SetActive(true);
        }
        dinoHealthbarFiller.fillAmount = val / 100;
    }

    public void OnPlayerDead()
    {
        playerDeadOvelay.SetActive(true);
    }

    public void SetUIOnLevelEnd()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
    }

    public Vector2 GetJoystickValues()
    {
        return new Vector2(
            joystick.axisX.axisValue,
            joystick.axisY.axisValue
        );
    }

    public Vector2 GetTouchpadValues()
    {
        return (new Vector2(
            touchpad.axisX.axisValue,
            touchpad.axisY.axisValue
        )*PreferenceManager.touchpadSensitivity);
    }

    #endregion

    #region Click Events

    public void OnPausePressed()
    {
        GameManager.Instance.ChangeGameState(GameState.PAUSED);
    }

    public void OnCrouchPressed()
    {
        isCrouch = !isCrouch;
        crouchButton.sprite = isCrouch? standSprite:crouchSprite;
        MobileInputs.Instance.OnCrouch(isCrouch);
    }

    public void OnFireBtnPressed()
    {
        if(gun == null)
        {
            gun = FindObjectOfType<NeoFPS.InputFirearm>();
        }
        gun.Fire();
    }

    public void OnAimBtnPressed()
    {
        if (gun == null)
        {
            gun = FindObjectOfType<NeoFPS.InputFirearm>();
        }
        isAiming = !isAiming;
        aimButton.color = isAiming ? Color.white : Color.yellow;
        gun.Aim(true);
    }

    public void OnReloadBtnClicked()
    {
        if (gun == null)
        {
            gun = FindObjectOfType<NeoFPS.InputFirearm>();
        }
        gun.Reload();
    }

    public void OnToggleFlash()
    {
        isFlashing = !isFlashing;
        flashButton.color = isFlashing ? Color.red : Color.white;
        if (gun == null)
        {
            gun = FindObjectOfType<NeoFPS.InputFirearm>();
        }
        gun.Flash();
    }

    #endregion
}