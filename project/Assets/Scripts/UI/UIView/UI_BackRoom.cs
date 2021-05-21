using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_BackRoom : UI_PopUpView
{
    public Button mBtnBack;
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnBack.onClick.AddListener(BtnEnterClickHandler);
    }
    protected override void ShowView()
    {
        base.ShowView();
    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_BackRoom>();
    }
    void BtnEnterClickHandler()
    {
        CamManager.Instance.ChangeCam(ECameraState.ECamRoomNor);
        GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("Back");
        GameDirector.Instance.source[1].Play();
        HideView();
    }
}
