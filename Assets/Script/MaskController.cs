using System;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    BoxCollider2D cd;
    public int id;
    public bool thuHepCollider=false; 
    public bool moRongCollider=false;   
    [SerializeField] float speed=5f;
    [SerializeField] float scaleDefault;
    
    
    [SerializeField] bool check1=false;
    [SerializeField] bool check2=false;

    float scaleX;
    
    
    [SerializeField] GameController gameController;

   

    void Start()
    {
        cd = GetComponent<BoxCollider2D>();
        scaleX=transform.localScale.x;
        scaleDefault=transform.localScale.x;
        
    }

    void Update()
    {
        if (thuHepCollider)
        {
            ThuHepCollider();
        }
        if (moRongCollider)
        {
            MoRongCollider();
        }
    }

    private void MoRongCollider()
    {
        if (scaleX > scaleDefault)
        {
            
            
            check2=false;
            
            moRongCollider=false;
            scaleX=scaleDefault;
            transform.Rotate(0,180,0);
            transform.localPosition= new Vector2(-1*transform.localPosition.x,transform.localPosition.y);
        }

        scaleX+=speed*Time.deltaTime;
        transform.localScale= new Vector2(scaleX,transform.localScale.y);
        

    }

    

    private void ThuHepCollider()
    {
        if (scaleX <= 0)
        {
            transform.localPosition= new Vector2(-1*transform.localPosition.x,transform.localPosition.y);
            thuHepCollider=false;
            scaleX=0;
            transform.Rotate(0,180,0);
            check1=false;
            // return;
            

        }
        scaleX-=speed*Time.deltaTime;
        transform.localScale= new Vector2(scaleX,transform.localScale.y);
    }

    public void setupMaskControllerThuHep()
    {
      
        if(!check1) 
        {
            Debug.Log("thu hep");
            check1=true;
            thuHepCollider=true;
        }
        
    }
    public void setupMaskControllerMoRong()
    {
        
        
        if(!check2) 
        {
            Debug.Log("morong");
            check2=true;
            moRongCollider=true;
        }

    }
}