using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float disTance=18.9f;
    [SerializeField] Transform parent;
    [SerializeField] List<GameObject> masks;
    [SerializeField] List<int> listStt;
    void Start()
    {
        float startPosition=-2.5f;
        for(int i = 0; i < listStt.Count; i++)
        {
            GameObject tmp=Instantiate(masks[listStt[i]],new Vector3(startPosition,0,0),Quaternion.identity,parent);
            startPosition-=18.85f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
