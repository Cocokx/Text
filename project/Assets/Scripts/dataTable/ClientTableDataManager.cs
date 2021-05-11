using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if !(UNITY_WP8 || UNITY_METRO)
using System.Threading;
#endif
using System;

public class ClientTableDataManager
{
    static ClientTableDataManager s_pInstance = null;

    public static ClientTableDataManager Instance
    {
        get
        {
            if (s_pInstance == null)
            {
                s_pInstance = new ClientTableDataManager();
            }
            return s_pInstance;
        }
    }
    public static void Reset()
    {
        s_pInstance = null;
        s_pInstance = new ClientTableDataManager();
    }
    
    public TabletDutiesInfo mTabletDutiesInfo;
    public TabletBossDutiesInfo mTabletBossDutiesInfo;
    public TabletBossDutiesUnlockInfo mTabletBossDutiesUnlockInfo;
    public TabletBossDutiesUnlockItemInfo mTabletBossDutiesUnlockItemInfo;

    public TableGameKey mTableGameKey;
    public TableGameProp mTableGameProp;
    

    public bool sInited = false;
#if !(UNITY_WP8 || UNITY_METRO)
    Thread mReadThread = null;
    int mThreadCount = 0;
#endif

    public void Init()
    {
        if (!sInited)
        {
            
            sInited = true;
        }
    }

    
    public TabletDutiesInfo.ObjTabletDutiesInfo GetTabletDutiesInfoById(string _id)
    {
        if (null == mTabletDutiesInfo)
        {
            mTabletDutiesInfo = new TabletDutiesInfo();
            mTabletDutiesInfo.ReadTable();
            mTabletDutiesInfo.ParseData();
        }
        return mTabletDutiesInfo.GetTabletDutiesInfoById(_id);
    }

    public List<TabletDutiesInfo.ObjTabletDutiesInfo> GetTabletDutiesInfotyType(EEmployeeDutiesType _type)
    {
        if (null == mTabletDutiesInfo)
        {
            mTabletDutiesInfo = new TabletDutiesInfo();
            mTabletDutiesInfo.ReadTable();
            mTabletDutiesInfo.ParseData();
        }
        return mTabletDutiesInfo.GetTabletDutiesInfotyType(_type);
    }

    public TabletBossDutiesInfo.ObjTabletBossDutiesInfo GetTabletBossDutiesInfoById(string _id)
    {
        if (null == mTabletBossDutiesInfo)
        {
            mTabletBossDutiesInfo = new TabletBossDutiesInfo();
            mTabletBossDutiesInfo.ReadTable();
            mTabletBossDutiesInfo.ParseData();
        }
        return mTabletBossDutiesInfo.GetTabletBossDutiesInfoById(_id);
    }

    public List<TabletBossDutiesInfo.ObjTabletBossDutiesInfo> GetTabletBossDutiesInfoByType(EBossDutiesType _type)
    {
        if (null == mTabletBossDutiesInfo)
        {
            mTabletBossDutiesInfo = new TabletBossDutiesInfo();
            mTabletBossDutiesInfo.ReadTable();
            mTabletBossDutiesInfo.ParseData();
        }
        return mTabletBossDutiesInfo.GetTabletBossDutiesInfoByType(_type);
    }

    public TabletBossDutiesUnlockInfo.ObjTabletBossDutiesUnlockInfo GetTabletBossDutiesUnlockInfoById(string _id)
    {
        if (null == mTabletBossDutiesUnlockInfo)
        {
            mTabletBossDutiesUnlockInfo = new TabletBossDutiesUnlockInfo();
            mTabletBossDutiesUnlockInfo.ReadTable();
            mTabletBossDutiesUnlockInfo.ParseData();
        }
        return mTabletBossDutiesUnlockInfo.GetTabletBossDutiesUnlockInfoById(_id);
    }
    public List<TabletBossDutiesUnlockInfo.ObjTabletBossDutiesUnlockInfo> GetAllTabletBossDutiesUnlockInfo()
    {
        if (null == mTabletBossDutiesUnlockInfo)
        {
            mTabletBossDutiesUnlockInfo = new TabletBossDutiesUnlockInfo();
            mTabletBossDutiesUnlockInfo.ReadTable();
            mTabletBossDutiesUnlockInfo.ParseData();
        }
        return mTabletBossDutiesUnlockInfo.GetAllTabletBossDutiesInfo();
    }

    public TabletBossDutiesUnlockItemInfo.ObjTabletBossDutiesUnlockItemInfo GetTabletBossDutiesUnlockItemInfoById(string _id)
    {
        if (null == mTabletBossDutiesUnlockItemInfo)
        {
            mTabletBossDutiesUnlockItemInfo = new TabletBossDutiesUnlockItemInfo();
            mTabletBossDutiesUnlockItemInfo.ReadTable();
            mTabletBossDutiesUnlockItemInfo.ParseData();
        }
        return mTabletBossDutiesUnlockItemInfo.GetBossDutiesUnlockItemInfoById(_id);
    }
    public List<TableGameKey.ObjTabletGameKey> GetAllTabletGameKey()
    {
        if (null == mTableGameKey)
        {
            mTableGameKey = new TableGameKey();
            mTableGameKey.ReadTable();
            mTableGameKey.ParseData();
        }
        return mTableGameKey.GetAllTabletGameKey();
    }

    public TableGameKey.ObjTabletGameKey GetTabletGameKeyById(int _id)
    {
        if (null == mTableGameKey)
        {
            mTableGameKey = new TableGameKey();
            mTableGameKey.ReadTable();
            mTableGameKey.ParseData();
        }
        return mTableGameKey.GetTabletGameKeyById(_id);
    }
    public TableGameKey.ObjTabletGameKey GetTabletGameKeyByEffectObjName(string _objName)
    {
        if (null == mTableGameKey)
        {
            mTableGameKey = new TableGameKey();
            mTableGameKey.ReadTable();
            mTableGameKey.ParseData();
        }
        return mTableGameKey.GetTabletGameKeyByEffectObjName(_objName);
    }
    public TableGameKey.ObjTabletGameKey GetTabletGameKeyByObjName(string _objName)
    {
        if (null == mTableGameKey)
        {
            mTableGameKey = new TableGameKey();
            mTableGameKey.ReadTable();
            mTableGameKey.ParseData();
        }
        return mTableGameKey.GetTabletGameKeyByObjName(_objName);
    }
    public List<TableGameProp.ObjTabletGameProp> GetAllTabletGameProp()
    {
        if (null == mTableGameProp)
        {
            mTableGameProp = new TableGameProp();
            mTableGameProp.ReadTable();
            mTableGameProp.ParseData();
        }
        return mTableGameProp.GetAllTabletGameProp();
    }
    public TableGameProp.ObjTabletGameProp GetTabletGamePropByObjName(string _objName)
    {
        if (null == mTableGameProp)
        {
            mTableGameProp = new TableGameProp();
            mTableGameProp.ReadTable();
            mTableGameProp.ParseData();
        }
        return mTableGameProp.GetTabletGamePropByObjName(_objName);
    }
    public TableGameProp.ObjTabletGameProp GetTabletGamePropById(int _id)
    {
        if (null == mTableGameProp)
        {
            mTableGameProp = new TableGameProp();
            mTableGameProp.ReadTable();
            mTableGameProp.ParseData();
        }
        return mTableGameProp.GetTabletGamePropById(_id);
    }
}
