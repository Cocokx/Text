using UnityEngine;
using System.Collections.Generic;

public abstract class AnimFSM
{
    protected List<AnimState> AnimStates;
    protected AnimState CurrentAnimState;
    protected AnimState NextAnimState;
    protected AnimState DefaultAnimState;

    protected Animation AnimEngine;

    public AnimFSM(Animation anims)
    {
        AnimEngine = anims;
        AnimStates = new List<AnimState>();
    }
    
    public virtual void Initialize()
    {
        CurrentAnimState = DefaultAnimState;
        CurrentAnimState.OnActivate();
        NextAnimState = null;
    }
    public void Reset()
    {
        for (int i = 0; i < AnimStates.Count; i++)
        {
            if (AnimStates[i].IsFinished() == false)
            {
                AnimStates[i].OnDeactivate();
                AnimStates[i].SetFinished(true);
            }
        }
    }
    public abstract void DoAction(E_PlayerState state);
    protected void ProgressToNextStage()
    {
        Debug.LogError("-----------NextAnimState-----------:" + NextAnimState.ToString());
        CurrentAnimState.Release();
        CurrentAnimState = NextAnimState;
        CurrentAnimState.OnActivate();
        NextAnimState = null;
    }
}