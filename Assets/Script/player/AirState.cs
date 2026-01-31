using UnityEngine;

public class AirState : playerState
{
    public AirState(Animator anim, string animString, Statemachine statemachine, Player player) : base(anim, animString, statemachine, player)
    {
    }


    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();
        if(player.CheckGround())
            statemachine.changeAnim(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}