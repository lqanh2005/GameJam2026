
using System.Collections;
using UnityEditor;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    BoxCollider2D cd;
    public int id;
    public bool thuHepCollider=false; 
    public bool moRongCollider=false;   
    [SerializeField] float speed=5f;
    [SerializeField] float scaleDefault;
    
    public int facingDir=1;
    // [SerializeField] bool check1=false;
    // [SerializeField] bool check2=false;
    [SerializeField] float timeCdDisable=1f;

    float scaleX;
    
    
    [SerializeField] GameController gameController;

   

    void Start()
    {
        speed=100f;
        cd = GetComponentInChildren<BoxCollider2D>();
        scaleX=transform.localScale.x;
        scaleDefault=transform.localScale.x;
       
        
        
    }

    void Update()
    {
        if (thuHepCollider&&facingDir==1)
        {
            ThuHepCollider();
            
        }
        else if (moRongCollider&&facingDir!=1)
        {
            MoRongCollider();
        }
    }

    private void MoRongCollider()
    {
         if (cd.enabled == false)
        {
                cd.enabled=true;
        }
         thuHepCollider=false;
        if (scaleX > scaleDefault)
        {
            
            
            // check2=false;
            
            moRongCollider=false;
            scaleX=scaleDefault;
            Flip();
            transform.localPosition= new Vector2(-1*transform.localPosition.x,transform.localPosition.y);
           
        }

        scaleX+=speed*Time.deltaTime;
        transform.localScale= new Vector2(scaleX,transform.localScale.y);
        

    }

    

    private void ThuHepCollider()
    {
        moRongCollider=false;
        if (scaleX <= 0)
        {
            transform.localPosition= new Vector2(-1*transform.localPosition.x,transform.localPosition.y);
            thuHepCollider=false;
            scaleX=0;
            Flip();
            // check1=false;
            // return;
            if (cd.enabled == true)
            {
                cd.enabled=false;
            }

        }
        scaleX-=speed*Time.deltaTime;
        transform.localScale= new Vector2(scaleX,transform.localScale.y);
    }

    public void setupMaskControllerThuHep()
    {
      
        // if(!check1) 
        // {
            Debug.Log("thu hep");
            // check1=true;
            thuHepCollider=true;
        // }
        
    }
    public void setupMaskControllerMoRong()
    {
        
        
        // if(!check2) 
        // {
            Debug.Log("morong");

            moRongCollider=true;
        // }

    }


    void setActiveCD()
    {
        StartCoroutine(distableCollider(timeCdDisable));
    }

    IEnumerator distableCollider(float _time)
    {
        cd.enabled=false;
        yield return new WaitForSeconds(_time);
        cd.enabled=true;
    }

    void Flip()
    {
        transform.Rotate(0,180,0);
        facingDir*=-1;
    }
}