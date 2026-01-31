using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public List<AudioClip> audioClips;
    public List<AudioClip> sfxClips;

    public AudioSource audioSource;
    public AudioSource sfxSource;

    public List<GameObject> level;

    [Header("--------------------------Btn Gameplay------------------------")]
    public Button retryBtn;
    public Button soundBtn;
    public Button musicBtn;
    public Button exitBtn;

    [Header("--------------------------Btn Winpop------------------------")]
    public GameObject winpop;
    public Button closeBtn;
    public Button nextBtn;
    public Button retryBtn1;

    [Header("--------------------------Btn Losepop------------------------")]
    public GameObject losepop;
    public Button retryBtn2;

    [Header("--------------------------Data------------------------")]
    public int currentLevel;
    public int onMusic;
    public int onSfx;
    public GameObject winPos;
    public bool isWin;
    public bool isLose;

    private void Awake()
    {
        instance = this;
        onMusic = PlayerPrefs.GetInt("OnMusic", 1);
        onSfx = PlayerPrefs.GetInt("OnSfx", 1);
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        for (int i = 0; i < level.Count; i++)
        {
            if (i == currentLevel - 1)
            {
                level[i].SetActive(true);
            }
            else
            {
                level[i].SetActive(false);
            }
        }
    }

    public void Start()
    {
        audioSource.clip = audioClips[currentLevel - 1];
        audioSource.Play();
        exitBtn.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
        });
        retryBtn.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        });
        nextBtn.onClick.AddListener(() =>
        {
            currentLevel++;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        });
        closeBtn.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
        });
        retryBtn1.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        });

        retryBtn2.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        });

        soundBtn.onClick.AddListener(() =>
        {
            onSfx = 1 - onSfx;
            sfxSource.mute = onSfx == 0;
            PlayerPrefs.SetInt("OnSfx", onSfx);
        });

        // Toggle Music
        musicBtn.onClick.AddListener(() =>
        {
            onMusic = 1 - onMusic;
            audioSource.mute = onMusic == 0;
            PlayerPrefs.SetInt("OnMusic", onMusic);
        });
    }
}
