using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public INKDialogueEvent dialogueEvents;

    private void Awake()
    {
        dialogueEvents = new INKDialogueEvent();
    }
}
