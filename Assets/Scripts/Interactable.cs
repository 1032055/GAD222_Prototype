using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] DialogueTrigger interactablesTrigger;
    [SerializeField] MovementControl player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player.interacting)
        {
            interactablesTrigger.TriggerDialogue();
        }
    }
}
