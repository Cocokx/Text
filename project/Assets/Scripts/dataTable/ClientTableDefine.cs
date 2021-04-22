using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DataParseUtils
{
    //[10|30|50|70]
    public static List<int> GetIntCompositeData(string _dataStr)
    {
        List<int> listResult = new List<int>();
        if (_dataStr.IndexOf("[") > -1)
        {
            string mTempDataStr = _dataStr.Remove(_dataStr.Length - 1, 1);
            mTempDataStr = mTempDataStr.Remove(0, 1);
            if (mTempDataStr.IndexOf('|') > -1)
            {
                string[] temDataStrs = mTempDataStr.Split('|');
                for (int z = 0; z < temDataStrs.Length; z++)
                {
                    listResult.Add(int.Parse(temDataStrs[z]));
                }
            }
            else
                listResult.Add(int.Parse(mTempDataStr));
        }
        return listResult;
    }
    //[1.0|3.0|5.0|7.0]
    public static List<float> GetFloatCompositeData(string _dataStr)
    {        
        List<float> listResult = new List<float>();
        if (_dataStr.IndexOf("[") > -1)
        {
            string mTempDataStr = _dataStr.Remove(_dataStr.Length - 1, 1);
            mTempDataStr = mTempDataStr.Remove(0, 1);
            if (mTempDataStr.IndexOf('|') > -1)
            {
                string[] temDataStrs = mTempDataStr.Split('|');
                for (int z = 0; z < temDataStrs.Length; z++)
                {
                    listResult.Add(float.Parse(temDataStrs[z]));
                }
            }
            else
                listResult.Add(float.Parse(mTempDataStr));
        }
        return listResult;
    }


    public static List<string> GetStringCompositeData(string _dataStr)
    {
        List<string> listResult = new List<string>();
        if (_dataStr.IndexOf("[") > -1)
        {
            string mTempDataStr = _dataStr.Remove(_dataStr.Length - 1, 1);
            mTempDataStr = mTempDataStr.Remove(0, 1);
            if (mTempDataStr.IndexOf('|') > -1)
            {
                string[] temDataStrs = mTempDataStr.Split('|');
                for (int z = 0; z < temDataStrs.Length; z++)
                {
                    listResult.Add(temDataStrs[z]);
                }
            }
            else
                listResult.Add(mTempDataStr);
        }
        return listResult;
    }

}

[System.Serializable]
public class Dimension2D
{
    public int x;
    public int y;
    public Dimension2D()
    {
        x = 0;
        y = 0;
    }
    public Dimension2D(int _x, int _y)
    {
        x = _x;
        y = _y;
    }
    public Vector2 ToVector2()
    {
        return new Vector2(x, y);
    }
}


public abstract class TableData
{
    // table
    protected RawTable mTableData;
    protected uint mHash = 0;
    static Dictionary<int, uint> s_hashDictionary = new Dictionary<int, uint>();
    public static void Reset()
    {
        s_hashDictionary.Clear();
    }
    static void CheckHash(string _path, uint _hash)
    {
        int key = _path.GetHashCode();
        uint oldHash;
        if (s_hashDictionary.TryGetValue(key, out oldHash))
        {
            if (oldHash != _hash)
                Application.Quit();
        }
        else
            s_hashDictionary.Add(key, _hash);
    }

    public static uint ComputeHash(byte[] s)
    {
        uint h = 0;
        for (int i = s.Length - 1; i >= 0; --i)
        {
            h = (h << 5) - h + s[i];
        }
        return h;
    }
    public static uint ComputeHash(char[] s)
    {
        uint h = 0;
        for (int i = s.Length - 1; i >= 0; --i)
        {
            h = (h << 5) - h + s[i];
        }
        return h;
    }
    protected virtual uint GetHash()
    {
        return 0;
    }
    protected abstract string GetPath();
    protected abstract void _ParseData();

    public uint CheckHash()
    {
        uint hash = GetHash();

        CheckHash(GetPath(), hash);

        return hash;
    }
    public void ReadTable()
    {
        if (mTableData == null)
            mTableData = new RawTable();

        mTableData.readBinary(GetPath());
    }
    public void ParseData()
    {
        _ParseData();
        CheckHash();
        mTableData = null;
    }
}




#region employee Duties
public class TabletDutiesInfo : TableData
{
    public readonly string sFilePath = "tDuties";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletDutiesInfo
    {
        public string mId;
        public EEmployeeDutiesType mType;
        public string mName;
        public string mPreId;
        public string mSkillName;
        public string mDesc;
        public string mSkillIcon;
        public int mDesign;
        public int mTech;
        public int mArt;
        public int mSalary;
        public int mloyal;
        public int mAddedDesign;
        public int mAddedTech;
        public int mAddedArt;
    }
    Dictionary<string, ObjTabletDutiesInfo> mDicInfo;
    Dictionary<EEmployeeDutiesType, List<ObjTabletDutiesInfo>> mDicTypeInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<string, ObjTabletDutiesInfo>();
        mDicTypeInfo = new Dictionary<EEmployeeDutiesType, List<ObjTabletDutiesInfo>>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletDutiesInfo info = new ObjTabletDutiesInfo();
            info.mId = mTableData.GetStr(i, DataDefine.Duties_Duties_Id);
            info.mType = (EEmployeeDutiesType)mTableData.GetInt(i, DataDefine.Duties_Duties_Type);
            info.mName = mTableData.GetStr(i, DataDefine.Duties_Duties_Name);
            info.mPreId = mTableData.GetStr(i, DataDefine.Duties_Duties_PreId);
            info.mSkillName = mTableData.GetStr(i, DataDefine.Duties_Duties_SkillName);
            info.mDesc = mTableData.GetStr(i, DataDefine.Duties_Duties_Desc);
            info.mSkillIcon = mTableData.GetStr(i, DataDefine.Duties_Duties_SkillIcon);
            //info.mExp = mTableData.GetInt(i, DataDefine.Duties_Duties_Exp);
            //info.mDesign = mTableData.GetInt(i, DataDefine.Duties_Duties_Design);
            //info.mTech = mTableData.GetInt(i, DataDefine.Duties_Duties_Tech);
            //info.mArt = mTableData.GetInt(i, DataDefine.Duties_Duties_Art);
            info.mSalary = mTableData.GetInt(i, DataDefine.Duties_Duties_Salary);
            info.mloyal = mTableData.GetInt(i, DataDefine.Duties_Duties_loyal);
            info.mAddedDesign = mTableData.GetInt(i, DataDefine.Duties_Duties_AddedDesign);
            info.mAddedTech = mTableData.GetInt(i, DataDefine.Duties_Duties_AddedTech);
            info.mAddedArt = mTableData.GetInt(i, DataDefine.Duties_Duties_AddedArt);

            mDicInfo[info.mId] = info;

            if (!mDicTypeInfo.ContainsKey(info.mType))
                mDicTypeInfo[info.mType] = new List<ObjTabletDutiesInfo>();

            mDicTypeInfo[info.mType].Add(info);
        }
    }

    public ObjTabletDutiesInfo GetTabletDutiesInfoById(string _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }
    public List<ObjTabletDutiesInfo> GetTabletDutiesInfotyType(EEmployeeDutiesType _type)
    {
        if (null != mDicTypeInfo && mDicTypeInfo.ContainsKey(_type))
            return mDicTypeInfo[_type];

        return null;
    }

}
#endregion

#region boss Duties
public class TabletBossDutiesInfo : TableData
{
    public readonly string sFilePath = "tBossDuties";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletBossDutiesInfo
    {
        public string mId;
        public EBossDutiesType mType;
        public string mName;
        public string mPreId;
        public string mSkillName;
        public string mDesc;
        public string mSkillIcon;
        public int mExp;
        public int mMoney;
        public int mHotValue;
        public int mCostMoney;
    }
    Dictionary<string, ObjTabletBossDutiesInfo> mDicInfo;
    Dictionary<EBossDutiesType, List<ObjTabletBossDutiesInfo>> mDicTypeInfo;

    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<string, ObjTabletBossDutiesInfo>();
        mDicTypeInfo = new Dictionary<EBossDutiesType, List<ObjTabletBossDutiesInfo>>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletBossDutiesInfo info = new ObjTabletBossDutiesInfo();
            info.mId = mTableData.GetStr(i, DataDefine.Duties_Boss_Id);          
            info.mType = (EBossDutiesType)mTableData.GetInt(i, DataDefine.Duties_Boss_Type);
            info.mName = mTableData.GetStr(i, DataDefine.Duties_Boss_Name);
            info.mPreId = mTableData.GetStr(i, DataDefine.Duties_Boss_PreId);
            //Debug.LogError("-- info.mPreId--:" + info.mPreId);
            info.mSkillName = mTableData.GetStr(i, DataDefine.Duties_Boss_SkillName);
            info.mDesc = mTableData.GetStr(i, DataDefine.Duties_Boss_Desc);
            info.mSkillIcon = mTableData.GetStr(i, DataDefine.Duties_Boss_SkillIcon);
            info.mExp = mTableData.GetInt(i, DataDefine.Duties_Boss_Exp);
            info.mMoney = mTableData.GetInt(i, DataDefine.Duties_Boss_Money);
            info.mHotValue = mTableData.GetInt(i, DataDefine.Duties_Boss_HotValue);
            info.mCostMoney = mTableData.GetInt(i, DataDefine.Duties_Boss_CostMoney);
            
            mDicInfo[info.mId] = info;
            if (!mDicTypeInfo.ContainsKey(info.mType))
                mDicTypeInfo[info.mType] = new List<ObjTabletBossDutiesInfo>();

            mDicTypeInfo[info.mType].Add(info);
        }
    }

    public ObjTabletBossDutiesInfo GetTabletBossDutiesInfoById(string _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }

    public List<ObjTabletBossDutiesInfo> GetTabletBossDutiesInfoByType(EBossDutiesType _type)
    {
        if (null != mDicTypeInfo && mDicTypeInfo.ContainsKey(_type))
            return mDicTypeInfo[_type];

        return null;
    }
}
#endregion
#region boss unlock
public class TabletBossDutiesUnlockInfo : TableData
{
    public readonly string sFilePath = "tBossDutiesUnlock";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletBossDutiesUnlockInfo
    {
        public string mId;
        public EBossDutiesType mType;
        public string mName;
        public string mDesc;
        public int mMoney;
        //public int mHotValue;
    }
    Dictionary<string, ObjTabletBossDutiesUnlockInfo> mDicInfo;
    List<ObjTabletBossDutiesUnlockInfo> allBossDutiesUnlockInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<string, ObjTabletBossDutiesUnlockInfo>();
        allBossDutiesUnlockInfo = new List<ObjTabletBossDutiesUnlockInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletBossDutiesUnlockInfo info = new ObjTabletBossDutiesUnlockInfo();
            info.mId = mTableData.GetStr(i, DataDefine.Duties_BossDutiesUnlock_Id);
            info.mType = (EBossDutiesType)mTableData.GetInt(i, DataDefine.Duties_BossDutiesUnlock_Type);

            info.mName = mTableData.GetStr(i, DataDefine.Duties_BossDutiesUnlock_Desc);
            info.mDesc = mTableData.GetStr(i, DataDefine.Duties_BossDutiesUnlock_DescId);
            info.mMoney = mTableData.GetInt(i, DataDefine.Duties_BossDutiesUnlock_Money);
            //info.mHotValue = mTableData.GetInt(i, DataDefine.Duties_BossDutiesUnlock_HotValue);

            mDicInfo[info.mId] = info;
            allBossDutiesUnlockInfo.Add(info);
        }
    }

    public ObjTabletBossDutiesUnlockInfo GetTabletBossDutiesUnlockInfoById(string _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }
    public List<ObjTabletBossDutiesUnlockInfo> GetAllTabletBossDutiesInfo()
    {
        return allBossDutiesUnlockInfo;
    }
}
#endregion

#region BossDutiesUnlockItemInfo
public class TabletBossDutiesUnlockItemInfo : TableData
{
    public readonly string sFilePath = "tBossDutiesUnlockItemInfo";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletBossDutiesUnlockItemInfo
    {
        public string mId;
        public string mName;
        public string mDesc;
    }
    Dictionary<string, ObjTabletBossDutiesUnlockItemInfo> mDicInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<string, ObjTabletBossDutiesUnlockItemInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletBossDutiesUnlockItemInfo info = new ObjTabletBossDutiesUnlockItemInfo();
            info.mId = mTableData.GetStr(i, DataDefine.Duties_BossDutiesUnlockItemInfo_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Duties_BossDutiesUnlockItemInfo_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Duties_BossDutiesUnlockItemInfo_Desc);

            mDicInfo[info.mId] = info;
        }
    }

    public ObjTabletBossDutiesUnlockItemInfo GetBossDutiesUnlockItemInfoById(string _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];
        return null;
    }
}
#endregion
