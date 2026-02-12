using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject GameplayUI;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject OptionsUI;
    [SerializeField] private GameObject GameOverUI;

    public void ShowMainMenu()
    {
        HideAllUI();

        mainMenuUI.SetActive(true);
    }

    public void ShowGameplayUI()
    {
        HideAllUI();

        GameplayUI.SetActive(true);
    }

    public void ShowPausedUI()
    {
        OptionsUI.SetActive(false);
        PauseUI.SetActive(true);
    }

    public void ShowOptionsUI()
    {
        PauseUI.SetActive(false);
        OptionsUI.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        GameOverUI.SetActive(true);
    }

    public void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        GameplayUI.SetActive(false);
        PauseUI.SetActive(false);
        OptionsUI.SetActive(false);
        GameOverUI.SetActive(false);
    }
}
