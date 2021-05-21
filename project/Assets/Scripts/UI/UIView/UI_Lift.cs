using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Lift : UI_PopUpView
{
    public Button mBtnClose;
    public Button mBtn1;
    public Button mBtn2;
    //public Button mBtn3;
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnClose.onClick.AddListener(BtnConfirmClickHandler);
        mBtn1.onClick.AddListener(BtnTo1);
        mBtn2.onClick.AddListener(BtnTo2);
        //mBtn3.onClick.AddListener(BtnTo3);
    }
    protected override void ShowView()
    {
        base.ShowView();
        //SceneInfoManager.Instance.HasUiPopup = false;
    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_Lift>();
    }
    void BtnConfirmClickHandler()
    {
        HideView();
    }
    void BtnTo1()
    {
        GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("Lift");
        GameDirector.Instance.source[1].Play();
        Player.Instance.SetPlayerPosition(Environment.Instance.Lift[0].position);
        HideView();
    }
    void BtnTo2()
    {
        GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("Lift");
        GameDirector.Instance.source[1].Play();
        Player.Instance.SetPlayerPosition(Environment.Instance.Lift[1].position);
        HideView();
    }
    void BtnTo3()
    {
        Player.Instance.SetPlayerPosition(Environment.Instance.Lift[2].position);
        HideView();
    }
}

