using TMPro;
using UnityEngine;

public class GameOver_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    void OnEnable()
    {
        if (scoreText)
            scoreText.text = GameManager.instance.GetScore().ToString();

        if (bestScoreText)
            bestScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void GoToMainMenu(GameObject mainMenu)
    {
        GameManager.instance.ResetGame(mainMenu);
    }
}
