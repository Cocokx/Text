using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneInfoManager
{
    static SceneInfoManager instance;
    public static SceneInfoManager Instance
    {
        get
        {
            if (null == instance)
                instance = new SceneInfoManager();
            return instance;
        }
    }
    bool mIsLogicBlock;
    bool mHasUiPopup;
    bool mIsPause;
    bool mIsInScene1;
    bool mIsInScene2;
    public string Scene1 = "Scene01";
    public string Scene2 = "Scene02";
    public string nextSceneName;
    public bool IsInScene1
    {
        get { return mIsInScene1; }
        set
        {
            mIsInScene1 = value;
            if (mIsInScene1)
            {
                nextSceneName = Scene2;
                mIsInScene2 = false;
            }
        }
    }
    public bool IsInScene2
    {
        get { return mIsInScene2; }
        set
        {
            mIsInScene2 = value;
            if (mIsInScene2)
            {
                nextSceneName = Scene1;
                mIsInScene1 = false;
            }
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(nextSceneName);
        if (IsInScene1)
        {
            IsInScene2 = true;
        }
        else if (IsInScene2)
        {
            IsInScene1 = true;
        }
        
    }
    
    public bool LogicBlock
    {
        get { return mIsLogicBlock; }
        set { mIsLogicBlock = value; }
    }

    public bool HasUiPopup
    {
        get { return mHasUiPopup; }
        set { mHasUiPopup = value; }
    }
    public bool IsPause
    {
        get {
                if (!HasUiPopup && !mIsLogicBlock)
                { 
                    mIsPause = false;
                    return mIsPause;
                }
                return true;
        }
        set { mIsPause = value; }
    }
}
