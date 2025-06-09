using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChortDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typeSpeed = 0.05f;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private Button continueButton;
    private int currentLine = 0;
    private bool isTyping = false;

    void Start()
    {
        if (continueButton != null) continueButton.gameObject.SetActive(false);
        if (continueButton != null) continueButton.onClick.AddListener(EndDialogue);

        if (dialogueLines.Length > 0)
        {
            StartCoroutine(TypeDialogue(dialogueLines[currentLine]));
        }
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[currentLine];
            isTyping = false;
            CheckForLastLine();
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isTyping && currentLine < dialogueLines.Length - 1)
        {
            currentLine++;
            StartCoroutine(TypeDialogue(dialogueLines[currentLine]));
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
        if (currentLine == dialogueLines.Length - 1)
        {
            if (continueButton != null) continueButton.gameObject.SetActive(true);
        }
    }

    void EndDialogue()
    {
        if (continueButton != null) continueButton.gameObject.SetActive(false);
        dialogueText.text = "";
        gameObject.SetActive(false);
    }
}
