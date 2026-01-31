using System;
using UnityEngine;

public class playerState
{
    protected Animator anim;
    protected String animString;
    protected Statemachine statemachine;
    protected Player player;

    protected float xInput;
    public playerState(Animator anim, String animString, Statemachine statemachine, Player player)
    {
        this.anim=anim;
        this.animString=animString;
        this.statemachine= statemachine;
        this.player=player;
    }

    public virtual void Enter()
    {
        anim.SetBool(animString,true);
    }

    public virtual void Update()
    {
       anim.SetFloat("yVelocity",player.rb.velocity.y);
       xInput=Input.GetAxisRaw("Horizontal");
        player.setVelocity(player.Speed*xInput,player.rb.velocity.y);
    }

    public virtual void Exit()
    {
        anim.SetBool(animString,false);
    }


}