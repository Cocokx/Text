using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance = null;
    Ship ship;
    public bool isPassThr;
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
    public enum EGameState
    {
        ENone,
        EGameStart,
        ESwitchScene,
        ERoom1,
        ERoom2,
        ERoom3,
        EBackToScene,
    }
    private InuStateMachine<EGameState> mFSM;
    private void Start()
    {
        InitFSM();
    }

    // Update is called once per frame
    void Update()
    {
        if (null != mFSM)
            mFSM.Update();
    }
    private void InitFSM()
    {
        mFSM = new InuStateMachine<EGameState>();
        mFSM.AddState(EGameState.EGameStart, new StateStartGame(mFSM, EGameState.EGameStart, this));
        mFSM.AddState(EGameState.ESwitchScene, new StateSwitchScene(mFSM, EGameState.ESwitchScene, this));
        mFSM.AddState(EGameState.ERoom1, new StateEnterRoom1(mFSM, EGameState.ERoom1, this));
        mFSM.AddState(EGameState.ERoom2, new StateEnterRoom2(mFSM, EGameState.ERoom2, this));
        mFSM.AddState(EGameState.ERoom3, new StateEnterRoom3(mFSM, EGameState.ERoom3, this));
        mFSM.AddState(EGameState.EBackToScene, new StateBackScene(mFSM, EGameState.EBackToScene, this));
        mFSM.ChangeState(EGameState.EGameStart);
    }
    public void ChangeTime()
    {
        mFSM.ChangeState(EGameState.ESwitchScene);
    }
    public void BackToScene()
    {
        mFSM.ChangeState(EGameState.EBackToScene);
    }
    public void EnterRoom(E_Scene scene)
    {
        switch (scene)
        {
            case (E_Scene.E_Room1):
                mFSM.ChangeState(EGameState.ERoom1);
                break;
            case (E_Scene.E_Room2):
                mFSM.ChangeState(EGameState.ERoom2);
                break;
            case (E_Scene.E_Room3):
                mFSM.ChangeState(EGameState.ERoom3);
                break;

        }
        mFSM.ChangeState(EGameState.ESwitchScene);
    }
    class StateBase : InuStateMachine<EGameState>.InuState
    {
        protected GameDirector mInit;
        public StateBase(InuStateMachine<EGameState> fsm, EGameState stateName, GameDirector init)
            : base(fsm, stateName)
        {
            mInit = init;
        }
        public override void EnterState()
        {
            base.EnterState();

        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateStartGame : StateBase
    {
        public StateStartGame(InuStateMachine<EGameState> fsm, EGameState stateName, GameDirector init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            GameDataManager.Instance.InitSceneName();
            GameDataManager.Instance.InitPassword();
            mInit.ship = FindObjectOfType<Ship>();
            CamManager.Instance.ChangeCam(ECameraState.ECamTrackShip);
            UIManager.Instance.CreateUIViewInstance<UI_Begin>();
            UIManager.Instance.CreateUIViewInstance<UI_StartGame>();
            //Player.Instance.transform.GetComponent<NavMeshAgent>().enabled = false;
            Player.Instance.transform.SetParent(mInit.ship.transform);
            Player.Instance.transform.position = new Vector3(0, 0, 0);
            Debug.Log(Player.Instance.transform.position);
            SceneInfoManager.Instance.IsInScene1 = true;
            GameDataManager.Instance.InitProp();
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateSwitchScene : StateBase
    {
        public StateSwitchScene(InuStateMachine<EGameState> fsm, EGameState stateName, GameDirector init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            if (GameDataManager.Instance.playerPos == null)
                GameDataManager.Instance.playerPos = new Vector3();
            GameDataManager.Instance.playerPos = Player.Instance.transform.localPosition;
            mInit.isPassThr = true;
            SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[SceneInfoManager.Instance.nextScene]);

            if (SceneInfoManager.Instance.IsInScene1)
            {
                SceneInfoManager.Instance.IsInScene2 = true;
            }
            else if (SceneInfoManager.Instance.IsInScene2)
            {
                SceneInfoManager.Instance.IsInScene1 = true;
            }

        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateBackScene : StateBase
    {
        public StateBackScene(InuStateMachine<EGameState> fsm, EGameState stateName, GameDirector init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            mInit.isPassThr = true;
            SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[SceneInfoManager.Instance.nextScene]);

        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateEnterRoom1 : StateBase
    {
        public StateEnterRoom1(InuStateMachine<EGameState> fsm, EGameState stateName, GameDirector init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            if (GameDataManager.Instance.playerPos == null)
                GameDataManager.Instance.playerPos = new Vector3();
            GameDataManager.Instance.playerPos = Player.Instance.transform.localPosition;
            mInit.isPassThr = false;
            SceneInfoManager.Instance.nextScene = E_Scene.E_Nor;
            SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[E_Scene.E_Room1]);
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateEnterRoom2 : StateBase
    {
        public StateEnterRoom2(InuStateMachine<EGameState> fsm, EGameState stateName, GameDirector init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            if (GameDataManager.Instance.playerPos == null)
                GameDataManager.Instance.playerPos = new Vector3();
            GameDataManager.Instance.playerPos = Player.Instance.transform.localPosition;
            mInit.isPassThr = false;
            SceneInfoManager.Instance.nextScene = E_Scene.E_Nor;
            SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[E_Scene.E_Room2]);
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateEnterRoom3 : StateBase
    {
        public StateEnterRoom3(InuStateMachine<EGameState> fsm, EGameState stateName, GameDirector init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            if (GameDataManager.Instance.playerPos == null)
                GameDataManager.Instance.playerPos = new Vector3();
            GameDataManager.Instance.playerPos = Player.Instance.transform.localPosition;
            mInit.isPassThr = false;
            SceneInfoManager.Instance.nextScene = E_Scene.E_Past;
            SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[E_Scene.E_Room3]);
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    public void InitPlayer()
    {
        Debug.Log("play1");
        if (!isPassThr)
            return;
        if (null != GameDataManager.Instance.playerPos)
        {
            //agent.isStopped = true;
            Debug.Log("play" + GameDataManager.Instance.playerPos);
            Player.Instance.transform.localPosition = GameDataManager.Instance.playerPos;
        }
    }
}
