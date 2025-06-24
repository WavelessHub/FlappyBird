using TMPro;
using UnityEngine;

public class ScoreBoard_UI : MonoBehaviour
{
    [SerializeField] private GameObject medal;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    void OnEnable()
    {
        int score = GameManager.instance.GetScore();
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (medal)
        {
            if (score >= highScore)
            {
                medal.SetActive(true);
            }
            else
            {
                medal.SetActive(false);
            }
        }

        if (scoreText)
        {
            scoreText.text = score.ToString();
        }

        if (bestScoreText)
        {
            bestScoreText.text = highScore.ToString();
        }
    }
}
