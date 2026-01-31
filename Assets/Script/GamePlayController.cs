using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioSource audioSource;

    public int currentLevel = 1;

    public void Start()
    {
        audioSource.clip = audioClips[currentLevel - 1];
        audioSource.Play();
    }
}
