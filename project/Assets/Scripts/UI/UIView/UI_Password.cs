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
        GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("OpenBackpack");
        GameDirector.Instance.source[1].Play();
    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_Password>();
    }
    protected override void CloseViewOpen()
    {
        base.CloseViewOpen();
        UIManager.Instance.CloseUIViewInstance<UI_Password>();
    }
    void BtnCancelClickHandler()
    {
        HideView();
        GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("Back");
        GameDirector.Instance.source[1].Play();
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
                mError.gameObject.SetActive(true);
                StartCoroutine(CloseError());
                GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("Error");
                GameDirector.Instance.source[1].Play();
                return;
            }
                
        }
        Debug.Log("输入正确");
        HideViewOpen();
        GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("Passward");
        GameDirector.Instance.source[1].Play();
        UIManager.Instance.CreateUIViewInstance<UI_GetProp>();
        //StartCoroutine(Open());

        //if (null != ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType))
        //    Environment.Instance.DisAppearKeys(ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType));
        //    GameDataManager.Instance.PickProp(ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType));
        
        
    }
    IEnumerator CloseError()
    {
        yield return new WaitForSeconds(2);
        mError.gameObject.SetActive(false);
    }
    IEnumerator Open()
    {
        yield return new WaitForSeconds(1);
        UIManager.Instance.CreateUIViewInstance<UI_GetProp>();
    }
}

