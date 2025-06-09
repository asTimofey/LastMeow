using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPlatformers : MonoBehaviour
{
    [SerializeField] private string _platformerName;
    [SerializeField] private GameObject[] _arrows;
    void Start()
    {
        if (PlayerPrefs.HasKey("CompletedPlatformers"))
        {
            string[] items = PlayerPrefs.GetString("CompletedPlatformers").Split(",");
            foreach (var itemName in items)
            {
                if (itemName == _platformerName)
                {
                    foreach(var arrow in _arrows)
                    {
                        arrow.SetActive(true);
                    }
                }
            }
        }
    }
}
