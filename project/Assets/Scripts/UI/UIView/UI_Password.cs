using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Password : UI_PopUpView
{
    public Button mBtnClose;
    public Button mBtnConfirm;
    public List<InputField> mPassword;
    public Text mError;
    //public 
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnClose.onClick.AddListener(BtnCancelClickHandler);
        mBtnConfirm.onClick.AddListener(BtnConfirmClickHandler);
    }
    protected override void ShowView()
    {
        base.ShowView();
        mError.gameObject.SetActive(false);
    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_Password>();
    }
    void BtnCancelClickHandler()
    {
        HideView();
    }
    void BtnConfirmClickHandler()
    {
        List<int> mPin = new List<int>();
        mPin = GameDataManager.Instance.mPassword[SceneInfoManager.Instance.nowScene];
        for(int i = 0; i < mPassword.Count; i++)
        {
            if (mPassword[i].text != mPin[i].ToString())
            {
                Debug.Log("输入错误");
                StartCoroutine(CloseError());
                return;
            }
                
        }
        Debug.Log("输入正确");
        HideView();
    }
    IEnumerator CloseError()
    {
        yield return new WaitForSeconds(2);
        mError.gameObject.SetActive(false);
    }
}

