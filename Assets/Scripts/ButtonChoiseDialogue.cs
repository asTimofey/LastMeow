using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonChoiseDialogue : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject correctImage;
    [SerializeField] private GameObject cat;
    [SerializeField] private Sprite catSprite;
    [SerializeField] private Sprite correctAnswer;
    [SerializeField] private Sprite badAnswer;
    [SerializeField] private GameObject[] buttons;
    private bool changedSprite = false;
    private void Update()
    {
        if (changedSprite)
        {
            cat.GetComponent<Image>().sprite = catSprite;
            changedSprite = false;
            foreach (var button in buttons)
            {
                button.SetActive(true);
            }
        }
    }
    public void CheckButton(bool isTrue)
    {
        foreach (var button in buttons)
        {
            button.SetActive(false);
        }
        OnOffButtons onOff = parent.GetComponent<OnOffButtons>();
        if (isTrue)
        {
            Debug.Log("Верная кнопка");
            cat.GetComponent<Image>().sprite = correctAnswer;
            if (onOff.itemSprites != null)
            {
                onOff.itemSprites.GetComponent<Button>().enabled = false;
                onOff.DisableClicks();
            }
            EnableClicks(onOff);
            StartCoroutine(ShowImage());
        }
        else
        {
            StartCoroutine(LoseDialogue());    
        }
    }
    private void EnableClicks(OnOffButtons onOff)
    {
       
        foreach (var item in onOff.enabledClicks)
        {
            item.GetComponent<Button>().enabled = true;
            item.GetComponent<Animator>().enabled = true;
        }
    }
    IEnumerator ShowImage()
    {
        correctImage.SetActive(true);
        yield return new WaitForSeconds(4);
        correctImage.SetActive(false);
        StartCoroutine(CorrectAnswer());
    }
    IEnumerator LoseDialogue()
    {
        cat.GetComponent<Image>().sprite = badAnswer;
        yield return new WaitForSeconds(5);
        changedSprite = true;
        screen.SetActive(false);
    }
    IEnumerator CorrectAnswer()
    {
        yield return new WaitForSeconds(5);
        changedSprite = true;
        screen.SetActive(false);
    }
}
