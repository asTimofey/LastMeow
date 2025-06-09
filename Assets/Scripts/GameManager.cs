using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;
    public bool isPlatformer = true;
    public bool IsGameOver
    {
        get {  return _isGameOver; }
        set { _isGameOver = value; }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightAlt))
        {
            GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>().DeleteInventory();
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
