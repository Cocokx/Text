using Cinemachine;
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
    public static Player Instance = null;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public NavMeshAgent agent;
    //private Animation ani;
    public Animator animator;
    public E_PlayerState ps = E_PlayerState.E_Idle;
    public E_Trigger triggerType = E_Trigger.E_None;
    //控制机器
    public StateMachine machine;
    private Vector3 linkStart;//OffMeshLink的开始点  
    private Vector3 linkEnd;//OffMeshLink的结束点  
    private Quaternion linkRotate;//OffMeshLink的旋转  
    public bool canClimb = true;
    public CinemachineVirtualCamera cv;
    //public Camera mainCamera;
    void Start()
    {
        //mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
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
        //Debug.Log(SceneInfoManager.Instance.IsPause);
        ////鼠标左键点击  
        if (SceneInfoManager.Instance.IsPause)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            //摄像机到点击位置的的射线  
            //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(ray);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log(Physics.Raycast(ray, out hit));
            if (Physics.Raycast(ray, out hit))
            {
                Debug.LogError("------hit----:");
                Debug.LogError(hit.collider.gameObject.name);
                Key key = hit.collider.gameObject.GetComponent<Key>();
                if (null != key && key.ID == (int)triggerType)
                {
                    Environment.Instance.DisAppearKeys(ClientTableDataManager.Instance.GetTabletGameKeyById(key.ID));
                    GameDataManager.Instance.PickProp(ClientTableDataManager.Instance.GetTabletGameKeyById(key.ID));
                }
                else
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LeftCamTrigger2")
        {
            Debug.Log("LeftCamTrigger2");
            CameraManager.Instance.ChangeCam(CameraManager.ECameraState.ECamLeft2);
        }
        if (other.gameObject.name == "LeftCamTrigger3")
        {
            Debug.Log("LeftCamTrigger3");
            CameraManager.Instance.ChangeCam(CameraManager.ECameraState.ECamLeft3);
        }
        if (other.gameObject.name == "LeftCamTrigger4")
        {
            Debug.Log("LeftCamTrigger4");
            CameraManager.Instance.ChangeCam(CameraManager.ECameraState.ECamLeft4);
        }
        if (other.gameObject.name == "LeftCamTrigger5")
        {
            Debug.Log("LeftCamTrigger5");
            CameraManager.Instance.ChangeCam(CameraManager.ECameraState.ECamLeft5);
        }
        if (other.gameObject.name == "DoorTrigger")
        {
            Debug.Log("DoorTrigger");
            CameraManager.Instance.ChangeCam(CameraManager.ECameraState.ECamNormal);
            transform.parent = null;
        }
        if (other.gameObject.GetComponent<Key>() != null)
        {
            triggerType = (E_Trigger)other.gameObject.GetComponent<Key>().ID;
            Debug.Log("碰到" + other.gameObject.name);
            Debug.Log("triggerType" + triggerType);
        }
        else if (other.gameObject.GetComponent<Prop>() != null)
        {
            TableGameKey.ObjTabletGameKey prop =
                ClientTableDataManager.Instance.GetTabletGameKeyById(other.gameObject.GetComponent<Prop>().ID);
            if (prop != null)
                triggerType = (E_Trigger)prop.mEffectId;
            Debug.Log("碰到" + other.gameObject.name);
            Debug.Log("triggerType" + triggerType);
        }
        else
        {
            //triggerType = E_Trigger.E_None;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Key>() != null
            || other.gameObject.GetComponent<Prop>() != null)
        {
            triggerType = E_Trigger.E_None;
            Debug.Log("triggerType" + triggerType);
        }
        if (other.gameObject.name == "LeftCamTrigger2"
            || other.gameObject.name == "LeftCamTrigger3"
            ||other.gameObject.name == "LeftCamTrigger4"
            ||   other.gameObject.name == "LeftCamTrigger5")
        {
            CameraManager.Instance.ChangeCam(CameraManager.ECameraState.ECamNormal);
        }
    }
}
