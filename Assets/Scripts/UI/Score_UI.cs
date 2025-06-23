using TMPro;
using UnityEngine;

public class Score_UI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = GameManager.instance.GetScore().ToString();
    }
}
