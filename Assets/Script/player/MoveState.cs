using UnityEditor.Callbacks;
using UnityEngine;

public class MoveState : GroundState
{
    public MoveState(Animator anim, string animString, Statemachine statemachine, Player player) : base(anim, animString, statemachine, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if(xInput==0)
            statemachine.changeAnim(player.idleState);
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}