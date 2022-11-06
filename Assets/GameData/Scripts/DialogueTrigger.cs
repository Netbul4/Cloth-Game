using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace clothgame{
    public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    //Open the Dialogue and displays it.
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
}

