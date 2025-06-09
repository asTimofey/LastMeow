using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminCommand : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.P))
        {
            NextLevelAdmin();
        }
        if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.K))
        {
            PreviousLevelAdmin();
        }
    }
    private void NextLevelAdmin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void PreviousLevelAdmin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
