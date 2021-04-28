using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class AgentLocomotion : MonoBehaviour
{
    private Vector3 target;//目标位置  
    private NavMeshAgent agent;
    private Animator mAnimator;
    //private Animation anim;//动画  
    private string locoState = "Locomotion_Stand";
    private Vector3 linkStart;//OffMeshLink的开始点  
    private Vector3 linkEnd;//OffMeshLink的结束点  
    private Quaternion linkRotate;//OffMeshLink的旋转  
    private bool begin;//是否开始寻路  
    public float JumpSpeed = 0.1f;
    public float JumpTime = 2.0f;

    // Use this for initialization  
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //自动移动并关闭OffMeshLinks,即在两个隔离障碍物直接生成的OffMeshLink，agent不会自动越过  
        agent.autoTraverseOffMeshLink = false;
        //创建动画  
        mAnimator = GetComponent<Animator>();
        
        //AnimationSetup();
        //起一个协程，处理动画状态机  
        //StartCoroutine(AnimationStateMachine());
    }

    void Update()
    {
        
        //鼠标左键点击  
        if (Input.GetMouseButtonDown(0))
        {

            //摄像机到点击位置的的射线  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //判断点击的是否地形  
                if (hit.collider.tag.Equals("Obstacle"))
                {
                    begin = true;
                    //点击位置坐标  
                    target = hit.point;
                }
            }
        }
        //每一帧，设置目标点  
        if (begin)
        {
            begin = false;
            agent.SetDestination(target);
        }
    }
    void FixedUpdate()
    {
        UpdateAnimation();
        if (agent.isOnOffMeshLink)
        {
            locoState = SelectLinkAnimation();
        }
    }
    void AnimatorTrans(E_PlayerState state)
    {
        switch (state)
        {
            case E_PlayerState.E_Idle:
                mAnimator.SetBool("Idle", true);
                mAnimator.SetBool("Jump", false);
                mAnimator.SetBool("Walk", false);
                break;
            case E_PlayerState.E_Jump:
                mAnimator.SetBool("Idle", false);
                mAnimator.SetBool("Jump", true);
                mAnimator.SetBool("Walk", false);
                break;
            case E_PlayerState.E_Walk:
                mAnimator.SetBool("Idle", false);
                mAnimator.SetBool("Jump", false);
                mAnimator.SetBool("Walk", true);
                break;
        }
    }
    IEnumerator AnimationStateMachine()
    {
        //根据locoState不同的状态来处理，调用相关的函数  
        while (Application.isPlaying)
        {
            //Debug.Log(locoState);
            yield return StartCoroutine(locoState);
        }
    }

    //站立  
    IEnumerator Locomotion_Stand()
    {
        do
        {
            UpdateAnimation();
            yield return new WaitForSeconds(0);
        } while (!agent.pathPending && agent.remainingDistance < agent.stoppingDistance);
        //未到达目标点，转到下一个状态Locomotion_Move  
        locoState = "Locomotion_Move";
        yield return null;
    }

    IEnumerator Locomotion_Move()
    {
        do
        {
            UpdateAnimation();
            yield return new WaitForSeconds(0);
            //角色处于OffMeshLink，根据不同的地点，选择不同动画  
            if (agent.isOnOffMeshLink)
            {
                
                locoState = SelectLinkAnimation();
                Debug.Log(locoState);
                yield break;
            }
        } while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance);
        //} while (agent.remainingDistance != 0);
        //已经到达目标点，状态转为Stand  
        locoState = "Locomotion_Stand";
        yield return null;
    }

    IEnumerator Locomotion_Jump()
    {
        //播放跳跃动画  
        Debug.Log("播放跳跃动画");
        float time = 0;
        string linkAnim = "Jump";
        Vector2 pannelPosStart = new Vector2(transform.position.x, transform.position.z);
        Vector2 pannellinkEnd = new Vector2(linkEnd.x, linkEnd.z);
        Vector3 newPos;
        float JumpTime = 1.5f;
            //(posStart - linkStart).magnitude * JumpSpeed;
        Debug.Log("跳跃时间" + JumpTime);
        mAnimator.SetBool(linkAnim, true);
        //agent.Stop();
        agent.isStopped = true;
        do
        {
            Debug.Log("开始");
            Debug.Log(time);
            time += Time.deltaTime;
            if (time > 0.5f)
            {
                Vector2 temPosXZ = Vector2.Lerp(pannelPosStart, pannellinkEnd, JumpTime * Time.deltaTime);
                newPos = new Vector3(temPosXZ.x, transform.position.y, temPosXZ.y);
                transform.position = newPos;
            }
            

        } while (time < 2.3f);
        ////anim.CrossFade(linkAnim, 0.1f, PlayMode.StopAll);
        //transform.rotation = linkRotate;

        //do
        //{
        //    //计算新的位置  
        //    float tlerp = mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime*10.0f;
        //    Vector3 newPos = Vector3.Lerp(posStart, linkEnd, tlerp);
        //    newPos.y += 0.4f * Mathf.Sin(Mathf.PI * tlerp);
        //    transform.position = newPos;
        //    Debug.Log(mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //    yield return new WaitForSeconds(0);
        //} while (mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
        ////动画恢复到Idle  
        //agent.CompleteOffMeshLink();
        agent.isStopped = false;
        //////下一个状态为Stand  
        //transform.position = linkEnd;
        locoState = "Locomotion_Stand";
        yield return null;
    }
    ////梯子  
    //IEnumerator Locomotion_Ladder()
    //{
    //    //梯子的中心位置  
    //    Vector3 linkCenter = (linkStart + linkEnd) * 0.5f;
    //    string linkAnim;
    //    //判断是在梯子上还是梯子下  
    //    if (transform.position.y > linkCenter.y)
    //        linkAnim = "Ladder Down";
    //    else
    //        linkAnim = "Ladder Up";

    //    agent.Stop(true);

    //    Quaternion startRot = transform.rotation;
    //    Vector3 startPos = transform.position;
    //    float blendTime = 0.2f;
    //    float tblend = 0f;

    //    //角色的位置插值变化（0.2内变化）  
    //    do
    //    {
    //        transform.position = Vector3.Lerp(startPos, linkStart, tblend / blendTime);
    //        transform.rotation = Quaternion.Lerp(startRot, linkRotate, tblend / blendTime);

    //        yield return new WaitForSeconds(0);
    //        tblend += Time.deltaTime;
    //    } while (tblend < blendTime);
    //    //设置位置  
    //    transform.position = linkStart;
    //    //播放动画  
    //    anim.CrossFade(linkAnim, 0.1f, PlayMode.StopAll);
    //    agent.ActivateCurrentOffMeshLink(false);
    //    //等待动画结束  
    //    do
    //    {
    //        yield return new WaitForSeconds(0);
    //    } while (anim[linkAnim].normalizedTime < 1);
    //    agent.ActivateCurrentOffMeshLink(true);
    //    //恢复Idle状态  
    //    anim.Play("Idle");
    //    transform.position = linkEnd;
    //    agent.CompleteOffMeshLink();
    //    agent.Resume();
    //    //下一个状态Stand  
    //    locoState = "Locomotion_Stand";
    //    yield return null;
    //}

    private string SelectLinkAnimation()
    {
        //获得当前的OffMeshLink数据  
        OffMeshLinkData link = agent.currentOffMeshLinkData;
        //NavMeshLinkData a = agent.link
        Debug.Log(link);
        //计算角色当前是在link的开始点还是结束点（因为OffMeshLink是双向的）  
        float distS = (transform.position - link.startPos).magnitude;
        float distE = (transform.position - link.endPos).magnitude;

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
        //OffMeshLink的方向  
        Vector3 alignDir = linkEnd - linkStart;
        //忽略y轴  
        alignDir.y = 0;
        //计算旋转角度  
        linkRotate = Quaternion.LookRotation(alignDir);
        Debug.Log(link.offMeshLink.area);
        //判断OffMeshLink是手动的（楼梯）还是自动生成的（跳跃）  
        if (link.offMeshLink.area == 3)
        {
            return ("Locomotion_Ladder");
        }
        else if(link.offMeshLink.area == 2)
        {
            
            return ("Locomotion_Jump");
        }
        else
        {

            return ("Locomotion_Stand");
        }
    }
    
    private void UpdateAnimation()
    {
        //行走速度  
        float walkAnimationSpeed = 1.5f;
        //速度阀值（idle和walk的临界点）  
        float speedThreshold = 0.1f;
        //速度，只考虑x和z  
        Vector3 velocityXZ = new Vector3(agent.velocity.x, 0.0f, agent.velocity.z);
        //速度值  
        float speed = velocityXZ.magnitude;
        //mAnimator.speed = speed / walkAnimationSpeed;
        if (speed > speedThreshold)
        {
            Debug.Log("走路");
            AnimatorTrans(E_PlayerState.E_Walk);
        }
        else
        {
            AnimatorTrans(E_PlayerState.E_Idle);
        }
     }
    
    //更新动画融合  
    //private void UpdateAnimationBlend()
    //{
    //    //行走速度  
    //    float walkAnimationSpeed = 1.5f;
    //    //奔跑速度  
    //    float runAnimationSpeed = 4.0f;
    //    //速度阀值（idle和walk的临界点）  
    //    float speedThreshold = 0.1f;

    //    //速度，只考虑x和z  
    //    Vector3 velocityXZ = new Vector3(agent.velocity.x, 0.0f, agent.velocity.z);
    //    //速度值  
    //    float speed = velocityXZ.magnitude;
        //设置Run动画的速度  
        //anim["Run"].speed = speed / runAnimationSpeed;
        //设置Walk动画的速度  
        //anim["Walk"].speed = speed / walkAnimationSpeed;

        //根据agent的速度大小，确定animation的播放状态  
        //if (speed > (walkAnimationSpeed + runAnimationSpeed) / 2)
        //{
            //anim.CrossFade("Run");
        //}
        //if (speed > speedThreshold)
        //{
        //    anim.CrossFade("Walk");
        //}
        //else
        //{
        //    Debug.Log("停止");
        //    anim.CrossFade("Idle", 0.5f, PlayMode.StopAll);
        //}
    //}
}
