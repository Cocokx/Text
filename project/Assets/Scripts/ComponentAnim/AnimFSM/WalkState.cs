using UnityEngine;
using System.Collections;

/// <summary>
/// Run状态
/// </summary>

public class WalkState : StateTemplate<Player>
{

    public WalkState(int id, Player p) : base(id, p)
    {
    }

    public override void OnEnter(params object[] args)
    {
        base.OnEnter(args);
        owner.animator.SetInteger("PlayerState", (int)owner.ps);
        //owner.ani.Play("Run");
    }
    public override void OnStay(params object[] args)
    {
        base.OnStay(args);
    }
    public override void OnExit(params object[] args)
    {
        base.OnExit(args);
    }
}