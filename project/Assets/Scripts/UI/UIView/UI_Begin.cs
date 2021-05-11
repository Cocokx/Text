using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Begin : UI_PopUpView
{
    public Button mBtnClose;
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnClose.onClick.AddListener(BtnConfirmClickHandler);
    }
    protected override void ShowView()
    {
        base.ShowView();

    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_Begin>();
    }
    void BtnConfirmClickHandler()
    {
        SceneInfoManager.Instance.LoadScene();
        //HideView();
    }
}
