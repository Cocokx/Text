using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_EnterRoom : UI_PopUpView
{
    public Button mBtnClose;
    public Button mBtnEnter;
    E_Trigger trigger;
    private void Awake()
    {
        base.onAwake();
        trigger = Player.Instance.triggerType;
    }
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnClose.onClick.AddListener(BtnCancelClickHandler);
        mBtnEnter.onClick.AddListener(BtnEnterClickHandler);
        switch (trigger)
        {
            case E_Trigger.E_Room:
                mBtnEnter.GetComponentInChildren<Text>().text = "进入房间";
                
                break;
            case E_Trigger.E_Plane:
                mBtnEnter.GetComponentInChildren<Text>().text = "进入飞机";
                break;
            case E_Trigger.E_TimeMachine:
                mBtnEnter.GetComponentInChildren<Text>().text = "时空穿梭";
                
                break;
            case E_Trigger.E_Door:
                mBtnEnter.GetComponentInChildren<Text>().text = "离开房间";
                break;
        }
    }
    protected override void ShowView()
    {
        base.ShowView();
        
    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_EnterRoom>();
    }
    void BtnCancelClickHandler()
    {
        HideView();
    }
    void BtnEnterClickHandler()
    {
        HideView();
        switch(trigger)
        {
            case E_Trigger.E_Room:
                GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("OpenDoor");
                GameDirector.Instance.source[1].Play();
                GameDirector.Instance.EnterRoom(SceneInfoManager.Instance.nowScene);
                
                break;
            case E_Trigger.E_Plane:
                GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("Plane");
                GameDirector.Instance.source[1].Play();
                Player.Instance.agent.enabled = false;
                Player.Instance.transform.SetParent(Environment.Instance.plane.transform);
                Player.Instance.transform.position = Environment.Instance.plane.transform.position;
                Environment.Instance.plane.startPlane = true;
                Environment.Instance.plane.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 20;
                
                Debug.Log("进入飞机");
                break;
            case E_Trigger.E_TimeMachine:
                GameDirector.Instance.ChangeTime();
                GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("PassThr");
                GameDirector.Instance.source[1].Play();
                Debug.Log("进入时空");
                break;
            case E_Trigger.E_Door:
                GameDirector.Instance.BackToScene();
                GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("CloseDoor");
                GameDirector.Instance.source[1].Play();
                Debug.Log("离开房间");
                break;
        }
    }
}

