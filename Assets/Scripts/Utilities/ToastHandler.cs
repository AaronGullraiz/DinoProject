using UnityEngine;
using UnityEngine.UI;

public class ToastHandler : MonoBehaviour
{
    public GameObject toastObject;
    public Text toastText;

    public static ToastHandler Instance;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ShowToast(string text, float stayTime=2)
    {
        toastText.text = text;
        toastObject.SetActive(true);
        Invoke("HideToast", stayTime);
    }

    private void HideToast()
    {
        toastObject.SetActive(false);
    }
}