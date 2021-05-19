using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Dia : UI_PopUpView
{
    public Text mTxtContent;
    public Button mBtnNext;
    List<string> mListAppraiseContent;
    int mAppraiseIndex = 0;
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnNext.onClick.AddListener(NextSetpHandler);
        mListAppraiseContent = GameDataManager.Instance.mDiaList;
        mTxtContent.text = mListAppraiseContent[0];
    }
    protected override void ShowView()
    {
        base.ShowView();
    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_Dia>();
    }
    void NextSetpHandler()
    {
        
        if (null != mListAppraiseContent && mListAppraiseContent.Count > 0 && mAppraiseIndex < mListAppraiseContent.Count - 1)
        {
            if (null != mTxtContent.gameObject.GetComponent<TypewriterEffect>())
                Destroy(mTxtContent.gameObject.GetComponent<TypewriterEffect>());

            mTxtContent.text = "";
            mAppraiseIndex++;
            mTxtContent.text = mListAppraiseContent[mAppraiseIndex];
            mTxtContent.gameObject.AddComponent<TypewriterEffect>();
            Invoke("ShowBossTalkAnima", 0.3f);
        }
        else
        {
            UIManager.Instance.CreateUIViewInstance<UI_GetProp>();
            CloseView();
        }
            
    }
}
