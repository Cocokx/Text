using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    //public List<TableGameKey.ObjTabletGameKey> mListUnPickProp;
    //已经捡起来的物品，true说明被使用，在场景，false说明未使用，在背包
    public  Dictionary<TableGameKey.ObjTabletGameKey,E_PropState> mDicProp;
    public Dictionary<E_Scene, string> mScene;
    public Dictionary<E_Scene, List<int>> mPassword;
    
    public Vector3 playerPos;
    static GameDataManager instance;
    public static GameDataManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new GameDataManager();
            }

            return instance;
        }
    }
    public void InitPassword()
    {
        List<int> room1 = new List<int>();
        List<int> room2 = new List<int>();
        room1.Add(1);
        room1.Add(2);
        room1.Add(3);
        room2.Add(3);
        room2.Add(3);
        room2.Add(3);
        if (null == mPassword)
            mPassword = new Dictionary<E_Scene, List<int>>();
        mPassword.Add(E_Scene.E_Room1, room1);
        mPassword.Add(E_Scene.E_Room3, room2);
    }
    public void InitSceneName()
    {
        if (null == mScene)
            mScene = new Dictionary<E_Scene, string>();
        mScene.Add(E_Scene.E_Past, "PastScene");
        mScene.Add(E_Scene.E_Nor, "NormalScene");
        mScene.Add(E_Scene.E_Room1, "Room1");
        mScene.Add(E_Scene.E_Room2, "Room2");
        mScene.Add(E_Scene.E_Room3, "Room3");
    }
    //捡物品时候，未捡列表发生变化，已经捡起的字典发生变化
    public void PickProp(TableGameKey.ObjTabletGameKey _info)
    {
        if (null == mDicProp)
        {
            InitProp();
        }
        if (mDicProp.ContainsKey(_info) && mDicProp[_info] == E_PropState.E_UnPicked)
            mDicProp[_info] = E_PropState.E_PickedUnUsed;
    }
    public void UseProp(TableGameKey.ObjTabletGameKey _info)
    {
        if (null == mDicProp)
        {
            InitProp();
        }
        if (mDicProp.ContainsKey(_info) && mDicProp[_info] == E_PropState.E_PickedUnUsed)
            mDicProp[_info] = E_PropState.E_PickedUsed;
    }
    public void InitProp()
    {
        mDicProp = new Dictionary<TableGameKey.ObjTabletGameKey, E_PropState>();
        List<TableGameKey.ObjTabletGameKey> mListProp = ClientTableDataManager.Instance.GetAllTabletGameKey();
        for (int i = 0; i < mListProp.Count; i++)
        {
            mDicProp.Add(mListProp[i], E_PropState.E_UnPicked);
        }
    }
    public bool CheckIsGetUnuseProp(TableGameKey.ObjTabletGameKey _info)
    {
        if (null != mDicProp)
            return (mDicProp.ContainsKey(_info) && mDicProp[_info] == E_PropState.E_PickedUnUsed);

        return false;
    }
    //public bool CheckIsUsedProp(TableGameKey.ObjTabletGameKey _info)
    //{
    //    if (null != mDicProp)
    //        return (mDicProp.ContainsKey(_info) && mDicProp[_info]);

    //    return false;
    //}
}
