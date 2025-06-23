using UnityEngine;

public class Game_UI : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements;

    public void SwitchUI(GameObject uiToEnable)
    {
        foreach (GameObject ui in uiElements)
        {
            ui.SetActive(false);
        }

        uiToEnable.SetActive(true);
    }

    public void PauseGame() => GameManager.instance.PauseGame();

    public void StartGame(GameObject inGameUI) => GameManager.instance.StartGame(inGameUI);
    public void GoToMainMenu(GameObject mainMenu) => GameManager.instance.ResetGame(mainMenu);
}
