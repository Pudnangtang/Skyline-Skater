using UnityEngine;

public class CutsceneInitializer : MonoBehaviour
{
    public ScreenFader screenFader;
    public CutsceneDialogueManager cutsceneDialogueManager;

    void Start()
    {
        screenFader.OnFadeComplete = cutsceneDialogueManager.StartDialogue;
    }
}
