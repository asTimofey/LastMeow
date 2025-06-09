using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typeSpeed = 0.05f;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private string[] correctDialogueLines;
    [SerializeField] private string[] incorrectDialogueLines;
    [SerializeField] private Button choiceButton1;
    [SerializeField] private Button choiceButton2;
    private int currentLine = 0;
    private bool isTyping = false;
    private bool dialogueGo = true;
    private string[] currentDialogue;

    void Start()
    {
        if (choiceButton1 != null) choiceButton1.gameObject.SetActive(false);
        if (choiceButton2 != null) choiceButton2.gameObject.SetActive(false);

        if (choiceButton1 != null) choiceButton1.onClick.AddListener(() => MakeChoice(true));
        if (choiceButton2 != null) choiceButton2.onClick.AddListener(() => MakeChoice(false));

        currentDialogue = dialogueLines;
        //if (currentDialogue.Length > 0)
        //{
        //    StartCoroutine(TypeDialogue(currentDialogue[currentLine]));
        //}
    }

    void Update()
    {
        if (dialogueGo)
        {
            if (choiceButton1 != null) choiceButton1.gameObject.SetActive(false);
            if (choiceButton2 != null) choiceButton2.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentDialogue[currentLine];
                isTyping = false;
                CheckForLastLine();
            }
            else if (currentLine < currentDialogue.Length - 1)
            {
                currentLine++;
                StartCoroutine(TypeDialogue(currentDialogue[currentLine]));
            }
        }
    }

    IEnumerator TypeDialogue(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
        CheckForLastLine();
    }

    private void CheckForLastLine()
    {
        if (currentLine == currentDialogue.Length - 1 && currentDialogue == dialogueLines)
        {
            dialogueGo = false;
            if (choiceButton1 != null) choiceButton1.gameObject.SetActive(true);
            if (choiceButton2 != null) choiceButton2.gameObject.SetActive(true);
        }
    }

    private void MakeChoice(bool choice)
    {
        dialogueGo = true;
        if (choiceButton1 != null) choiceButton1.gameObject.SetActive(false);
        if (choiceButton2 != null) choiceButton2.gameObject.SetActive(false);

        currentLine = 0;
        currentDialogue = choice ? correctDialogueLines : incorrectDialogueLines;

        if (currentDialogue.Length > 0)
        {
            StartCoroutine(TypeDialogue(currentDialogue[currentLine]));
        }
        else
        {
            dialogueText.text = "";
            gameObject.SetActive(false);
        }
    }
    public void ResetDialogue()
    {
        StopAllCoroutines();
        currentLine = 0;
        currentDialogue = dialogueLines;
        isTyping = false;
        dialogueGo = true;
        dialogueText.text = "";
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        if (currentDialogue.Length > 0)
        {
            StartCoroutine(TypeDialogue(currentDialogue[currentLine]));
        }
    }
}
