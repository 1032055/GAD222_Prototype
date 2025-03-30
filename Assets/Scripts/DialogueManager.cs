using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    //Queue<string> sentences;

    [SerializeField] MovementControl player;
    [SerializeField] private TextAsset inkJson;

    private Story story;
    public bool inDialogue = false;
    private int currentChoiceIndex = -1;

    public Animator animator;
    private GameObject charPortrait;

    public TextMeshProUGUI charName;
    public TextMeshProUGUI dialogueText;

    [SerializeField] private DialogueChoiceButton[] choiceButtons;

    void Start()
    {
        //sentences = new Queue<string>();
        story = new Story(inkJson.text);
        foreach (DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }
    }
    
    public void StartDialogue(Dialogue words)
    {
        if(inDialogue)
        {
            return;
        }
        inDialogue = true;

        player.interacting = false;
        charPortrait = words.portrait;
        charPortrait.SetActive(true);
        animator.SetBool("IsOpen", true);

        //Debug.Log("chat: " + words.name);
        charName.text = words.name;

        if(!words.dialogueKnotName.Equals(""))
        {
            story.ChoosePathString(words.dialogueKnotName);
        }
        else
        {
            Debug.LogWarning("Knot Name empty when entering dialogue, check knot attached?");
        }

        // For the non-ink ver
        /*sentences.Clear();

        foreach (string sentence in words.sentences)
        {
            sentences.Enqueue(sentence);
        }*/

        DisplayNextSentence();

    }

    public void SetChoiceIndex(DialogueChoiceButton leButton)
    {
        currentChoiceIndex = leButton.choiceIndex;
    }

    public void DisplayNextSentence()
    {
        foreach(DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        if(story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            currentChoiceIndex = -1;
        }

        if (story.canContinue)
        {
            string dialogueLine = story.Continue();
            //Debug.Log(dialogueLine);

            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogueLine, story.currentChoices));
        }
        else if (story.currentChoices.Count == 0)
        {
            EndDialogue();
        }

        //For Non-ink Ver
        /*if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentSentence = sentences.Dequeue();

        //Debug.Log("bro: " + currentSentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));*/
    }

    IEnumerator TypeSentence(string sentence, List<Choice> dialogueChoices)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

        if(dialogueChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("more choices than supported");
        }

        int choiceButtonIndex = dialogueChoices.Count - 1;
        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialogueChoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton choiceButton = choiceButtons[inkChoiceIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialogueChoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);

            if(inkChoiceIndex == 0)
            {
                choiceButton.SelectButton();
            }

            choiceButtonIndex++;
        }
    }


    private void EndDialogue()
    {
        //Debug.Log("chats done");
        animator.SetBool("IsOpen", false);
        charPortrait.SetActive(false);
        inDialogue = false;

        story.ResetState();

        foreach (DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }
    }
}


