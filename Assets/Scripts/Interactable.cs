using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] DialogueTrigger interactablesTrigger;
    [SerializeField] MovementControl player;

    private void OnTriggerStay2D()
    {
        if (player.interacting)
        {
            interactablesTrigger.TriggerDialogue();
        }
    }
}
