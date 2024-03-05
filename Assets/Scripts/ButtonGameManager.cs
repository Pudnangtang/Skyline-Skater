using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class ButtonGameManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
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
