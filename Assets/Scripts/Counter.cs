using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    private int objectCounter = 0;
    private static string _previousScene;
    private static bool _isChortWasShown = false;
    [SerializeField] private GameObject chortScreen;
    [SerializeField] private GameObject[] catScreens;
    [SerializeField] private GameObject _chortButton;

    private static Dictionary<string, int> sceneItemCount = new Dictionary<string, int>()
    {
        { "LivingRoom", 0 }, 
        { "Kitchen", 0 },
        { "Cabinet", 0 },
        { "Bedroom", 0 }
    };


    private void Awake()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (string.IsNullOrEmpty(_previousScene))
        {
            _previousScene = currentScene;
        }
        else
        {
            if (currentScene != _previousScene)
            {
                _previousScene = currentScene;
                _isChortWasShown = false;
            }
        }

        if (sceneItemCount.ContainsKey(currentScene))
        {
            objectCounter = sceneItemCount[currentScene];
        }

        if (PlayerPrefs.HasKey("IndexChort"))
        {
            string[] items = PlayerPrefs.GetString("IndexChort").Split(",");
            foreach (var itemName in items)
            {
                if (itemName == SceneManager.GetActiveScene().name)
                {
                    _chortButton.SetActive(true);
                }
                else
                {
                    _chortButton.SetActive(false);
                }
            }
        }
    }
    void Update()
    {
        if (PlayerPrefs.HasKey("IndexChort"))
        {
            string[] items = PlayerPrefs.GetString("IndexChort").Split(",");
            foreach (var itemName in items)
            {
                if (itemName == SceneManager.GetActiveScene().name)
                {
                    _chortButton.SetActive(true);
                }
            }
        }
        if (!_isChortWasShown)
        {
            if (objectCounter == 2)
            {
                SaveState();
                foreach (GameObject catScreen in catScreens)
                {
                    catScreen.SetActive(false);
                }
                chortScreen.SetActive(true);
                _isChortWasShown = true;
            }
        }
    }
    public void PlusObject()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (sceneItemCount.ContainsKey(currentScene))
        {
            objectCounter++;
            sceneItemCount[currentScene] = objectCounter;
        }
    }
    private void SaveState()
    {
        PlayerPrefs.SetString("IndexChort",SceneManager.GetActiveScene().name + ",");
        PlayerPrefs.Save();
    }
}
