using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance = null;
    Ship ship;
    public AudioSource[] source;
    public bool isPassThr;
    public bool TimeTravel;
    public E_TimeMachine machine;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        source = transform.GetComponents<AudioSource>();
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
            GameDataManager.Instance.InitDia();
            Environment.Instance.InitTimeMachinePos();
            mInit.ship = FindObjectOfType<Ship>();
            mInit.isPassThr = false;
            mInit.source[0].clip = GameResourceManager.Instance.GetBGMByName("Post");
            mInit.source[0].Play();

            CamManager.Instance.ChangeCam(ECameraState.ECamNormal);
            CamManager.Instance.ChangeCam(ECameraState.ECamTrackShip);
            UIManager.Instance.CreateUIViewInstance<UI_Begin>();
            UIManager.Instance.CreateUIViewInstance<UI_StartGame>();
            Player.Instance.transform.GetComponent<NavMeshAgent>().isStopped = true;
            Player.Instance.transform.SetParent(mInit.ship.transform);
            Player.Instance.transform.localPosition = new Vector3(0, 0, 2.3F);
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
        float time = 0;
        float timeMachine = 2.0f;
        bool CanChange;
        GameObject go;
        public StateSwitchScene(InuStateMachine<EGameState> fsm, EGameState stateName, GameDirector init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            time = 0;
            timeMachine = 1.0f;
            CanChange = true;
            mInit.TimeTravel = true;
            if (GameDataManager.Instance.playerPos == null)
                GameDataManager.Instance.playerPos = new Vector3();
            GameDataManager.Instance.playerPos = Player.Instance.transform.localPosition;
            mInit.isPassThr = true;
            go = Resources.Load<GameObject>("Time/TimeEffect");
            Debug.Log(go.name);
            go = Instantiate(go, GameDataManager.Instance.mTimeMechinePos[mInit.machine], Quaternion.identity);

        }
        public override void UpdateState()
        {
            base.UpdateState();
            if (CanChange)
            {
                if (time < timeMachine)
                {
                    time+=Time.deltaTime;
                }
                else
                {

                    mInit.SwitchScene();
                    CanChange = false;
                    
                }
            }
            
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
            mInit.SwitchBackScene();
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    public void SwitchRoom1()
    {
        UI_Fade fadeView = UIManager.Instance.CreateUIViewInstance<UI_Fade>();
        fadeView.onFadeIn = LoadRoom1;
        fadeView.onFadeOut = SwitchSceneComplete;
    }
    public void SwitchRoom2()
    {
        UI_Fade fadeView = UIManager.Instance.CreateUIViewInstance<UI_Fade>();
        fadeView.onFadeIn = LoadRoom2;
        fadeView.onFadeOut = SwitchSceneComplete;
    }
    public void SwitchRoom3()
    {
        UI_Fade fadeView = UIManager.Instance.CreateUIViewInstance<UI_Fade>();
        fadeView.onFadeIn = LoadRoom3;
        fadeView.onFadeOut = SwitchSceneComplete;
    }
    public void SwitchScene()
    {
        UI_Fade fadeView = UIManager.Instance.CreateUIViewInstance<UI_Fade>();
        fadeView.onFadeIn = LoadScene;
        fadeView.onFadeOut = SwitchSceneComplete;
    }
    public void SwitchBackScene()
    {
        UI_Fade fadeView = UIManager.Instance.CreateUIViewInstance<UI_Fade>();
        fadeView.onFadeIn = LoadBackScene;
        fadeView.onFadeOut = SwitchSceneComplete;
    }
    public void SwitchSceneComplete()
    {
        Debug.Log("SwitchSceneComplete");
    }
    public void LoadBackScene()
    {
        SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[SceneInfoManager.Instance.nextScene]);
        if (SceneInfoManager.Instance.IsInScene1)
        {
            SceneInfoManager.Instance.nextScene = E_Scene.E_Nor;
        }
        else if (SceneInfoManager.Instance.IsInScene2)
        {
            SceneInfoManager.Instance.nextScene = E_Scene.E_Past;
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[SceneInfoManager.Instance.nextScene]);

        if (SceneInfoManager.Instance.IsInScene1)
        {
            SceneInfoManager.Instance.IsInScene2 = true;
            source[0].clip = GameResourceManager.Instance.GetBGMByName("Normal");
            source[0].Play();
        }
        else if (SceneInfoManager.Instance.IsInScene2)
        {
            SceneInfoManager.Instance.IsInScene1 = true;
            source[0].clip = GameResourceManager.Instance.GetBGMByName("Post");
            source[0].Play();
        }
    }
    public void LoadRoom1()
    {
        SceneInfoManager.Instance.nextScene = E_Scene.E_Nor;
        SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[E_Scene.E_Room1]);
    }
    public void LoadRoom2()
    {
        SceneInfoManager.Instance.nextScene = E_Scene.E_Nor;
        SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[E_Scene.E_Room2]);
    }
    public void LoadRoom3()
    {
        SceneInfoManager.Instance.nextScene = E_Scene.E_Past;
        SceneManager.LoadSceneAsync(GameDataManager.Instance.mScene[E_Scene.E_Room3]);
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
            mInit.SwitchRoom1();
            
            
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
            mInit.SwitchRoom2();
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
            mInit.SwitchRoom3();
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
