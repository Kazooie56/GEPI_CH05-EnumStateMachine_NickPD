using UnityEngine;

public enum GameState
{
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

    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        SetState(GameState.MainMenu);
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState)
        {
            return;
        }

        previousState = currentState;
        currentState = newState;

        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState currentState)
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                uiManager.ShowMainMenu();
                Time.timeScale = 1f;
                Debug.Log("GameState changed to MainMenu");
                break;

            case GameState.Gameplay:
                uiManager.ShowGameplayUI();
                Time.timeScale = 1f;
                Debug.Log("GameState changed to Gameplay");
                break;

            case GameState.Paused:
                uiManager.ShowPausedUI();
                Time.timeScale = 0f;
                Debug.Log("GameState changed to Paused");
                break;

            case GameState.Options:
                uiManager.ShowOptionsUI();
                Debug.Log("GameState changed to Options");
                Time.timeScale = 0f;
                break;

            case GameState.GameOver:
                uiManager.ShowGameOverUI();
                Time.timeScale = 0f;
                Debug.Log("GameState changed to GameOver");
                break;

        }
        // internal method to handle what happens when the gamestate changes
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
        else if (currentState == GameState.GameOver)
        {
            SetState(GameState.Gameplay);
        }
    }
}
