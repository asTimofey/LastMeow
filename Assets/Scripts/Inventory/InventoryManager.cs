using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private GameObject inventoryCanvas;

    [SerializeField] private GameObject[] inventoryItems;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void LoadInventory()
    {
        if (inventoryCanvas == null)
        {
            inventoryCanvas = GameObject.FindGameObjectWithTag("InventoryCanvas");
        }
        if (PlayerPrefs.HasKey("InventoryData"))
        {
            string[] items = PlayerPrefs.GetString("InventoryData").Split(',');
            foreach (var itemName in items)
            {
                foreach(var inventoryItem in inventoryItems)
                {
                    if (itemName == inventoryItem.name)
                    {
                        inventoryItem.SetActive(true);
                    }
                }
            }
        }
    }
    public void DeleteInventory()
    {
        if (PlayerPrefs.HasKey("InventoryData"))
        {
            string[] items = PlayerPrefs.GetString("InventoryData").Split(',');
            foreach (var itemName in items)
            {
                foreach (var inventoryItem in inventoryItems)
                {
                    if (itemName == inventoryItem.name)
                    {
                        inventoryItem.SetActive(false);
                    }
                }
            }
        }
    }

    public void ToggleInventory(bool show)
    {
        inventoryCanvas.SetActive(show);
        LoadInventory();
    }
}
