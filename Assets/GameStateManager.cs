using UnityEngine;

public enum GameState
{
    Init,
    MainMenu,
    Gameplay,
    Paused,
    Options,
    GameOver

}

public class GameStateManager : MonoBehaviour
{
    // Properties to get the current and previous game states
    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }

    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        SetState(GameState.MainMenu);
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState) return;
        previousState = currentState;
        currentState = newState;

        currentActiveState = currentState.ToString();
        previousActiveState = previousState.ToString();

        OnGameStateChanged(previousState, currentState);

    }

    private void OnGameStateChanged(GameState previousState, GameState currentState)
    {
        Time.timeScale = 1f;
        switch (currentState)
        {
            case GameState.MainMenu:
                uiManager.ShowMainMenu();
                Debug.Log("GameState changed to MainMenu");
                break;

            case GameState.Gameplay:
                uiManager.ShowGameplayUI();
                Debug.Log("GameState changed to Gameplay");
                break;

            case GameState.Paused:
                uiManager.ShowPausedUI();
                Time.timeScale = 0f;
                Debug.Log("GameState changed to Paused");
                break;

            case GameState.Options:
                uiManager.ShowOptionsUI();
                Time.timeScale = 0f;
                Debug.Log("GameState changed to Options");

                break;

            case GameState.GameOver:
                uiManager.ShowGameOverUI();
                Time.timeScale = 0f;
                Debug.Log("GameState changed to GameOver");
                break;
        }
    }

    // Button Logic

    public void StartGame()
    {
        SetState(GameState.Gameplay);
    }
    public void GoBack()
    {
        SetState(previousState);
    }
    public void OptionsButton()
    {
        SetState(GameState.Options);
    }
    public void MenuButton()
    {
        SetState(GameState.MainMenu);
    }


    public void TogglePause()
    {
        if (currentState == GameState.Gameplay)
        {
            SetState(GameState.Paused);
        }
        else if (currentState == GameState.Paused)
        {
            SetState(GameState.Gameplay);
        }
    }

    public void ToggleGameOver()
    {
        if (currentState == GameState.Gameplay)
        {
            SetState(GameState.GameOver);
        }
    }
}
