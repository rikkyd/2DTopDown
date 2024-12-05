using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public InputHandler inputHandler;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    void Start()
    {
        GameManager.GetInstance().OnGameOverAction += gameOver;
    }

    void Update()
    {
        
    }

    public void startGame() {
        mainMenu.SetActive(false);
    }

    public void pauseGame() 
    {
        pauseMenu.SetActive(true);
        GameManager.GetInstance().pauseGame(); 
    }

    public void resumeGame() 
    {
        pauseMenu.SetActive(false);
        GameManager.GetInstance().resumeGame();
    }

    public void quitGame() 
    {
        Application.Quit();
    }

    public void gameOver() 
    {
        gameOverMenu.SetActive(true);
    }

    public void retry() 
    {
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(true);
        GameManager.GetInstance().retry();
    }

    private void OnEnable() 
    {
        inputHandler.OnPauseAction += pauseGame;
    }

    private void OnDisable() 
    {
        inputHandler.OnPauseAction -= pauseGame;
    }
}