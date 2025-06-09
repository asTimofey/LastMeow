using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _buttonSound;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayCoinSound()
    {
        if (_coinSound != null)
        {
            _audioSource.PlayOneShot(_coinSound);
        }
    }
    public void PlayOverSound()
    {
        if (_gameOverSound != null)
        {
            _audioSource.PlayOneShot(_gameOverSound);
        }
    }
    public void PlayWinSound()
    {
        if (_winSound != null)
        {
            _audioSource.PlayOneShot(_winSound);
        }
    }
    public void PlayButtonSound()
    {
        if (_buttonSound != null)
        {
            _audioSource.PlayOneShot(_buttonSound);
        }
    }
}
