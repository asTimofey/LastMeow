using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typeSpeed = 0.05f;
    [SerializeField] private string[] dialogueLines; 
    private int currentLine = 0;
    private bool isTyping = false;
    private Animator animator;
    [SerializeField] private GameObject cat;
    [SerializeField] private bool isStart;

    void Start()
    {
        if (isStart)
        {
            if (!PlayerPrefs.HasKey("StartDialogue"))
            {
                PlayerPrefs.SetInt("StartDialogue", 1);
                animator = cat.GetComponent<Animator>();
                if (dialogueLines.Length > 0)
                {
                    StartCoroutine(TypeDialogue(dialogueLines[currentLine]));
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            animator = cat.GetComponent<Animator>();
            if (dialogueLines.Length > 0)
            {
                StartCoroutine(TypeDialogue(dialogueLines[currentLine]));
            }
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLine];
                isTyping = false;
            }
            else
            {
                currentLine++;
                if (currentLine < dialogueLines.Length)
                {
                    StartCoroutine(TypeDialogue(dialogueLines[currentLine]));
                }
                else
                {
                    dialogueText.text = "";
                    gameObject.SetActive(false); 
                }
            }
            if (currentLine == 2)
            {
                animator.SetBool("Bad", true);
            }
            else if (currentLine == 3)
            {
                animator.SetBool("Bad", false);
                animator.SetBool("Laugh", true);
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
    }
}
