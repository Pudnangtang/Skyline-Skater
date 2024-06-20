using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CutsceneDialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public AudioSource dialogueAudioSource;
    public AudioClip dialogueClip;
    public float pitch = 1f;
    public float frequency = 1f;
    public string[] dialogueLines;
    public float textSpeed = 0.05f;

    private int currentLineIndex = 0;

    void Start()
    {
        dialogueAudioSource.pitch = pitch;
        dialogueAudioSource.clip = dialogueClip;
    }

    public void StartDialogue()
    {
        StartCoroutine(DisplayDialogue());
    }

    IEnumerator DisplayDialogue()
    {
        foreach (string line in dialogueLines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(frequency);
        }

        LoadNextScene();
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            dialogueAudioSource.Play();
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void LoadNextScene()
    {
        // Load the next scene here
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
}
