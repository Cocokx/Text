using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoSingleton<CameraManager>
{
    //public enum ECameraState
    //{
    //    ENone,
    //    ECamNormal,
    //    ECamLeft2,
    //    ECamLeft3,
    //    ECamLeft4,
    //    ECamLeft5,
    //    ECamTrackShip,
    //    ECamTrackPlane,
    //    ECamRightFourFloor,
    //    ECamVeh,
    //}
    //private InuStateMachine<ECameraState> mFSM;
    //public CinemachineVirtualCamera camNormal;
    ////public CinemachineVirtualCamera camRightFourFloor;
    //public CinemachineVirtualCamera camLeft2;
    //public CinemachineVirtualCamera camLeft3;
    //public CinemachineVirtualCamera camLeft4;
    //public CinemachineVirtualCamera camLeft5;
    //public CinemachineVirtualCamera camVeh;
    //public CinemachineVirtualCamera camTrackShip;
    //public CinemachineVirtualCamera camTrackPlane;
    //ECameraState cam = ECameraState.ECamNormal;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    InitFSM();
    //    //camNormal = transform.Find("CM Normal").GetComponent<CinemachineVirtualCamera>();
    //    //camLeftSecondFloor = transform.Find("CM LeftSecondFloor").GetComponent<CinemachineVirtualCamera>();
    //    //camRightFourFloor = transform.Find("CM RightFourFloor").GetComponent<CinemachineVirtualCamera>();
    //    //camVeh = transform.Find("CM Veh").GetComponent<CinemachineVirtualCamera>();
    //    //camNormal = transform.GetChild(0).GetComponent<CinemachineVirtualCamera>();
    //    //camLeft = transform.GetChild(1).GetComponent<CinemachineVirtualCamera>();
    //    //camRight = transform.GetChild(2).GetComponent<CinemachineVirtualCamera>();
    //    //mFSM.ChangeState(ECameraState.ECamNormal);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (null != mFSM)
    //        mFSM.Update();
    //}
    //private void InitFSM()
    //{
    //    mFSM = new InuStateMachine<ECameraState>();
    //    mFSM.AddState(ECameraState.ECamNormal, new StateNormal(mFSM, ECameraState.ECamNormal, this));
    //    mFSM.AddState(ECameraState.ECamRightFourFloor, new StateRightFourFloor(mFSM, ECameraState.ECamRightFourFloor, this));
    //    mFSM.AddState(ECameraState.ECamLeft2, new StateLeft2(mFSM, ECameraState.ECamLeft2, this));
    //    mFSM.AddState(ECameraState.ECamLeft3, new StateLeft3(mFSM, ECameraState.ECamLeft3, this));
    //    mFSM.AddState(ECameraState.ECamLeft4, new StateLeft4(mFSM, ECameraState.ECamLeft4, this));
    //    mFSM.AddState(ECameraState.ECamLeft5, new StateLeft5(mFSM, ECameraState.ECamLeft5, this));
    //    mFSM.AddState(ECameraState.ECamVeh, new StateVeh(mFSM, ECameraState.ECamVeh, this));
    //    mFSM.AddState(ECameraState.ECamTrackShip, new StateTrackShip(mFSM, ECameraState.ECamTrackShip, this));
    //    mFSM.AddState(ECameraState.ECamTrackPlane, new StateTrackPlane(mFSM, ECameraState.ECamTrackPlane, this));
    //    if (!SceneInfoManager.Instance.isPassThr)
    //        mFSM.ChangeState(ECameraState.ECamTrackShip);
    //    else
    //        mFSM.ChangeState(ECameraState.ECamNormal);
    //}
    //public void ChangeCam(ECameraState state)
    //{
    //    mFSM.ChangeState(state);
    //}
    
    //class StateBase : InuStateMachine<ECameraState>.InuState
    //{
    //    protected CameraManager mInit;
    //    public StateBase(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //        : base(fsm, stateName)
    //    {
    //        mInit = init;
    //    }
    //    public override void EnterState()
    //    {
    //        base.EnterState();

    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateNormal : StateBase
    //{
    //    public StateNormal(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        mInit.cam = ECameraState.ECamNormal;
    //        mInit.camNormal.Priority = 100;
    //        mInit.camLeft3.Priority = 10;
    //        mInit.camLeft2.Priority = 10;
    //        mInit.camLeft4.Priority = 10;
    //        mInit.camLeft5.Priority = 10;
    //        mInit.camTrackShip.Priority = 10;
    //        mInit.camTrackPlane.Priority = 10;
    //        mInit.camVeh.Priority = 10;

    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateTrackShip : StateBase
    //{
    //    public StateTrackShip(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        mInit.cam = ECameraState.ECamTrackShip;
    //        mInit.camNormal.Priority = 10;
    //        mInit.camLeft3.Priority = 10;
    //        mInit.camLeft2.Priority = 10;
    //        mInit.camLeft4.Priority = 10;
    //        mInit.camLeft5.Priority = 10;
    //        mInit.camTrackShip.Priority = 100;
    //        mInit.camTrackPlane.Priority = 10;
    //        mInit.camVeh.Priority = 10;

    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateTrackPlane : StateBase
    //{
    //    public StateTrackPlane(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        mInit.cam = ECameraState.ECamTrackPlane;
    //        mInit.camNormal.Priority = 10;
    //        mInit.camLeft3.Priority = 10;
    //        mInit.camLeft2.Priority = 10;
    //        mInit.camLeft4.Priority = 10;
    //        mInit.camLeft5.Priority = 10;
    //        mInit.camTrackShip.Priority = 10;
    //        mInit.camTrackPlane.Priority = 100;
    //        mInit.camVeh.Priority = 10;

    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateRightFourFloor : StateBase
    //{
    //    public StateRightFourFloor(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        mInit.cam = ECameraState.ECamRightFourFloor;
    //        //mInit.camRightFourFloor.Priority = 100;
    //        mInit.camNormal.Priority = 10;
    //        mInit.camLeft2.Priority = 10;
    //        mInit.camVeh.Priority = 10;
    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateLeft2 : StateBase
    //{
    //    public StateLeft2(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        Debug.Log("aa");
    //        mInit.camLeft2.Priority = 100;
    //        mInit.camLeft3.Priority = 10;
    //        mInit.camNormal.Priority = 10;
    //        mInit.camLeft4.Priority = 10;
    //        mInit.camLeft5.Priority = 10;
    //        mInit.camVeh.Priority = 10;
    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateLeft3 : StateBase
    //{
    //    public StateLeft3(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        Debug.Log("3楼");
    //        mInit.camLeft2.Priority = 10;
    //        mInit.camLeft3.Priority = 100;
    //        mInit.camNormal.Priority = 10;
    //        mInit.camLeft4.Priority = 10;
    //        mInit.camLeft5.Priority = 10;
    //        mInit.camVeh.Priority = 10;
    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateLeft4 : StateBase
    //{
    //    public StateLeft4(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        Debug.Log("aa");
    //        mInit.camLeft2.Priority = 10;
    //        mInit.camLeft3.Priority = 10;
    //        mInit.camNormal.Priority = 10;
    //        mInit.camLeft4.Priority = 100;
    //        mInit.camLeft5.Priority = 10;
    //        mInit.camVeh.Priority = 10;
    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateLeft5 : StateBase
    //{
    //    public StateLeft5(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        Debug.Log("aa");
    //        mInit.camLeft2.Priority = 10;
    //        mInit.camLeft3.Priority = 10;
    //        mInit.camNormal.Priority = 10;
    //        mInit.camLeft4.Priority = 10;
    //        mInit.camLeft5.Priority = 100;
    //        mInit.camVeh.Priority = 10;
    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
    //class StateVeh : StateBase
    //{
    //    public StateVeh(InuStateMachine<ECameraState> fsm, ECameraState stateName, CameraManager init)
    //         : base(fsm, stateName, init)
    //    { }
    //    public override void EnterState()
    //    {
    //        base.EnterState();
    //        mInit.cam = ECameraState.ECamVeh;
    //        mInit.camNormal.Priority = 10;
    //        mInit.camLeft3.Priority = 10;
    //        mInit.camLeft2.Priority = 10;
    //        mInit.camLeft4.Priority = 10;
    //        mInit.camLeft5.Priority = 10;
    //        mInit.camVeh.Priority = 100;
    //    }
    //    public override void UpdateState()
    //    {
    //        base.UpdateState();
    //    }
    //}
}
