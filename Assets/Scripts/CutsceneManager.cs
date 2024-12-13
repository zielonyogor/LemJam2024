using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue sentences;
    private Queue names;

    void Awake()
    {
        sentences = new Queue();
        names = new Queue();

    }
    public void StartCutscene(Dialouge dialouge)
    {


        sentences.Clear();
        foreach (string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        names.Clear();
        foreach (string name in dialouge.names)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();


    }
    public void SkipAll()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();

            return;
        }
        string sentence = (string)sentences.Dequeue();
        dialogueText.text = sentence;

        string name = (string)names.Dequeue();
        nameText.text = name;

    }


    void EndDialogue()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
