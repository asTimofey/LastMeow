using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageController : PlayerInfo
{
    [SerializeField] private GameObject[] _hearts;
    [SerializeField] private Sprite _grayHeartSprite;
    [SerializeField] private GameObject _gameOverScreen;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        Health = 3;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void TakeDamage()
    {
        Health -= 1;
        StartCoroutine(CdAtfterDamage());
        if (Health >= 0)
        {
            _hearts[Health].GetComponent<Image>().sprite = _grayHeartSprite;
            if (Health <= 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        GetComponent<PlayerSoundManager>().PlayOverSound();
        GetComponent<PlayerController>().PlayDeathAnimation();
        StartCoroutine(CdBeforeRestart());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KillBox"))
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!GetComponent<PlayerController>().IsAttacking)
            {
                TakeDamage();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
    IEnumerator CdBeforeRestart()
    {
        _gameOverScreen.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    IEnumerator CdAtfterDamage()
    {
        Color defaultColor = _spriteRenderer.color;
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1);
        _spriteRenderer.color = defaultColor;
    }
}
