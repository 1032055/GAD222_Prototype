using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INKDialogueEvent
{
    public event Action<string> onEnterDialogue;
    public event Action<int> onUpdateChoiceIndex;

    public void EnterDialogue(string knotName)
    {
        if(onEnterDialogue != null)
        {
            onEnterDialogue(knotName);
        }
    }

    public void UpdateChoiceIndex(int choiceIndex)
    {
        if(onUpdateChoiceIndex != null)
        {
            onUpdateChoiceIndex(choiceIndex);
        }
    }


}
