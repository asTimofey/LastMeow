using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flag"))
        {
            string currentPlatformer = PlayerPrefs.HasKey("CompletedPlatformers") ?
            PlayerPrefs.GetString("CompletedPlatformers") : "";
            GetComponent<PlayerSoundManager>().PlayWinSound();
            PlayerPrefs.SetString("CompletedPlatformers", currentPlatformer + SceneManager.GetActiveScene().name + ",");
            PlayerPrefs.Save();
            StartCoroutine(ShowWinGame());
        }
    }
    IEnumerator ShowWinGame()
    {
        _winScreen.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
