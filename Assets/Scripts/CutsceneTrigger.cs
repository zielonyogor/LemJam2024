using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
     public Dialouge dialogue;

    public void TriggerCutscene() { 
        FindAnyObjectByType<CutsceneManager>().StartCutscene(dialogue);
    }

}
