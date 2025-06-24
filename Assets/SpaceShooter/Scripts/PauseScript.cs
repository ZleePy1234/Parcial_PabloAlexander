using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private Canvas pauseMenuCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Time.timeScale = 1f;
        pauseMenuCanvas = GetComponentInChildren<Canvas>();
        pauseMenuCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                PauseMenu();
            }
            else
            {
                Time.timeScale = 1f;
                UnPause();
            }
        }
    }
    public void PauseMenu()
    {
        pauseMenuCanvas.enabled = true;
        Debug.Log("Game Paused");
    }
    public void UnPause()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
