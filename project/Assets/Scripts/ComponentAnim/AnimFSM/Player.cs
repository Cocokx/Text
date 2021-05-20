using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

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
    public E_Trigger triggerType = E_Trigger.E_None;
    //控制机器
    public StateMachine machine;
    private Vector3 linkStart;//OffMeshLink的开始点  
    private Vector3 linkEnd;//OffMeshLink的结束点  
    private Quaternion linkRotate;//OffMeshLink的旋转  
    public bool canClimb = true;
    public CinemachineVirtualCamera cv;
    public Transform mLift3;
    public static Player Instance = null;
    public bool canTrigger =true;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }
        //public Camera mainCamera;
    void Start()
    {
        InitPlayer();
           //mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
           agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        //ani = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        IdleState idle = new IdleState(0, this);
        WalkState walk = new WalkState(1, this);
        ClimbState climb = new ClimbState(2, this);

        machine = new StateMachine(idle);
        machine.AddState(walk);
        machine.AddState(climb);
        agent.enabled = true;
        
    }
    public void InitPlayer()
    {
        
        if (!GameDirector.Instance.isPassThr)
            return;
        if (null != GameDataManager.Instance.playerPos)
        {
            Debug.Log("play" + GameDataManager.Instance.playerPos);
            Player.Instance.transform.localPosition = GameDataManager.Instance.playerPos;
        }
    }
    void Update()
    {
        Debug.Log(triggerType);
        //Debug.Log(SceneInfoManager.Instance.IsPause);
        ////鼠标左键点击  
        if (SceneInfoManager.Instance.IsPause)
        {
            ps = E_PlayerState.E_Idle;
            machine.TranslateState((int)ps);
            
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!canTrigger)
            {
                Invoke("DelayShow", 1.5f);
                canTrigger = true;
                //transform.GetComponent<BoxCollider>().enabled = true;
            }
            
            //摄像机到点击位置的的射线  
            //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(ray);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.LogError("------ButtonDown----:");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.LogError("------hit----:");
                Debug.LogError(hit.collider.gameObject.name);
                Key key = hit.collider.gameObject.GetComponent<Key>();
                if (hit.collider.CompareTag("UI"))
                    return;
                if (null != key && key.ID == (int)triggerType)
                {
                    if (key.ID == (int)E_Trigger.E_Seed )
                    {
                        Environment.Instance.DisAppearKeys(ClientTableDataManager.Instance.GetTabletGameKeyById(key.ID));
                        GameDataManager.Instance.PickProp(ClientTableDataManager.Instance.GetTabletGameKeyById(key.ID));
                    }
                    else if(key.ID == (int)E_Trigger.E_RoomKey)
                    {
                        UIManager.Instance.CreateUIViewInstance<UI_Dia>();
                    }
                    else
                    {
                        UIManager.Instance.CreateUIViewInstance<UI_Password>();
                    }
                    
                }
                else if (hit.collider.gameObject.name=="Gift" && triggerType == E_Trigger.E_Gift)
                {
                    CamManager.Instance.ChangeCam(ECameraState.ECamRoomFree);
                    UIManager.Instance.CreateUIViewInstance<UI_BackRoom>();
                }
                //else if (hit.collider.gameObject.name == "Password" && triggerType == E_Trigger.E_Password)
                //{
                //    UIManager.Instance.CreateUIViewInstance<UI_Password>();
                //}
                else if (hit.collider.gameObject.name == "Door" && triggerType == E_Trigger.E_Door)
                {
                    GameDirector.Instance.BackToScene();
                }
                else
                    agent.SetDestination(hit.point);
            }
        }
        ChangeState();
        UpdateAnimation();
    }
    void DelayShow()
    {
        transform.GetComponent<BoxCollider>().enabled = true;
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
                //Debug.Log("walk");
                ps = E_PlayerState.E_Walk;
            }
            else
            {
                //Debug.Log("idle");
                ps = E_PlayerState.E_Idle;
            }
        }
        //Debug.Log("是否碰到Link"+agent.isOnOffMeshLink);
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
            if (agent.currentOffMeshLinkData.offMeshLink.area == 4)
            {
                agent.CompleteOffMeshLink();

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
        switch (other.gameObject.name)
        {
            case "LiftTrigger":
                UIManager.Instance.CreateUIViewInstance<UI_Lift>();
                other.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "PlaneTrigger":
                UIManager.Instance.CreateUIViewInstance<UI_EnterRoom>();
                break;
            case "RoomTrigger":
                //UIManager.Instance.CreateUIViewInstance<UI_EnterRoom>();
                break;
            case "LeftCamTrigger2":
                CamManager.Instance.ChangeCam(ECameraState.ECamLeft2);
                break;
            case "LeftCamTrigger3":
                CamManager.Instance.ChangeCam(ECameraState.ECamLeft3);
                break;
            case "LeftCamTrigger4":
                CamManager.Instance.ChangeCam(ECameraState.ECamLeft4);
                break;
            case "LeftCamTrigger5":
                CamManager.Instance.ChangeCam(ECameraState.ECamLeft5);
                break;
            case "DoorTrigger":
                CamManager.Instance.ChangeCam(ECameraState.ECamNormal);
                transform.parent = null;
                break;
            case "Gift":
                triggerType = E_Trigger.E_Gift;
                break;
            //case "Password":
            //    triggerType = E_Trigger.E_Password;
            //    break;
            case "Door":
                triggerType = E_Trigger.E_Door;
                break;
        }
        if (other.gameObject.GetComponent<TimeMachine>() != null)
        {
            triggerType = E_Trigger.E_TimeMachine;
            GameDirector.Instance.machine = other.gameObject.GetComponent<TimeMachine>().machine;
            UIManager.Instance.CreateUIViewInstance<UI_EnterRoom>();
            
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
        else if(other.gameObject.GetComponent<Room>() != null)
        {
            triggerType = E_Trigger.E_Room;
            UIManager.Instance.CreateUIViewInstance<UI_EnterRoom>();
            SceneInfoManager.Instance.nowScene = other.gameObject.GetComponent<Room>().type;
        }
        else
        {
            //triggerType = E_Trigger.E_None;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("离开" + other.gameObject.name);
        if (other.transform.CompareTag("Trigger"))
            triggerType = E_Trigger.E_None;
        //if (other.gameObject.GetComponent<Key>() != null
        //    || other.gameObject.GetComponent<Prop>() != null)
        //{
        //    triggerType = E_Trigger.E_None;
        //    Debug.Log("triggerType" + triggerType);
        //}
        if (other.gameObject.name == "LiftTrigger")
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
        switch (other.gameObject.name)
        {
            case "LeftCamTrigger2":
            case "LeftCamTrigger3":
            case "LeftCamTrigger4":
            case "LeftCamTrigger5":
                CamManager.Instance.ChangeCam(ECameraState.ECamNormal);
                break;
        }
    }
    public void SetPlayerPosition(Vector3 tar)
    {
        agent.SetDestination(tar);
    }
}
