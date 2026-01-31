using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CircleCollider2D cd{get;private set;}
    public Rigidbody2D rb{get;private set;}
    
    public Animator anim{get;private set;}
   public Statemachine statemachine{get;private set;}
    
    public IdleState idleState{get;private set;}
    public MoveState moveState{get;private set;}
    public JumbState jumbState{get;private set;}
    public AirState airState{get;private set;}

    public float Speed=10f;
    public float jumbSpeed=10f;
    
    int facingDir=1;
    [SerializeField] Transform checkGround;
    [SerializeField] float distance=2f;
    [SerializeField] LayerMask layerMask;
    void Awake()
    {
        cd=GetComponent<CircleCollider2D>();
        rb=GetComponent<Rigidbody2D>();
        statemachine= new Statemachine();
        anim=GetComponentInChildren<Animator>();
        idleState= new IdleState(anim,"Idle",statemachine,this);
        moveState= new MoveState(anim,"Move",statemachine,this);
        jumbState= new JumbState(anim,"Jumb",statemachine,this);
        airState= new AirState(anim,"Jumb",statemachine,this);
        
    }

    void Start()
    {
        statemachine.startAnim(idleState);
    }

 
    void Update()
    {
        statemachine.currentState.Update();
    }

    public void Flip()
    {
        
        transform.Rotate(0,180,0);
        facingDir*=-1;
    }

    public void setVelocity(float x,float y)
    {
        
        rb.velocity= new Vector2(x,y);
        if (rb.velocity.x > 0&&facingDir==-1)
        {
            Flip();
        }
        else if(rb.velocity.x < 0 && facingDir == 1)
        {
            Flip();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(checkGround.position,
                        new Vector3(checkGround.position.x,checkGround.position.y-distance));
    }

    public RaycastHit2D CheckGround()=> Physics2D.Raycast(checkGround.position,Vector2.down,
                                            distance,layerMask);
}
