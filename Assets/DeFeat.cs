using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeFeat : MonoBehaviour
{
    public bool Die=false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Die=true;
        }
    }

}
