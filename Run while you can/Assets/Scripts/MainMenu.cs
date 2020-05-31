using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TMP_Text lastScoreText;
    public TMP_Text highScoreText;

    private void OnEnable()
    {
        Time.timeScale = 0;
        lastScoreText.text = $"Last Score: {PlayerPrefs.GetInt("LastScore", 0)}";
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    
    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void PlayGame()
    {
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
