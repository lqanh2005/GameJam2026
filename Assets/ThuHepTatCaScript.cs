using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThuHepTatCaScript : MonoBehaviour
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
        if(transform.position.x<=8.7f)
            return;
            
        if (transform.position.x >= positions[idx])
        {
            listMaskController[idx].thuHepCollider=true;   
            listMaskController[idx].moRongCollider=false;     
            if(idx<listMaskController.Count-1)
                idx++;     
        }
        float tmp= transform.position.x+speed*Time.deltaTime;
        transform.position= new Vector3(tmp,transform.position.y);

    }
}
