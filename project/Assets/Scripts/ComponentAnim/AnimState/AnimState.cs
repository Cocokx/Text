using UnityEngine;
public class AnimState
{ 
    protected Animation AnimEngine;
    private bool m_Finished = true;
    public AnimState(Animation anims )
    {
        AnimEngine = anims;
    }
    virtual public void OnActivate()
    {
        SetFinished(false);
    }

    virtual public void OnDeactivate()
    {
    }
    virtual public bool HandleNewState(AnimState state) { return false; } // new action is comming..
    virtual public void Release() { SetFinished(true); } // finish currrent action and then finish state
    
    // update current state
    virtual public void Update()
    {
              
    }

    virtual public bool IsFinished() { return m_Finished; }

    public virtual void SetFinished(bool finished) { m_Finished = finished; } // state is finished or not

    virtual protected void Initialize()
    {
    }
    protected void SetMoveStateForFixPos()
    {
    }

    protected void ResetPos()
    {
        AnimEngine.transform.localPosition = Vector3.zero;
    }
    protected void MoveEnable(bool _enable)
    {

    }
    
    protected void PlayAnima(string anim)
    {
        if (string.IsNullOrEmpty(anim))
            Debug.LogError("---anim---empty------");
        else
        {
            if (GetCurrentAnima() != anim)
            {
                if (null != AnimEngine)
                {
                    AnimEngine.CrossFade(anim);
                }
            }
        }
    }
    protected string GetCurrentAnima()
    {
        return AnimEngine.name;
    }
    protected void PauseAnima()
    {
        AnimEngine.enabled = false;
    }
    protected void ResumeAnima()
    {
        AnimEngine.enabled = true;
    }
    protected bool IsAnimaPlaying(string anim)
    {
        return AnimEngine.name == anim;
    }
    
}
