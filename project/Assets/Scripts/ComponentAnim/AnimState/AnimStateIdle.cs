using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateIdle : AnimState
{
    public AnimStateIdle(Animation anims) : base(anims)
    {
    }

    public override bool HandleNewState(AnimState anim)
    {
        return false;
    }

    public override void OnActivate()
    {
        base.OnActivate();
        PlayIdleAnim();
    }

    public override void OnDeactivate()
    {
        base.OnDeactivate();
    }

    public override void Release()
    {
        SetFinished(true);
    }
    void PlayIdleAnim()
    {
        string name = AnimSet.Instance.GetIdleAnim();
        if (!IsAnimaPlaying(name))
            PlayAnima(name);
    }
    
}
