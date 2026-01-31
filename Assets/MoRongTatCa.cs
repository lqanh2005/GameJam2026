using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoRongTatCa : MonoBehaviour
{
   [SerializeField] List<MaskController>listMaskController;
    [SerializeField] List<float> positions;
    public int idx=0;
    [SerializeField] float speed=5f;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(transform.position.x<=8.7f)
        //     return;

        if (idx<=listMaskController.Count-1&&transform.position.x >= positions[idx])
        {
            listMaskController[idx].moRongCollider=true; 
             listMaskController[idx].thuHepCollider=false; 
            if(idx<listMaskController.Count-1)
                idx++;     
        }

    }
}
