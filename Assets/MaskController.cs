using System;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    BoxCollider2D cd;
    public int id;
    public bool thuHepCollider; 
    public bool moRongCollider;
    [SerializeField] float speed=5f;
    [SerializeField] float scaleDefault;
    
    
    [SerializeField] bool check1=false;
    [SerializeField] bool check2=true;
    [SerializeField] bool khoaMoRong=false;
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
        if (scaleX >= scaleDefault)
        {
            
            check1=false;
            check2=true;
            
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
            check1=true;
            check2=false;
            

        }
        scaleX-=speed*Time.deltaTime;
        transform.localScale= new Vector2(scaleX,transform.localScale.y);
    }

    public void setupMaskControllerThuHep()
    {
        if(!check1&&check2) // check 1=false; check2=true;
        {
            Debug.Log("thu hep");
            check1=true;
            thuHepCollider=true;
        }
        
    }
    public void setupMaskControllerMoRong()
    {
        
        if(!check2&&check1) // check 2=false; check1=true;
        {
            Debug.Log("morong");
            check2=true;
            moRongCollider=true;
        }
        
    }
}