using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DialogueChoiceButton : MonoBehaviour, ISelectHandler
{
    [SerializeField] Button bottun;
    [SerializeField] TextMeshProUGUI choiceText;

    public int choiceIndex = -1;

    public void SetChoiceText(string choiceTextString)
    {
        choiceText.text = choiceTextString;
    }

    public void SetChoiceIndex(int choiceIndexNum)
    {
        choiceIndex = choiceIndexNum;
        //Debug.Log("option " + choiceIndex);
    }

    public void SelectButton()
    {
        bottun.Select();
    }

    public void OnSelect(BaseEventData eventData)
    {
        GameEventManager.instance.dialogueEvents.UpdateChoiceIndex(choiceIndex);
    }
}
