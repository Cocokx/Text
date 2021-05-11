using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    //public List<TableGameKey.ObjTabletGameKey> mListUnPickProp;
    //已经捡起来的物品，true说明被使用，在场景，false说明未使用，在背包
    public  Dictionary<TableGameKey.ObjTabletGameKey,E_PropState> mDicProp;
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
