using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    ScoreKeeper scoreKeeper;

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
        scoreKeeper.ResetScore();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverDelay());
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator LoadGameOverDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");
    }

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
}
