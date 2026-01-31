using UnityEngine;

public class JumbState : playerState
{
    public JumbState(Animator anim, string animString, Statemachine statemachine, Player player) : base(anim, animString, statemachine, player)
    {
    }


    public override void Enter()
    {
        base.Enter();
        player.setVelocity(player.rb.velocity.x,player.jumbSpeed);
    }

    public override void Update()
    {
        base.Update();
        
        if (player.rb.velocity.y < 0)
        {
            statemachine.changeAnim(player.airState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}