using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputExam : MonoBehaviour
{
    public TMP_InputField[] inputFields;

    void Start()
    {
        for (int i = 0; i < inputFields.Length; i++)
        {
            int index = i;
            inputFields[i].onValueChanged.AddListener(delegate { OnInputFieldChanged(index); });
            inputFields[i].onValidateInput += delegate (string text, int charIndex, char addedChar)
            {
                if (IsRussianLetter(addedChar))
                    return addedChar;
                return '\0';
            };
        }
        inputFields[0].Select();
    }
    private bool IsRussianLetter(char c)
    {
        return (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё';
    }

    void OnInputFieldChanged(int currentIndex)
    {
        inputFields[currentIndex].text = inputFields[currentIndex].text.ToUpper();
        if (inputFields[currentIndex].text.Length == 1 && currentIndex < inputFields.Length - 1)
        {
            inputFields[currentIndex + 1].Select();
        }
    }

    public void CheckWord()
    {
        string correctWord = "МУРЛЫКАНЬЕ";
        string enteredWord = "";

        foreach (var field in inputFields)
        {
            enteredWord += field.text;
        }
        bool collectedItems = CheckItems();
        if (enteredWord == correctWord && collectedItems)
        {
            SceneManager.LoadScene("GoodEnding");
            Debug.Log("Слово введено правильно: " + enteredWord);
        }
        else
        {
            SceneManager.LoadScene("BadEnding");
            Debug.Log("Слово введено неверно. Ожидалось: " + correctWord + ", введено: " + enteredWord);
        }
    }
    private bool CheckItems()
    {
        if (PlayerPrefs.HasKey("InventoryData"))
        {
            string[] items = PlayerPrefs.GetString("InventoryData").Split(',');
            if (items.Length == 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
