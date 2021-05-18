using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_EnterRoom : UI_PopUpView
{
    public Button mBtnClose;
    public Button mBtnEnter;
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnClose.onClick.AddListener(BtnConfirmClickHandler);
        mBtnEnter.onClick.AddListener(BtnEnterClickHandler);
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
    void BtnConfirmClickHandler()
    {
        HideView();
    }
    void BtnEnterClickHandler()
    {

        HideView();
    }
}

