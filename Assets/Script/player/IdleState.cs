using UnityEngine;

public class IdleState : GroundState
{
    public IdleState(Animator anim, string animString, Statemachine statemachine, Player player) : base(anim, animString, statemachine, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

}