using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_StartGame : UI_PopUpView
{
    public Button mBtnQuit;
    public Button mBtnStart;
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnQuit.onClick.AddListener(BtnQuitClickHandler);
        mBtnStart.onClick.AddListener(BtnStartHandler);
    }
    protected override void ShowView()
    {
        base.ShowView();
    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_StartGame>();
    }
    void BtnQuitClickHandler()
    {
        Application.Quit();
    }
    void BtnStartHandler()
    {
        BeginSceneDirector.Instance.PlayTimeline();
        HideView();
    }
}
