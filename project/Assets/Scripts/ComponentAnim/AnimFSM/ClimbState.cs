using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class ClimbState : StateTemplate<Player>
{

    private Vector3 linkStart;//OffMeshLink的开始点  
    private Vector3 linkEnd;//OffMeshLink的结束点  
    private Quaternion linkRotate;//OffMeshLink的旋转  
    float mTimer = 0.0f;
    float mDelayTimer = 0.2f;
    float minDis = 0.8f;
    public Vector3 movingValue;
    public ClimbState(int id, Player p) : base(id, p)
    {
    }

    public override void OnEnter(params object[] args)
    {
        base.OnEnter(args);
        Debug.Log("climb");
        mTimer = 0.0f;
        owner.agent.isStopped = true;
        owner.animator.SetInteger("PlayerState", (int)owner.ps);
        //DOTween.To(() => movingValue, x => movingValue = x, linkEnd, 1);
        LinkData();
    }
    public override void OnStay(params object[] args)
    {
        base.OnStay(args);
        if (mTimer < mDelayTimer)
        {
            owner.transform.position = Vector3.Lerp(owner.transform.position, linkStart, mTimer / mDelayTimer);
            owner.transform.rotation = Quaternion.Lerp(owner.transform.rotation, linkRotate, mTimer / mDelayTimer);
            mTimer += Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(owner.transform.position.y - linkEnd.y) > 1.0f)
            {
                owner.transform.DOMove(linkEnd, 1).SetSpeedBased();
                owner.transform.rotation = linkRotate;
            }
            else
            {
                owner.transform.DOPause();
                owner.agent.ActivateCurrentOffMeshLink(true);
                owner.transform.position = linkEnd;
                owner.agent.CompleteOffMeshLink();
                owner.agent.isStopped = false;
                owner.ps = E_PlayerState.E_Walk;
                owner.canClimb = true;
            }
        }
    }
    public override void OnExit(params object[] args)
    {
        base.OnExit(args);
    }
    
    private void LinkData()
    {
        //获得当前的OffMeshLink数据  
        OffMeshLinkData link = owner.agent.currentOffMeshLinkData;
        //计算角色当前是在link的开始点还是结束点（因为OffMeshLink是双向的）  
        float distS = (owner.transform.position - link.startPos).magnitude;
        float distE = (owner.transform.position - link.endPos).magnitude;

        if (distS < distE)
        {
            linkStart = link.startPos;
            linkEnd = link.endPos;
        }
        else
        {
            linkStart = link.endPos;
            linkEnd = link.startPos;
        }
        //梯子的中心位置  
        Vector3 linkCenter = (linkStart + linkEnd) * 0.5f;
        //OffMeshLink的方向  
        Vector3 alignDir = linkEnd - linkStart;
        if (owner.transform.position.y > linkCenter.y)
        {
            alignDir = linkStart - linkEnd;
        }
        else
        {
            alignDir = linkEnd - linkStart;
        }
        alignDir.y = 0;
        //忽略y轴  
        alignDir.y = 0;
        //计算旋转角度  
        linkRotate = Quaternion.LookRotation(alignDir);
    }
}