using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameObject exitPopup;

    public void ExitGame()
    {
        exitPopup.SetActive(true);
    }

    public void YesClicked()
    {
        Application.Quit();
        Debug.Log("Exiting app");
    }

    public void NoClicked()
    {
        exitPopup.SetActive(false);
    }
}
