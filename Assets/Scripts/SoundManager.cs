using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    private AudioSource _audioSource;
    private bool _platformerMusicIsPlaying = false;
    [SerializeField] private AudioClip[] _audioClips;
    private GameManager _gameManager;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        PlayDefaultMusic();
        TryFindGameManager();
    }

    private void Update()
    {
        if (_gameManager != null)
        {
            HandleGameManagerMusicLogic();
        }
        else
        {
            TryFindGameManager();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _platformerMusicIsPlaying = false;
        PlayDefaultMusic();
        TryFindGameManager();
    }

    private void PlayDefaultMusic()
    {
        if (_audioClips.Length > 0 && _audioSource.clip != _audioClips[0])
        {
            _audioSource.clip = _audioClips[0];
            _audioSource.Play();
        }
    }

    private void TryFindGameManager()
    {
        if (_gameManager != null) return;

        GameObject gmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (gmObject != null)
        {
            _gameManager = gmObject.GetComponent<GameManager>();
            Debug.Log("GameManager найден!");
        }
    }

    private void HandleGameManagerMusicLogic()
    {
        if (_gameManager.isPlatformer && !_platformerMusicIsPlaying)
        {
            PlayMusic(1);
            _platformerMusicIsPlaying = true;
        }
        else if (!_gameManager.isPlatformer && _platformerMusicIsPlaying)
        {
            PlayMusic(0);
            _platformerMusicIsPlaying = false;
        }
    }

    private void PlayMusic(int clipIndex)
    {
        if (clipIndex < _audioClips.Length && _audioSource.clip != _audioClips[clipIndex])
        {
            _audioSource.clip = _audioClips[clipIndex];
            _audioSource.Play();
        }
    }
}