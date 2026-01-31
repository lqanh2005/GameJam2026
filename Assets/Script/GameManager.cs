using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button lv1Btn;
    public Button lv2Btn;
    public Button startBtn;

    public int currentLevel;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        lv1Btn.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        });
        lv2Btn.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("CurrentLevel", 2);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        });
        startBtn.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
        });
    }
}
