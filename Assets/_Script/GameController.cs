using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOverPanel;
    public GameObject levelComplete;
    public GameObject endText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        endText.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public IEnumerator LevelComplete()
    {

        yield return new WaitForSeconds(2f);
        endText.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        levelComplete.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
