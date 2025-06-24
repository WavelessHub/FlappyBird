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

    public void PauseGame()
    {
        MenuClickSFX();
        GameManager.instance.PauseGame();
    }

    public void StartGame(GameObject inGameUI)
    {
        MenuClickSFX();
        GameManager.instance.StartGame(inGameUI);
    }

    public void GoToMainMenu(GameObject mainMenu)
    {
        MenuClickSFX();
        GameManager.instance.ResetGame(mainMenu);
    }

    void MenuClickSFX() => AudioManager.instance.PlaySFX(3);
}
