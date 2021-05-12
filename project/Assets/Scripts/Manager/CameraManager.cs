using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoSingleton<CameraManager>
{
    enum ECameraState
    {
        ENone,
        ECamNormal,
        ECamLeftSecondFloor,
        ECamRightFourFloor,
        ECamVeh,
    }
    private InuStateMachine<ECameraState> mFSM;
    CinemachineVirtualCamera camNormal; 
    CinemachineVirtualCamera camRightFourFloor; 
    CinemachineVirtualCamera camLeftSecondFloor;
    CinemachineVirtualCamera camVeh;
    ECameraState cam = ECameraState.ECamNormal;
    // Start is called before the first frame update
    void Start()
    {
        InitFSM();
        camNormal = GameObject.Find("CM Normal").GetComponent<CinemachineVirtualCamera>();
        camLeftSecondFloor = GameObject.Find("CM LeftSecondFloor").GetComponent<CinemachineVirtualCamera>();
        camRightFourFloor = GameObject.Find("CM RightFourFloor").GetComponent<CinemachineVirtualCamera>();
        camVeh = GameObject.Find("CM Veh").GetComponent<CinemachineVirtualCamera>();
        //camNormal = transform.GetChild(0).GetComponent<CinemachineVirtualCamera>();
        //camLeft = transform.GetChild(1).GetComponent<CinemachineVirtualCamera>();
        //camRight = transform.GetChild(2).GetComponent<CinemachineVirtualCamera>();
        mFSM.ChangeState(ECameraState.ECamNormal);
    }

    // Update is called once per frame
    void Update()
    {
        if (null != mFSM)
            mFSM.Update();
    }
    private void InitFSM()
    {
        mFSM = new InuStateMachine<ECameraState>();
        mFSM.AddState(ECameraState.ECamNormal, new StateNormal(mFSM, ECameraState.ECamNormal, this));
        mFSM.AddState(ECameraState.ECamRightFourFloor, new StateRightFourFloor(mFSM, ECameraState.ECamNormal, this));
        mFSM.AddState(ECameraState.ECamLeftSecondFloor, new StateLeftSecondFloor(mFSM, ECameraState.ECamNormal, this));
        mFSM.AddState(ECameraState.ECamVeh, new StateVeh(mFSM, ECameraState.ECamVeh, this));

    }
    public void ChangeNormal()
    {
        mFSM.ChangeState(ECameraState.ECamNormal);
    }
    public void ChangeRightFourFloor()
    {
            mFSM.ChangeState(ECameraState.ECamRightFourFloor);
    }
    public void ChangeLeftSecondFloor()
    {
            mFSM.ChangeState(ECameraState.ECamLeftSecondFloor);
    }
    public void ChangeVeh()
    {
        mFSM.ChangeState(ECameraState.ECamVeh);
    }
    class StateBase : InuStateMachine<ECameraState>.InuState
    {
        protected CameraManager mInit;
        public StateBase(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
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
    class StateNormal : StateBase
    {
        public StateNormal(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            mInit.cam = ECameraState.ECamNormal;
            mInit.camNormal.Priority = 100;
            mInit.camRightFourFloor.Priority = 10;
            mInit.camLeftSecondFloor.Priority = 10;
            mInit.camVeh.Priority = 10;

        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateRightFourFloor : StateBase
    {
        public StateRightFourFloor(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            mInit.cam = ECameraState.ECamRightFourFloor;
            mInit.camRightFourFloor.Priority = 100;
            mInit.camNormal.Priority = 10;
            mInit.camLeftSecondFloor.Priority = 10;
            mInit.camVeh.Priority = 10;
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateLeftSecondFloor : StateBase
    {
        public StateLeftSecondFloor(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            mInit.cam = ECameraState.ECamLeftSecondFloor;
            mInit.camLeftSecondFloor.Priority = 100;
            mInit.camNormal.Priority = 10;
            mInit.camRightFourFloor.Priority = 10;
            mInit.camVeh.Priority = 10;
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
    class StateVeh : StateBase
    {
        public StateVeh(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
             : base(fsm, stateName, init)
        { }
        public override void EnterState()
        {
            base.EnterState();
            mInit.cam = ECameraState.ECamLeftSecondFloor;
            mInit.camVeh.Priority = 100;
            mInit.camNormal.Priority = 10;
            mInit.camRightFourFloor.Priority = 10;
            mInit.camLeftSecondFloor.Priority = 10;
        }
        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
}
