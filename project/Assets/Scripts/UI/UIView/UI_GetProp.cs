using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_GetProp : UI_PopUpView
{
    public Button mBtnConfirm;
    public RawImage mIcon;
    public Text mGetText;
    protected override void onAwake()
    {
        base.onAwake();
    }
protected override void InitEvent()
    {
        base.InitEvent();
        
        mBtnConfirm.onClick.AddListener(BtnConfirmClickHandler);
        if (null != ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType))
            mIcon.texture = GameResourceManager.Instance.GetBackPackIconByName(ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType).mTexture);
        mGetText.text = ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType).mName;
    }
    protected override void ShowView()
    {
        base.ShowView();
        GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("OpenBackpack");
        GameDirector.Instance.source[1].Play();
    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_GetProp>();
    }
    void BtnConfirmClickHandler()
    {
        if (null != ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType))
            Environment.Instance.DisAppearKeys(ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType));
        GameDataManager.Instance.PickProp(ClientTableDataManager.Instance.GetTabletGameKeyById((int)Player.Instance.triggerType));
        GameDirector.Instance.source[1].clip = GameResourceManager.Instance.GetAudioEffectClipByName("GetProp");
        GameDirector.Instance.source[1].Play();
        HideView();
    }
}

