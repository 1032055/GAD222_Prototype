using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue chat;

    public void TriggerDialogue()
    {
        //Debug.Log("chat triggered");
        FindObjectOfType<DialogueManager>().StartDialogue(chat);
    }
}
