using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
public class UI_PopUpView : UIView
{
    //public Image mBgMask;
    public RectTransform mRectMainPanel;
    Vector3 mDefaultSize = new Vector3(0.8f, 0.8f, 0.8f);
    Vector3 mTargetSize = Vector3.one;
    Ease mShowEase = Ease.OutBack;
    Ease mHideEase = Ease.InBack;
    void Start()
    {
        mRectMainPanel.transform.localScale = mDefaultSize;
        ShowView();
        InitEvent();
    }
    protected virtual void InitEvent()
    {

    }
    protected virtual void ShowView()
    {
        //GameTime.Instance.HasUiPopup = true;
        mRectMainPanel.transform.DOScale(mTargetSize, 0.3f).SetEase(mShowEase).OnComplete(AddMaskEffect);

        HideShowOtherUIView(true);
    }
    protected virtual void HideView()
    {
        mRectMainPanel.transform.DOScale(mDefaultSize, 0.3f).SetEase(mHideEase).OnComplete(CloseView);

    }

    protected virtual void CloseView()
    {

        HideShowOtherUIView(false);
        //游戏进程开始
        //GameTime.Instance.HasUiPopup = false;
    }
    void AddMaskEffect()
    {
        Debug.Log("已显示UI");
    }

    protected void HideShowOtherUIView(bool _hide)
    {

        
    }
}

