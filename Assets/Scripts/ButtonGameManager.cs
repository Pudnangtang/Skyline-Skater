using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonGameManager : MonoBehaviour
{
    public ScreenFader screenFader;
    public CutsceneDialogueManager CutscenedialogueManager;

    public void StartGame()
    {
        SceneManager.LoadScene("Cutscene1");
        // The rest of the code here won't execute because the scene is changing.
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
