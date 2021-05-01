using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// PlayerCtrl
/// 挂载在角色身上的脚本，用来控制状态机器类
/// </summary>
/// 
public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    //private Animation ani;
    public Animator animator;
    public E_PlayerState ps = E_PlayerState.E_Idle;

    //控制机器
    public StateMachine machine;
    private Vector3 linkStart;//OffMeshLink的开始点  
    private Vector3 linkEnd;//OffMeshLink的结束点  
    private Quaternion linkRotate;//OffMeshLink的旋转  
    public bool canClimb = true;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //ani = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        IdleState idle = new IdleState(0, this);
        WalkState walk = new WalkState(1, this);
        ClimbState climb = new ClimbState(2, this);

        machine = new StateMachine(idle);
        machine.AddState(walk);
        machine.AddState(climb);
    }

    void Update()
    {
        //鼠标左键点击  
        if (Input.GetMouseButtonDown(0))
        {
            //摄像机到点击位置的的射线  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("鼠标点击");
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        ChangeState();
        UpdateAnimation();
    }
    void ChangeState()
    {
        if(!agent.isStopped)
        {
            //速度，只考虑x和z  
            Vector3 velocityXZ = new Vector3(agent.velocity.x, 0.0f, agent.velocity.z);
            //速度值  
            float speed = velocityXZ.magnitude;
            if (speed > 0)
            {
                Debug.Log("walk");
                ps = E_PlayerState.E_Walk;
            }
            else
            {
                Debug.Log("idle");
                ps = E_PlayerState.E_Idle;
            }
        }
        Debug.Log(agent.isOnOffMeshLink);
        if (agent.isOnOffMeshLink )
        {
            Debug.Log(agent.currentOffMeshLinkData.offMeshLink.area);
            if (agent.currentOffMeshLinkData.offMeshLink.area == 3 && canClimb)
            {
                Debug.Log("aaa");
                canClimb = false;
                agent.isStopped = true;
                ps = E_PlayerState.E_Climb;
                machine.TranslateState((int)ps);

            }
        }
            
    }
    
    private void UpdateAnimation()
    {
        switch (ps)
        {
            case E_PlayerState.E_Idle:
            case E_PlayerState.E_Walk:
                machine.TranslateState((int)ps);
                break;
        }
    }

    void LateUpdate()
    {
        machine.Update();
    }
}
