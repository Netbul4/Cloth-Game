using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace clothgame
{
    public class DialogueManager : MonoBehaviour
{
    public GameObject TextCanvas;
    public TextMeshProUGUI nameText, dialogueText;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>(); // Set the new Queue for the dialogues.
    }

    //Start the Dialogue of the object/npc.
    public void StartDialogue(Dialogue dialogue)
    {
        TextCanvas.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);     //Display each sentence of the Queue.
        }

        DisplayNextSentence();
    }

    //This display the Next Sentence and check if the Dialogue is ended.
    public void DisplayNextSentence(){
        if(sentences.Count == 0) //Check if there no are more sentences.
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    //Finish the Dialogue.
    void EndDialogue(){
        TextCanvas.SetActive(false);
    }
}
}
