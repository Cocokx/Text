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
    public E_Scene nextScene;
    public E_Scene nowScene;
    public bool IsInScene1
    {
        get { return mIsInScene1; }
        set
        {
            mIsInScene1 = value;
            if (mIsInScene1)
            {
                nextScene = E_Scene.E_Nor;
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
                nextScene = E_Scene.E_Past;
                mIsInScene1 = false;
            }
        }
    }
    //public void LoadScene()
    //{
    //    if (GameDataManager.Instance.playerPos == null)
    //        GameDataManager.Instance.playerPos = new Vector3();
    //    GameDataManager.Instance.playerPos = Player.Instance.transform.localPosition;
    //    isPassThr = true;
    //    Debug.Log("pos" + GameDataManager.Instance.playerPos);


    //    SceneManager.LoadSceneAsync(nextSceneName);
    //    if (IsInScene1)
    //    {
    //        IsInScene2 = true;
    //    }
    //    else if (IsInScene2)
    //    {
    //        IsInScene1 = true;
    //    }
        
    //}
    
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
