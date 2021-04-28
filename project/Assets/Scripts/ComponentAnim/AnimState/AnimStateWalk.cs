using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateWalk : AnimState
{
    public AnimStateWalk(Animation anims) : base(anims)
    {
    }

    public override bool HandleNewState(AnimState anim)
    {
        if(anim is AnimStateWalk)
        {
            return true;
        }
        if (anim is AnimStateIdle)
        {
            SetFinished(true);
        }
        return false;
    }
    public override void OnActivate()
    {
        base.OnActivate();
        PlayWalkAnim();
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
    }

    public override void Release()
    {
        SetFinished(true);
    }
    void PlayWalkAnim()
    {
        string name = AnimSet.Instance.GetWalkAnim();
        if (!IsAnimaPlaying(name))
            PlayAnima(name);
    }
}
