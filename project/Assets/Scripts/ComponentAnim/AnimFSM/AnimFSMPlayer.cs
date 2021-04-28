using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimFSMPlayer : AnimFSM
{
    
    public AnimFSMPlayer(Animation anims) : base(anims)
    {
    }

    public override void Initialize()
    {
        AnimStates = new List<AnimState>();
        AnimStates.Add(new AnimStateIdle(AnimEngine));
        AnimStates.Add(new AnimStateWalk(AnimEngine));
        DefaultAnimState = AnimStates[(int)E_PlayerState.E_Idle];
        base.Initialize();
    }
    public override void DoAction(E_PlayerState state)
    {
        //正在播放下一个动画
        if (CurrentAnimState.HandleNewState(AnimStates[(int)state]))
        {
            NextAnimState = null;
        }
        else
        {
            NextAnimState = AnimStates[(int)state];
        }
        if (null != NextAnimState)
        {
            ProgressToNextStage();
        }
    }

}
