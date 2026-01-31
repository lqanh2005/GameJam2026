using UnityEngine;

public class GroundState : playerState
{
    public GroundState(Animator anim, string animString, Statemachine statemachine, Player player) : base(anim, animString, statemachine, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        if (xInput != 0)
        {
          statemachine.changeAnim(player.moveState);

        }

        if (Input.GetKeyDown(KeyCode.Space)&&player.CheckGround())
        {
            statemachine.changeAnim(player.jumbState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}