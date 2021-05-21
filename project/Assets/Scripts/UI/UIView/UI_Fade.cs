using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UI_Fade : UIView
{
    public Image mImageFade;
    public Color mFadeOutColor;
    public Color mFadeInColor;

    public delegate void FadeInDelegate();
    public FadeInDelegate onFadeIn = null;

    public delegate void FadeOutCompleteDelegate();
    public FadeOutCompleteDelegate onFadeOut = null;


    private void Start()
    {
        DoFadeIn();
    }
    void DoFadeIn()
    {
        mImageFade.DOColor(mFadeInColor, 1.0f).OnComplete(FadeInComplete);
    }
    public void DoFadeOut()
    {
        //mImageFade
        mImageFade.DOColor(mFadeOutColor, 1.0f).SetDelay(1.5f).OnComplete(FadeOutComplete);
    }

    void FadeOutComplete()
    {
        UIManager.Instance.CloseUIViewInstance<UI_Fade>();
        if (null != onFadeOut)
            onFadeOut();       
    }

    void FadeInComplete()
    {
        if (null != onFadeIn)
            onFadeIn();
       
        DoFadeOut();
    }
}
