using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOver;

    private bool hasStarted = false;

    private int score = 0;

    private Game_UI gameUI;
    private Bird bird;

    void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        gameUI = FindFirstObjectByType<Game_UI>();
        bird = FindFirstObjectByType<Bird>();
    }

    void Start()
    {
        bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }

    public int GetScore() => score;
    public void IncrementScore() => score++;

    public bool HasGameStarted() => hasStarted;

    public void StartGame(GameObject inGameUI)
    {
        hasStarted = true;
        Time.timeScale = 1;

        gameUI.SwitchUI(inGameUI);

        bird.rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void ResetGame(GameObject mainMenu)
    {
        Time.timeScale = 1;

        bird.transform.position = Vector2.zero;
        bird.rb.bodyType = RigidbodyType2D.Static;

        Pipe[] pipes = FindObjectsByType<Pipe>(FindObjectsSortMode.None);

        foreach (Pipe pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }

        score = 0;

        gameUI.SwitchUI(mainMenu);
    }

    public void PauseGame()
    {
        if (hasStarted)
        {
            hasStarted = false;
            Time.timeScale = 0;

            pauseMenu.SetActive(true);
        }
        else
        {
            hasStarted = true;
            Time.timeScale = 1;

            pauseMenu.SetActive(false);
        }
    }

    public void GameOver()
    {
        hasStarted = false;
        Time.timeScale = 0;

        SaveProgress();

        gameOver.SetActive(true);
    }

    void SaveProgress()
    {
        int previousScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > previousScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
