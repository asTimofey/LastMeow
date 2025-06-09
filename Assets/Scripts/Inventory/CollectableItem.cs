using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public bool _isFound = false;
    [SerializeField] private GameObject _dialogueObject;

    private void Start()
    {
        if (PlayerPrefs.HasKey("FoundObjects"))
        {
            string[] items = PlayerPrefs.GetString("FoundObjects").Split(',');
            foreach (var itemName in items)
            {
                if (itemName == gameObject.name)
                {
                    _dialogueObject.GetComponent<OnOffButtons>().DisableParentObject();
                    _isFound = true;
                }
            }
        }
    }

    public void ObjectFound()
    {
        if (_isFound) return;

        _isFound = true;

        string currentItems = PlayerPrefs.HasKey("FoundObjects") ?
            PlayerPrefs.GetString("FoundObjects") : "";

        PlayerPrefs.SetString("FoundObjects", currentItems + gameObject.name + ",");
        PlayerPrefs.SetString("InventoryData", currentItems + gameObject.name + ",");
        PlayerPrefs.Save();

        _dialogueObject.GetComponent<OnOffButtons>().DisableParentObject();
    }
}
