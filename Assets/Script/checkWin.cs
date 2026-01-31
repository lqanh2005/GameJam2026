using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GamePlayController.instance.isWin = true;
            GamePlayController.instance.sfxSource.PlayOneShot(GamePlayController.instance.sfxClips[0]);
            GamePlayController.instance.audioSource.Pause();
            GamePlayController.instance.winpop.SetActive(true);
        }
    }
}
