using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;

    [SerializeField] MovementControl player;

    public Animator animator;
    private GameObject charPortrait;

    public TextMeshProUGUI charName;
    public TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue words)
    {
        player.interacting = false;
        charPortrait = words.portrait;
        charPortrait.SetActive(true);
        animator.SetBool("IsOpen", true);

        Debug.Log("chat: " + words.name);
        charName.text = words.name;

        sentences.Clear();

        foreach (string sentence in words.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentSentence = sentences.Dequeue();

        //Debug.Log("bro: " + currentSentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    private void EndDialogue()
    {
        Debug.Log("chats done");
        animator.SetBool("IsOpen", false);
        charPortrait.SetActive(false);
    }
}


