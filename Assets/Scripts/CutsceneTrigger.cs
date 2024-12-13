using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public Dialouge dialogue;

    private void Start()
    {
        TriggerCutscene();
    }
    public void TriggerCutscene()
    {
        FindAnyObjectByType<CutsceneManager>().StartCutscene(dialogue);
    }

}
