using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject ExitConfirmPanel;
    public void UIEvent_ExitRequest()
    {
        ExitConfirmPanel.SetActive(true);
    }

    public void UIEvent_OnExitConfirmed()
    {
        Application.Quit();
    }

    public void UIEvent_CancelExit()
    {
        ExitConfirmPanel.SetActive(false);
    }
}