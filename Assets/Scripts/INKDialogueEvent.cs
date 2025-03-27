using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INKDialogueEvent
{
    public event Action<string> onEnterDialogue;

    public void EnterDialogue(string knotName)
    {
        if(onEnterDialogue != null)
        {
            onEnterDialogue(knotName);
        }
    }
}
