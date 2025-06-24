using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    private PlayerScript playerScript;
    private Canvas endGameCanvas;
    private HUDscript hudScript;
    public TextMeshProUGUI stats;
    void Awake()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        endGameCanvas = GetComponentInChildren<Canvas>();
        hudScript = GameObject.Find("ScreenSpace").GetComponent<HUDscript>();
        endGameCanvas.enabled = false;
    }

    void Update()
    {

    }
    public void DisplayEndGameStats()
    {
        stats.text = $"Asteroids Destroyed: {playerScript.asteroidsDestroyed}\n" +
                     $"Time Survived: {hudScript.timer.text}";
    }

    public void GameOver()
    {
        DisplayEndGameStats();
        endGameCanvas.enabled = true;
        hudScript.enabled = false;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
