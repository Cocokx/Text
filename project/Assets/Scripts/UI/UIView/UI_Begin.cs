using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Begin : UI_PopUpView
{
    public Button mBtnClose;
    public Button mBtnBackPack;
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnClose.onClick.AddListener(BtnConfirmClickHandler);
        mBtnBackPack.onClick.AddListener(BtnBackHandler);
    }
    protected override void ShowView()
    {
        base.ShowView();
        SceneInfoManager.Instance.HasUiPopup = false;
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
    void BtnBackHandler()
    {
        UIManager.Instance.CreateUIViewInstance<UI_BackPack>();
        //HideView();
    }
}
