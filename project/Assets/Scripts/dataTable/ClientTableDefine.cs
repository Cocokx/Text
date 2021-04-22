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


public class TableGameProperty : TableData
{
    // file path
    public readonly string sFilePath = "tData";
    // data
    //onslider
    public float DirectionChangeInterval = 0.0f;
    public int InitialMoney;
    public int OfficeRent;
    public int OfficeRent1;
    public int OfficeRent2;
    public int GameEndMoney;
    protected override string GetPath()
    {
        return sFilePath;
    }

    protected override void _ParseData()
    {
        Dictionary<string, string> dic_props = new Dictionary<string, string>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            dic_props.Add(mTableData.GetStr(i, DataDefine.Property_Data_Key),
                            mTableData.GetStr(i, DataDefine.Property_Data_Value));
        }
        DirectionChangeInterval = float.Parse(dic_props["DirectionChangeInterval"]);
        InitialMoney = int.Parse(dic_props["InitialMoney"]);
        OfficeRent = int.Parse(dic_props["OfficeRent"]);
        OfficeRent1 = int.Parse(dic_props["OfficeRent1"]);
        OfficeRent2 = int.Parse(dic_props["OfficeRent2"]);

        GameEndMoney = int.Parse(dic_props["GameEndMoney"]);
    }
}


#region role
public class TableRoleInfoConfig : TableData
{
    public class ObjRoleConfigInfo
    {
        public string mId;
        public E_RoleType mType;        
        public string mName;
      
        public int mAge;   
        public int mHireLev;
        public int mBaseStamina;
        public string mAvatar;    
        public string mDesc;
        public string mSkinName;
        public List<ERoleActionTypeEnum> mActionList;
        public float mHungerAttenuation;
        public float mStrengthAttenuation;
        public float mPressAttenuation;
        public float mLoyalContactAttenuation;

        //public ERoleHobbyType mHobbyType;
        public int mPassiveSkillId;
        public int mCoreplayId;
        public int mTopicId;

        //public ApplicationConditionType mApplicationConditionType;
        public int mApplicationConditionValue;
        public string mOpeningRemarks;

        public List<string> mUnlockDutiesList;
        public E_RoleType mRoleType;
        public float mRoleProfessionValue1;
        public float mRoleProfessionValue2;
        public float mRoleProfessionValue3;

        public float mDefaultExp;
    }

    public readonly string sFilePath = "tRole";
    protected override string GetPath()
    {
        return sFilePath;
    }

    public Dictionary<string, ObjRoleConfigInfo> mDicData;
    List<ObjRoleConfigInfo> mAllRoleList;
    protected override void _ParseData()
    {
        mDicData = new Dictionary<string, ObjRoleConfigInfo>();
        mAllRoleList = new List<ObjRoleConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjRoleConfigInfo info = new ObjRoleConfigInfo();
            info.mId = mTableData.GetStr(i, DataDefine.Role_Role_id);
            info.mName = mTableData.GetStr(i, DataDefine.Role_Role_Name);
          
            info.mAge = mTableData.GetInt(i, DataDefine.Role_Role_Age);

            info.mType = (E_RoleType)mTableData.GetInt(i, DataDefine.Role_Role_Profession);
            //info.mSubType = (EProfessionType)mTableData.GetInt(i, DataDefine.Role_Role_SubType);
            //info.mBaseSalary = mTableData.GetInt(i, DataDefine.Role_Role_BaseSalary);
            //info.mNationality = mTableData.GetStr(i, DataDefine.Role_Role_Nationality);
            //info.mLearnAblity = mTableData.GetInt(i, DataDefine.Role_Role_LearnAblity);
            //info.mHireLev = mTableData.GetInt(i, DataDefine.Role_Role_HireLev);

            //info.mGameDesign = mTableData.GetInt(i, DataDefine.Role_Role_Gameplay);
            //info.mTechnology = mTableData.GetInt(i, DataDefine.Role_Role_Tech);
            //info.mArt = mTableData.GetInt(i, DataDefine.Role_Role_Art);
            //info.mWorkingAbility = mTableData.GetInt(i, DataDefine.Role_Role_WorkingAbility);
            info.mBaseStamina = GetRamdomValue(mTableData.GetStr(i, DataDefine.Role_Role_BaseStamina));

            //info.mArt = mTableData.GetInt(i, DataDefine.Role_Role_MainAbility);
            //info.mStrength = mTableData.GetInt(i, DataDefine.Role_Role_StrengthMax);

            //info.mEventId = mTableData.GetInt(i, DataDefine.Role_Role_EventId);
            info.mAvatar = mTableData.GetStr(i, DataDefine.Role_Role_SkinName);

            info.mDesc = mTableData.GetStr(i, DataDefine.Role_Role_Desc);
            info.mSkinName = mTableData.GetStr(i, DataDefine.Role_Role_SkinName);
            //info.mObjName = "Spine_juese_" + Random.Range(1,19);
            //info.mMissionList = new List<int>();
            //List<int> actionIdInfo = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Role_Role_ActionList));
            //info.mActionList = new List<ERoleActionTypeEnum>();
            //if (null != actionIdInfo && actionIdInfo.Count > 0)
            //{
            //    for (int m = 0; m < actionIdInfo.Count; m++)
            //    {
            //        info.mActionList.Add((ERoleActionTypeEnum)actionIdInfo[m]);
            //    }
            //}

            //info.mStaminaReversionSpeed = mTableData.GetInt(i, DataDefine.Role_Role_StaminaReversionSpeed);
            //info.mPressureLimit = mTableData.GetInt(i, DataDefine.Role_Role_PressureLimit);
            //info.mDiversity = mTableData.GetFloat(i, DataDefine.Role_Role_Diversity);
            //info.mExpressiveness = mTableData.GetFloat(i, DataDefine.Role_Role_Expressiveness);
            //info.mContend = mTableData.GetFloat(i, DataDefine.Role_Role_Contend);
            //info.mOperation = mTableData.GetFloat(i, DataDefine.Role_Role_Operation);
            //info.mSocialContact = mTableData.GetFloat(i, DataDefine.Role_Role_SocialContact);
            //info.mSubstitution = mTableData.GetFloat(i, DataDefine.Role_Role_Substitution);

            //info.mDreamThirstValue = mTableData.GetFloat(i, DataDefine.Role_Role_DreamThirstValue);
            //info.mMoneyThirstValue = mTableData.GetFloat(i, DataDefine.Role_Role_MoneyThirstValue);

            //info.mHungerAttenuation = mTableData.GetFloat(i, DataDefine.Role_Role_HungerAttenuation);
            info.mStrengthAttenuation = mTableData.GetFloat(i, DataDefine.Role_Role_StrengthAttenuation);
            info.mPressAttenuation = mTableData.GetFloat(i, DataDefine.Role_Role_PressAttenuation);
            info.mLoyalContactAttenuation = mTableData.GetFloat(i, DataDefine.Role_Role_LoyalContactAttenuation);
            //info.mHobbyType = (ERoleHobbyType)mTableData.GetInt(i, DataDefine.Role_Role_Hobby);
            info.mPassiveSkillId = mTableData.GetInt(i, DataDefine.Role_Role_PassiveSkillId);

            string coreplayAndTopicStr = mTableData.GetStr(i, DataDefine.Role_Role_CoreplayAndTopic);
            if (!string.IsNullOrEmpty(coreplayAndTopicStr) && coreplayAndTopicStr != "-")
            {
                List<int> coreplayAndTopic = DataParseUtils.GetIntCompositeData(coreplayAndTopicStr);
                info.mCoreplayId = coreplayAndTopic[0];
                info.mTopicId = coreplayAndTopic[1];
            }

            //string applicationConditionStr = mTableData.GetStr(i, DataDefine.Role_Role_ApplicationCondition);
        
            //if (!string.IsNullOrEmpty(applicationConditionStr) && applicationConditionStr != "-")
            //{
            //    List<int> applicationCondition = DataParseUtils.GetIntCompositeData(applicationConditionStr);
            //    if (null != applicationCondition && applicationCondition.Count == 2)
            //    {
            //        //info.mApplicationConditionType = (ApplicationConditionType)applicationCondition[0];
            //        //info.mApplicationConditionValue = applicationCondition[1];
            //    }
            //}
            info.mOpeningRemarks = mTableData.GetStr(i, DataDefine.Role_Role_OpeningRemarks);
            info.mUnlockDutiesList = DataParseUtils.GetStringCompositeData(mTableData.GetStr(i, DataDefine.Role_Role_Resume));


            info.mRoleType = (E_RoleType)mTableData.GetInt(i, DataDefine.Role_Role_Profession);
            info.mRoleProfessionValue1 = mTableData.GetFloat(i, DataDefine.Role_Role_ProfessionValue1);
            info.mRoleProfessionValue2 = mTableData.GetFloat(i, DataDefine.Role_Role_ProfessionValue2);
            info.mRoleProfessionValue3 = mTableData.GetFloat(i, DataDefine.Role_Role_ProfessionValue3);
            info.mDefaultExp = mTableData.GetFloat(i, DataDefine.Role_Role_DefaultExp);


            mDicData[info.mId] = info;
            mAllRoleList.Add(info);
        }
    }

    int GetRamdomValue(string _strInfo)
    {
        string str = _strInfo;
        str = str.Remove(0, 1);
        str = str.Remove(str.Length - 1, 1);
        string[] strData = str.Split('|');
        int min = -1;
        int max = -1;
        int.TryParse(strData[0],out min);
        int.TryParse(strData[1], out max);

        return Random.Range(min, max);
    }
    public ObjRoleConfigInfo GetRoleInfoById(string _id)
    {
        if (mDicData.ContainsKey(_id))
            return mDicData[_id];
        return null;
    }

    public List<ObjRoleConfigInfo> GetAllRoleInfoByHireLev(int _hireLev)
    {
        List<ObjRoleConfigInfo> listResult = new List<ObjRoleConfigInfo>();
        if (null != mAllRoleList && mAllRoleList.Count > 0)
        {
            for (int i = 0; i < mAllRoleList.Count; i++)
            {
                if (mAllRoleList[i].mHireLev == _hireLev)
                    listResult.Add(mAllRoleList[i]);
            }
        }
        return listResult;
    }

    public List<ObjRoleConfigInfo> GetAllRoleInfo()
    {
        return mAllRoleList;
    }
}
#endregion

#region game
public class TableGameContentInfoConfig : TableData
{
    public class ObjGameContentConfigInfo
    {
        public int mId;
        public string mName;
        public string mIconName;
        public int mUnLockTime;
        public int mUnLockMoney;
        //public List<int> mLevUpMoney;

        public int mLev;
        //操作
        public float mSetting1Value;
        //策略玩法
        public float mSetting2Value;
        //收集养成
        public float mSetting3Value;
        //角色原画
        public float mSetting4Value;
        //动作特效
        public float mSetting5Value;
        //场景世界观
        public float mSetting6Value;

        public int mRandomProbability;
        public ETopiclType mType;
    }

    public readonly string sFilePath = "tGameContent";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public Dictionary<int, ObjGameContentConfigInfo> mDicData;
    public Dictionary<ETopiclType, List<ObjGameContentConfigInfo>> mDicTypeData;
    List<ObjGameContentConfigInfo> mListGameContent;
    protected override void _ParseData()
    {
        mDicData = new Dictionary<int, ObjGameContentConfigInfo>();
        mDicTypeData = new Dictionary<ETopiclType, List<ObjGameContentConfigInfo>>();

        mListGameContent = new List<ObjGameContentConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjGameContentConfigInfo info = new ObjGameContentConfigInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Game_Content_ID);
            info.mName = mTableData.GetStr(i, DataDefine.Game_Content_GameContent);
            info.mIconName = mTableData.GetStr(i, DataDefine.Game_Content_Icon);
            info.mLev = mTableData.GetInt(i, DataDefine.Game_Content_Lev);
            info.mUnLockTime = mTableData.GetInt(i, DataDefine.Game_Content_UnLockTime);


            //List<int> listMoneyValues = DataParseUtils.GetIntCompositeData());
            info.mUnLockMoney = mTableData.GetInt(i, DataDefine.Game_Content_Money);
            //info.mLevUpMoney = listMoneyValues;


            info.mSetting1Value = mTableData.GetFloat(i, DataDefine.Game_Content_Setting1);
            info.mSetting2Value = mTableData.GetFloat(i, DataDefine.Game_Content_Setting2);
            info.mSetting3Value = mTableData.GetFloat(i, DataDefine.Game_Content_Setting3);
            info.mSetting4Value = mTableData.GetFloat(i, DataDefine.Game_Content_Setting4);
            info.mSetting5Value = mTableData.GetFloat(i, DataDefine.Game_Content_Setting5);
            info.mSetting6Value = mTableData.GetFloat(i, DataDefine.Game_Content_Setting6);


            info.mRandomProbability = mTableData.GetInt(i, DataDefine.Game_Content_RandomProbability);
            info.mType = (ETopiclType)mTableData.GetInt(i, DataDefine.Game_Content_Type);

            if (!mDicTypeData.ContainsKey(info.mType))
                mDicTypeData[info.mType] = new List<ObjGameContentConfigInfo>();
            mDicTypeData[info.mType].Add(info);

            mDicData[info.mId] = info;
            mListGameContent.Add(info);
        }
    }

    public List<ObjGameContentConfigInfo> GetAllGameContent()
    {
        return mListGameContent;
    }
    public ObjGameContentConfigInfo GetGameContentInfoById(int _id)
    {
        if (mDicData.ContainsKey(_id))
            return mDicData[_id];
        return null;
    }

    public List<ObjGameContentConfigInfo> GetGameContentConfigInfoByType(ETopiclType _type)
    {
        if (null != mDicTypeData && mDicTypeData.ContainsKey(_type))
            return mDicTypeData[_type];

        return null;
    }
}


#endregion

#region roleAction
public class TableRoleItemAction : TableData
{
    public class ObjRoleItemActionInfo
    {
        public int mId;
        public string mName;
        //public int mPrice;
        public int mTime;
        public float mHunger;
        public float mStrength;
        public float mRecreation;
        public float mLoyal;
        public EInteractionSpecEffectType mSpeceffectType;
        public float mSpeceffectValue;
    }

    public readonly string sFilePath = "tItemActions";
    protected override string GetPath()
    {
        return sFilePath;
    }

    public Dictionary<int, ObjRoleItemActionInfo> mDicData;
 
    protected override void _ParseData()
    {
        mDicData = new Dictionary<int, ObjRoleItemActionInfo>();
      
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjRoleItemActionInfo info = new ObjRoleItemActionInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Items_Actions_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Items_Actions_Name);
            //info.mPrice = mTableData.GetInt(i, DataDefine.Items_Actions_Price);
            info.mTime = mTableData.GetInt(i, DataDefine.Items_Actions_Time);
            info.mHunger = mTableData.GetFloat(i, DataDefine.Items_Actions_Hunger);
            info.mStrength = mTableData.GetFloat(i, DataDefine.Items_Actions_Strength);
            info.mRecreation = mTableData.GetFloat(i, DataDefine.Items_Actions_Recreation);
            info.mLoyal = mTableData.GetFloat(i, DataDefine.Items_Actions_Loyal);

            //string dataStr = mTableData.GetStr(i, DataDefine.Items_Actions_SpecEffect);
            //if (dataStr != "-")
            //{
            //    //Debug.LogError("---------dataStr------:" + dataStr);
            //    List<float> listSpecData = DataParseUtils.GetFloatCompositeData(dataStr);
            //    if (null != listSpecData && listSpecData.Count > 0)
            //    {
            //        info.mSpeceffectType = (EInteractionSpecEffectType)listSpecData[0];
            //        info.mSpeceffectValue = (listSpecData[1]);
            //    }
            //}           
            mDicData[info.mId] = info;        
        }
    }

    public ObjRoleItemActionInfo GetActionInfoById(int _id)
    {
        if (mDicData.ContainsKey(_id))
            return mDicData[_id];
        return null;
    }
}
#endregion

//#region BossStory
//public class TableBossStory : TableData
//{
//    public class ObjBossStoryInfo
//    {
//        public int mId;
//        public string mRoleId;
//        public EBossStoryConditionType mConditionType;
//        public string[] mContentKeys;
//    }
//    public readonly string sFilePath = "tBossStory";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    public Dictionary<EBossStoryConditionType, ObjBossStoryInfo> mDicData;
//    List<ObjBossStoryInfo> mDataList;
//    protected override void _ParseData()
//    {
//        mDicData = new Dictionary<EBossStoryConditionType, ObjBossStoryInfo>();
//        mDataList = new List<ObjBossStoryInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjBossStoryInfo info = new ObjBossStoryInfo();
//            info.mId = mTableData.GetInt(i, DataDefine.Story_BossStory_Id);
//            info.mRoleId = mTableData.GetStr(i, DataDefine.Story_BossStory_RoleId);
//            info.mConditionType = (EBossStoryConditionType)mTableData.GetInt(i, DataDefine.Story_BossStory_ConditionType);
//            info.mContentKeys = mTableData.GetStr(i, DataDefine.Story_BossStory_ContentKey).Split('|');

//            mDicData[info.mConditionType] = info;
//            mDataList.Add(info);
//        }
//    }

//    public ObjBossStoryInfo GetBossStoryInfoByRoleIdAndCondition(string _roleId, EBossStoryConditionType _conditionType)
//    {
//        List<ObjBossStoryInfo> mList = new List<ObjBossStoryInfo>();
//        for (int i = 0; i < mDataList.Count; i++)
//        {
//            if (mDataList[i].mRoleId == _roleId || mDataList[i].mRoleId == "0")
//                mList.Add(mDataList[i]);
//        }
//        for (int m = 0; m < mList.Count; m++)
//        {
//            if (_conditionType == mList[m].mConditionType)
//                return mList[m];
//        }
//        return null;
//    }
//}
//#endregion

#region boss
public class TableBossInfo : TableData
{
    public class ObjBossInfo
    {
        public string mId;
        public string mName;
        public int mAge;
        public string mAvatar;
        public string mObjname;
        public string mDesc;

        //public int mGameDesign;
        //public int mTechnology;
        //public int mArt;


        //public float mHungerAttenuation;
        public float mStrengthAttenuation;
        public float mRecreationAttenuation;
        //public float mSocialContactAttenuation;

    }
    public readonly string sFilePath = "tRoleBoss";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public Dictionary<string, ObjBossInfo> mDicData;
    protected override void _ParseData()
    {
        mDicData = new Dictionary<string, ObjBossInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjBossInfo info = new ObjBossInfo();
            info.mId = mTableData.GetStr(i, DataDefine.Role_Boss_id);
            info.mAge = mTableData.GetInt(i, DataDefine.Role_Boss_Age);
            info.mName = mTableData.GetStr(i, DataDefine.Role_Boss_Name);
            info.mAvatar = mTableData.GetStr(i, DataDefine.Role_Boss_Avatar);
            info.mObjname = mTableData.GetStr(i, DataDefine.Role_Boss_Objname);
            info.mDesc = mTableData.GetStr(i, DataDefine.Role_Boss_Desc);

            //info.mGameDesign = mTableData.GetInt(i, DataDefine.Role_Boss_Gameplay);
            //info.mTechnology = mTableData.GetInt(i, DataDefine.Role_Boss_Tech);
            //info.mArt = mTableData.GetInt(i, DataDefine.Role_Boss_Art);

            //info.mHungerAttenuation = mTableData.GetFloat(i, DataDefine.Role_Boss_HungerAttenuation);
            info.mStrengthAttenuation = mTableData.GetFloat(i, DataDefine.Role_Boss_StrengthAttenuation);
            info.mRecreationAttenuation = mTableData.GetFloat(i, DataDefine.Role_Boss_RecreationAttenuation);
            //info.mSocialContactAttenuation = mTableData.GetFloat(i, DataDefine.Role_Boss_SocialContactAttenuation);

            mDicData[info.mId] = info;
        }
    }

    public ObjBossInfo GetBossById(string _id)
    {
        if (null != mDicData && mDicData.ContainsKey(_id))
            return mDicData[_id];
        return null;
    }

    int GetRamdomValue(string _strInfo)
    {
        string str = _strInfo;
        str = str.Remove(0, 1);
        str = str.Remove(str.Length - 1, 1);
        string[] strData = str.Split('|');
        int min = -1;
        int max = -1;
        int.TryParse(strData[0], out min);
        int.TryParse(strData[1], out max);

        return Random.Range(min, max);
    }
}
#endregion

//#region EmployeeStory
//public class TableEmployeeStoryInfo : TableData
//{
//    public class ObjEmployeeStoryInfo
//    {
//        public int mId;
//        public string mRoleId;
//        public string[] mContentKeys;

//        public EEmployeeStoryConditionType mConditionType;
//        public int mConditionValue;
//        public EmployeeStoryEffectType mEffectType;
//        public int mEffectTypeValue;
//    }
//    public readonly string sFilePath = "tEmployeeStory";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    List<ObjEmployeeStoryInfo> mDataList;
//    protected override void _ParseData()
//    {
//        mDataList = new List<ObjEmployeeStoryInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjEmployeeStoryInfo info = new ObjEmployeeStoryInfo();
//            info.mId = mTableData.GetInt(i, DataDefine.Story_EmployeeStory_Id);
//            info.mRoleId = mTableData.GetStr(i, DataDefine.Story_EmployeeStory_RoleId);
//            info.mContentKeys = mTableData.GetStr(i, DataDefine.Story_EmployeeStory_ContentKey).Split('|');
//            info.mConditionType = (EEmployeeStoryConditionType)mTableData.GetInt(i, DataDefine.Story_EmployeeStory_ConditionType);
//            info.mConditionValue = mTableData.GetInt(i, DataDefine.Story_EmployeeStory_ConditionValue);
//            info.mEffectType = (EmployeeStoryEffectType)mTableData.GetInt(i, DataDefine.Story_EmployeeStory_EffectType);
//            info.mEffectTypeValue = mTableData.GetInt(i, DataDefine.Story_EmployeeStory_EffectValue);

//            mDataList.Add(info);
//        }
//    }

//    public ObjEmployeeStoryInfo GetEmployeeStoryInfoByRoleIdAndCondition(string _roleId, EEmployeeStoryConditionType _conditionType)
//    {
//        List<ObjEmployeeStoryInfo> mList = new List<ObjEmployeeStoryInfo>();
//        for (int i = 0; i < mDataList.Count; i++)
//        {
//            if (mDataList[i].mRoleId == _roleId || mDataList[i].mRoleId == "0")
//                mList.Add(mDataList[i]);
//        }
//        for (int m = 0; m < mList.Count; m++)
//        {
//            if (_conditionType == mList[m].mConditionType)
//                return mList[m];
//        }
//        return null;
//    }
//}
//#endregion

#region worldmap
public class TableWorldMapInfo : TableData
{
    //public class ObjWorldMapSpreadTypeValue
    //{
    //    public ESpreadType mType;
    //    public float mValue;
    //}
    //public class ObjWorldMapSpreadGameTypeValue
    //{
    //    public int mGameType;
    //    public float mValue;
    //}
    public class ObjWorldMapInfo
    {
        public EWorldSubregion mId;
        public string mName;
        public string mIconName;
        public string mDesc;
        public int mPlayerNum;
        public float mProportion;
        public Dictionary<int, float> mDicGameType;
        public float mPopulationParamValue;
        public float mArpuValue;
        public Dictionary<ESpreadType, float> mDicSpreadType;
        public Dictionary<ESpreadType, float> mDicSpreadParam;
        //public Dictionary<ESettingId, int> mDicReleaseCondition;
        public ESettingId mReleaseConditionType;
        public int mReleaseConditionValue;
        //public List<int> mPlatFormPreference;

    }
    Dictionary<EWorldSubregion, ObjWorldMapInfo> mDicData;
    List<ObjWorldMapInfo> mListAllWorldMapInfo;
    public readonly string sFilePath = "tWorldMap";
    protected override string GetPath()
    {
        return sFilePath;
    }

    protected override void _ParseData()
    {
        mDicData = new Dictionary<EWorldSubregion, ObjWorldMapInfo>();
        mListAllWorldMapInfo = new List<ObjWorldMapInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjWorldMapInfo info = new ObjWorldMapInfo();
            info.mId = (EWorldSubregion)mTableData.GetInt(i, DataDefine.WorldMap_WorldMap_Id);
            info.mName = mTableData.GetStr(i, DataDefine.WorldMap_WorldMap_Name);
            info.mIconName = mTableData.GetStr(i, DataDefine.WorldMap_WorldMap_Icon);

            info.mDesc = mTableData.GetStr(i, DataDefine.WorldMap_WorldMap_Desc);
            info.mPlayerNum = mTableData.GetInt(i, DataDefine.WorldMap_WorldMap_PlayerNum);
            info.mProportion = mTableData.GetFloat(i, DataDefine.WorldMap_WorldMap_Proportion);

            string[] gameTypeData = mTableData.GetStr(i, DataDefine.WorldMap_WorldMap_GameType).Split('|');
            info.mDicGameType = new Dictionary<int, float>();
            for (int m = 0; m < gameTypeData.Length; m++)
            {
                string mTempStr = gameTypeData[m].Remove(gameTypeData[m].Length - 1, 1);
                mTempStr = mTempStr.Remove(0, 1);
                string[] dataStr = mTempStr.Split(':');
                info.mDicGameType[int.Parse(dataStr[0])] = float.Parse(dataStr[1]);
            }

            //info.mPopulationParamValue = mTableData.GetFloat(i, DataDefine.WorldMap_WorldMap_PopulationParam);
            //info.mArpuValue = mTableData.GetFloat(i, DataDefine.WorldMap_WorldMap_ArpuValue);

            info.mDicSpreadType = new Dictionary<ESpreadType, float>();
            string[] spreadTypeStrData = mTableData.GetStr(i, DataDefine.WorldMap_WorldMap_SpreadParam).Split('|');
            for (int n = 0; n < spreadTypeStrData.Length; n++)
            {
                string mTempStr = spreadTypeStrData[n].Remove(spreadTypeStrData[n].Length - 1,1);
                mTempStr = mTempStr.Remove(0,1);
             
                string[] dataStr = mTempStr.Split(':');
                info.mDicSpreadType[(ESpreadType)int.Parse(dataStr[0])] = float.Parse(dataStr[1]);

            }

            info.mDicSpreadParam = new Dictionary<ESpreadType, float>();
            string[] spreadParamStrData = mTableData.GetStr(i, DataDefine.WorldMap_WorldMap_SpreadParam).Split('|');
            for (int n = 0; n < spreadParamStrData.Length; n++)
            {
                string mTempStr = spreadParamStrData[n].Remove(spreadParamStrData[n].Length - 1, 1);
                mTempStr = mTempStr.Remove(0, 1);

                string[] dataStr = mTempStr.Split(':');
                info.mDicSpreadParam[(ESpreadType)int.Parse(dataStr[0])] = float.Parse(dataStr[1]);
            }

            string releaseConditionStr = mTableData.GetStr(i, DataDefine.WorldMap_WorldMap_ReleaseCondition);
            if (!string.IsNullOrEmpty(releaseConditionStr) && releaseConditionStr != "-")
            {
                string[] releaseCondition = releaseConditionStr.Split('|');
                int settingType = int.Parse(releaseCondition[0]);

                info.mReleaseConditionType = (ESettingId)settingType;
                info.mReleaseConditionValue = int.Parse(releaseCondition[1]);
            }

            //info.mPlatFormPreference = new List<int>();
            //string[] strPlatFormPreference = mTableData.GetStr(i, DataDefine.WorldMap_WorldMap_PlatFormPreference).Split('|');
            //for (int x = 0; x < strPlatFormPreference.Length; x++)
            //{
            //    info.mPlatFormPreference.Add(int.Parse(strPlatFormPreference[x]));
            //}
            mDicData[info.mId] = info;
            mListAllWorldMapInfo.Add(info);
        }
    }

    public ObjWorldMapInfo GetWorldMapInfoById(EWorldSubregion _id)
    {
        if (null != mDicData && mDicData.ContainsKey(_id))        
            return mDicData[_id];

        return null;
    }


    public List<ObjWorldMapInfo> GetAllWorldMapInfo()
    {
        return mListAllWorldMapInfo;
    }

}
#endregion

#region SpreadTypeInfo
public class TableSpreadTypeInfo : TableData
{
    public class ObjSpreadTypeInfo
    {
        public ESpreadType mTypeId;
        public string mName;
        public int mPrice;
        public float mIntensity;
        public string mIconName;
    }

    public readonly string sFilePath = "tSpreadType";
    Dictionary<ESpreadType, ObjSpreadTypeInfo> mDicData;

    List<ObjSpreadTypeInfo> mAllInfo;
    protected override string GetPath()
    {
        return sFilePath;
    }

    protected override void _ParseData()
    {
        mAllInfo = new List<ObjSpreadTypeInfo>();
        mDicData = new Dictionary<ESpreadType, ObjSpreadTypeInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjSpreadTypeInfo info = new ObjSpreadTypeInfo();
            info.mTypeId = (ESpreadType)mTableData.GetInt(i, DataDefine.WorldMap_SpreadType_Id);
            info.mName = mTableData.GetStr(i, DataDefine.WorldMap_SpreadType_Name);
            info.mPrice = mTableData.GetInt(i, DataDefine.WorldMap_SpreadType_Price);
            info.mIntensity = mTableData.GetFloat(i, DataDefine.WorldMap_SpreadType_SettingType);
            info.mIconName = mTableData.GetStr(i, DataDefine.WorldMap_SpreadType_Icon);
            mDicData[info.mTypeId] = info;
            mAllInfo.Add(info);
        }
    }

    public ObjSpreadTypeInfo GetpreadTypeInfoById(ESpreadType _id)
    {
        if (null != mDicData && mDicData.ContainsKey(_id))
            return mDicData[_id];

        return null;
    }

    public List<ObjSpreadTypeInfo> GetAllSpreadType()
    {
        return mAllInfo;
    }
}
#endregion

#region Fans

public class TableFansInfo : TableData
{
    public class ObjFansInfo
    {
        public int mLev;
        public int mExp;
        public int mIntensity;
        public int mIntensityHalo;
    }

    public readonly string sFilePath = "tFans";
    protected override string GetPath()
    {
        return sFilePath;
    }
    Dictionary<int, ObjFansInfo> mDicData;
    protected override void _ParseData()
    {
        mDicData = new Dictionary<int, ObjFansInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjFansInfo info = new ObjFansInfo();
            info.mLev = mTableData.GetInt(i, DataDefine.WorldMap_Fans_Lev);
            info.mExp = mTableData.GetInt(i, DataDefine.WorldMap_Fans_Exp);
            info.mIntensity = mTableData.GetInt(i, DataDefine.WorldMap_Fans_Intensity);
            info.mIntensityHalo = mTableData.GetInt(i, DataDefine.WorldMap_Fans_IntensityHalo);

            mDicData[info.mLev] = info;
        }
    }

    public ObjFansInfo GetFansInfoByLev(int _lev)
    {
        if (null != mDicData && mDicData.ContainsKey(_lev))
            return mDicData[_lev];

        return null;
    }
}
#endregion

//#region RoleGoap

//public class TableEmployeeGoap : TableData
//{
//    public class ObjRoleGoapInfo
//    {
//        public int mID;
//        public float mCommunicationIncrement;   
//        public float mThirstyIncrement;   
//        public float mLearningDesireIncrement;    
       
//    }
//    public readonly string sFilePath = "tGoap";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    Dictionary<int, ObjRoleGoapInfo> mDicData;
//    protected override void _ParseData()
//    {
//        mDicData = new Dictionary<int, ObjRoleGoapInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjRoleGoapInfo info = new ObjRoleGoapInfo();
//            info.mID = mTableData.GetInt(i, DataDefine.Role_Goap_ID);
//            info.mCommunicationIncrement = mTableData.GetFloat(i, DataDefine.Role_Goap_CommunicationIncrement);         
//            info.mThirstyIncrement = mTableData.GetFloat(i, DataDefine.Role_Goap_ThirstyIncrement);        
//            info.mLearningDesireIncrement = mTableData.GetFloat(i, DataDefine.Role_Goap_LearningDesireIncrement);         
            

//            mDicData[info.mID] = info;
//        }
//    }


//    public ObjRoleGoapInfo GetRoleGoapById(int _id)
//    {
//        if (null != mDicData && mDicData.ContainsKey(_id))
//            return mDicData[_id];
//        return null;
//    }
//}
//#endregion

//#region EmployeeSalary
//public class TableEmployeeSalary : TableData
//{
//    public class ObjEmployeeSalaryInfo
//    {
//        public int mAbility;
//        public int mSalary;
//    }
//    public readonly string sFilePath = "tSalary";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }

//    Dictionary<int, int> mDicData;
//    protected override void _ParseData()
//    {
//        mDicData = new Dictionary<int, int>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjEmployeeSalaryInfo info = new ObjEmployeeSalaryInfo();
         
//            info.mAbility = mTableData.GetInt(i, DataDefine.Role_Salary_Ability);
//            info.mSalary = Mathf.FloorToInt(mTableData.GetFloat(i, DataDefine.Role_Salary_Salary));

            
//            mDicData[info.mAbility] = info.mSalary;
//        }
//    }

//    public int GetSalaryByAbility( int _ability)
//    {
//        if(mDicData.ContainsKey(_ability))
//            return mDicData[_ability];
//        return 0;
//    }
//}

//#endregion

//#region eventBuff

//public class TableEventBuff : TableData
//{
//    public class ObjEventBuffInfo
//    {
//        public int mId;
//        public string mName;
//        public float mLearnAbility;
//        public float mWorkEfficiency;
//        public float mBrightSpotOutput;
//        public float mPhysicalExertion;
//        public string mIconName;      
//    }

//    public readonly string sFilePath = "tEventBuff";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    Dictionary<int, ObjEventBuffInfo> mDicData;
//    protected override void _ParseData()
//    {
//        mDicData = new Dictionary<int, ObjEventBuffInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjEventBuffInfo info = new ObjEventBuffInfo();
//            info.mId = mTableData.GetInt(i, DataDefine.Event_Buff_id);
//            info.mName = mTableData.GetStr(i, DataDefine.Event_Buff_Name);
//            info.mLearnAbility = mTableData.GetFloat(i, DataDefine.Event_Buff_LearnAbility);
//            info.mWorkEfficiency = mTableData.GetFloat(i, DataDefine.Event_Buff_WorkEfficiency);
//            info.mBrightSpotOutput = mTableData.GetFloat(i, DataDefine.Event_Buff_BrightSpotOutput);
//            info.mPhysicalExertion = mTableData.GetFloat(i, DataDefine.Event_Buff_PhysicalExertion);

//            mDicData[info.mId] = info;
//        }
//    }

//    public ObjEventBuffInfo GetBuffInfoById(int _id)
//    {
//        if (mDicData.ContainsKey(_id))
//            return mDicData[_id];
//        return null;
//    }
//}

//#endregion


//#region spec event
//public class TableSpecEvent : TableData
//{
//    public class ObjEpecEventInfoConfig
//    {
//        public int mId;
//        public ESpecEventTriggerType mSpecEventTriggerType;
//        public ETriggerValueType mTriggerCounterType;
//        public List<int> mListTriggerValue;
//        public ESpecEventRoleType mRoleType;
//        public List<int> mListDreamValueRange;
//        public List<int> mListMoneyValueRange;
//        public int mProbability;
//        public string mName;
//        public string mDesc;
//        public string mOpAName;
//        public string mOpAFeedbackDesc;
//        public EEvtEffectType mOpAFeedbackValueType;
//        public int mOpAFeedbackValue;
//        public List<int> mOpADreamValueRange;
//        public List<int> mOpADreamValueEmotionalOutcome;
//        public List<int> mOpAMoneyValueRange;
//        public List<int> mOpAMoneyValueEmotionalOutcome;
//        public int mOpABuffTime;
//        public List<EEventType> mOpAListTriggerEventType;
//        public List<int> mOpAListTriggerEventId;

//        public string mOpBName;
//        public string mOpBFeedbackDesc;
//        public EEvtEffectType mOpBFeedbackValueType;
//        public int mOpBFeedbackValue;
//        public List<int> mOpBDreamValueRange;
//        public List<int> mOpBDreamValueEmotionalOutcome;
//        public List<int> mOpBMoneyValueRange;
//        public List<int> mOpBMoneyValueEmotionalOutcome;
//        public int mOpBBuffTime;
//        public List<EEventType> mOpBListTriggerEventType;
//        public List<int> mOpBListTriggerEventId;
//    }

//    public Dictionary<int, ObjEpecEventInfoConfig> mDicData;
//    public List<ObjEpecEventInfoConfig> mAllItemsData;

//    public readonly string sFilePath = "tSpecEvent";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }

//    protected override void _ParseData()
//    {
//        mDicData = new Dictionary<int, ObjEpecEventInfoConfig>();
//        mAllItemsData = new List<ObjEpecEventInfoConfig>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjEpecEventInfoConfig info = new ObjEpecEventInfoConfig();
//            info.mId = mTableData.GetInt(i, DataDefine.Event_SpecEvent_id);
//            info.mSpecEventTriggerType = (ESpecEventTriggerType)mTableData.GetInt(i, DataDefine.Event_SpecEvent_TriggerType);
//            info.mListTriggerValue = new List<int>();


//            string triggerCounterDataStr = mTableData.GetStr(i, DataDefine.Event_CommonEvent_TriggerCounter);
//            if (triggerCounterDataStr.IndexOf("[") > -1)//[10|30|50|70]
//            {
//                info.mTriggerCounterType = ETriggerValueType.eCoalition;

//                string mTemptemptriggerCounterDataStr = triggerCounterDataStr.Remove(triggerCounterDataStr.Length - 1, 1);
//                mTemptemptriggerCounterDataStr = mTemptemptriggerCounterDataStr.Remove(0, 1);
//                if (mTemptemptriggerCounterDataStr.IndexOf('|') > -1)
//                {
//                    string[] temptriggerCounterDataStr = mTemptemptriggerCounterDataStr.Split('|');
//                    for (int z = 0; z < temptriggerCounterDataStr.Length; z++)
//                    {
//                        info.mListTriggerValue.Add(int.Parse(temptriggerCounterDataStr[z]));
//                    }
//                }
//                else
//                    info.mListTriggerValue.Add(int.Parse(mTemptemptriggerCounterDataStr));
//            }
//            else if (triggerCounterDataStr.IndexOf("{") > -1)//{13}
//            {
//                info.mTriggerCounterType = ETriggerValueType.eMultiple;
//                string mTempStr = triggerCounterDataStr.Remove(triggerCounterDataStr.Length - 1, 1);
//                mTempStr = mTempStr.Remove(0, 1);
//                info.mListTriggerValue.Add(int.Parse(mTempStr));
//            }

//            //mRoleType
//            info.mRoleType = (ESpecEventRoleType)mTableData.GetInt(i, DataDefine.Event_SpecEvent_RoleType);
//            string mListDreamValueRangeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_DreamValueRange);
//            info.mListDreamValueRange = EventParseTools.GetIntDataArr(mListDreamValueRangeStr);
//            string mListMoneyValueRangeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_MoneyValueRange);
//            info.mListMoneyValueRange = EventParseTools.GetIntDataArr(mListMoneyValueRangeStr);

//            info.mProbability = mTableData.GetInt(i, DataDefine.Event_SpecEvent_Probability);
//            info.mName = mTableData.GetStr(i, DataDefine.Event_SpecEvent_Name);
//            info.mDesc = mTableData.GetStr(i, DataDefine.Event_SpecEvent_Desc);

//            //opA
//            info.mOpAName = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpAName);
//            info.mOpAFeedbackDesc = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpAFeedbackDesc);
//            info.mOpAFeedbackValueType = (EEvtEffectType)mTableData.GetInt(i, DataDefine.Event_SpecEvent_OpAValueType);
//            info.mOpAFeedbackValue = mTableData.GetInt(i, DataDefine.Event_SpecEvent_OpAFeedbackValue);

//            string mOpADreamValueRangeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpADreamValueRange);
//            info.mOpADreamValueRange = EventParseTools.GetIntDataArr(mOpADreamValueRangeStr);
//            string mListDreamValueEmotionalOutcomeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpADreamValueEmotionalOutcome);
//            info.mOpADreamValueEmotionalOutcome = EventParseTools.GetIntDataArr(mListDreamValueEmotionalOutcomeStr);

//            string mOpAMoneyValueRangeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpAMoneyValueRange);
//            info.mOpAMoneyValueRange = EventParseTools.GetIntDataArr(mOpAMoneyValueRangeStr);
//            string mOpAListMoneyValueEmotionalOutcomeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpAMoneyValueEmotionalOutcome);
//            info.mOpAMoneyValueEmotionalOutcome = EventParseTools.GetIntDataArr(mOpAListMoneyValueEmotionalOutcomeStr);
//            info.mOpABuffTime = mTableData.GetInt(i, DataDefine.Event_SpecEvent_OpABuffTime);
//            string opAtriggerEventStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpATriggerEventId);
//            info.mOpAListTriggerEventType = new List<EEventType>();
//            info.mOpAListTriggerEventId = new List<int>();
//            EventParseTools.SettriggerEventInfo(opAtriggerEventStr, info.mOpAListTriggerEventType, info.mOpAListTriggerEventId);


//            //opB
//            info.mOpBName = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpBName);
//            info.mOpBFeedbackDesc = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpBFeedbackDesc);
//            //Debug.LogError("---- info.mId----:" + info.mId);
//            //Debug.LogError("---- info.mOpBFeedbackDesc----:" + info.mOpBFeedbackDesc);
//            info.mOpBFeedbackValueType = (EEvtEffectType)mTableData.GetInt(i, DataDefine.Event_SpecEvent_OpBValueType);
//            info.mOpBFeedbackValue = mTableData.GetInt(i, DataDefine.Event_SpecEvent_OpBFeedbackValue);

//            string mOpBDreamValueRangeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpBDreamValueRange);
//            info.mOpBDreamValueRange = EventParseTools.GetIntDataArr(mOpBDreamValueRangeStr);
//            string mOpBListDreamValueEmotionalOutcomeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpBDreamValueEmotionalOutcome);
//            info.mOpBDreamValueEmotionalOutcome = EventParseTools.GetIntDataArr(mOpBListDreamValueEmotionalOutcomeStr);

//            string mOpBMoneyValueRangeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpBMoneyValueRange);
//            info.mOpBMoneyValueRange = EventParseTools.GetIntDataArr(mOpBMoneyValueRangeStr);
//            string mOpBListMoneyValueEmotionalOutcomeStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpBMoneyValueEmotionalOutcome);
//            info.mOpBMoneyValueEmotionalOutcome = EventParseTools.GetIntDataArr(mOpBListMoneyValueEmotionalOutcomeStr);
//            info.mOpBBuffTime = mTableData.GetInt(i, DataDefine.Event_SpecEvent_OpBBuffTime);
//            string opBtriggerEventStr = mTableData.GetStr(i, DataDefine.Event_SpecEvent_OpBTriggerEventId);
//            info.mOpBListTriggerEventType = new List<EEventType>();
//            info.mOpBListTriggerEventId = new List<int>();
//            EventParseTools.SettriggerEventInfo(opBtriggerEventStr, info.mOpBListTriggerEventType, info.mOpBListTriggerEventId);


//            mDicData[info.mId] = info;
//            mAllItemsData.Add(info);
//        }
//    }

//    public ObjEpecEventInfoConfig GetSpecInfoById(int _id)
//    {
//        if (null != mDicData && mDicData.ContainsKey(_id))
//            return mDicData[_id];

//        return null;
//    }


//    public List<ObjEpecEventInfoConfig> GetSpecEventInfosByTriggerTypeAndCounter(ESpecEventTriggerType _triggerType, int _value)
//    {
//        List<ObjEpecEventInfoConfig> result = new List<ObjEpecEventInfoConfig>();
//        for (int i = 0; i < mAllItemsData.Count; i++)
//        {
//            ObjEpecEventInfoConfig info = mAllItemsData[i];
//            if (info.mSpecEventTriggerType == _triggerType)
//            {
//                //Debug.LogError("********_triggerType******:" + _triggerType);
//                switch (info.mTriggerCounterType)
//                {
//                    case ETriggerValueType.eMultiple:
//                        if (_value % info.mListTriggerValue[0] == 0)
//                            result.Add(info);
//                        break;

//                    case ETriggerValueType.eCoalition:
//                        if (info.mListTriggerValue.IndexOf(_value) > -1)
//                            result.Add(info);
//                        break;
//                }
//            }
//        }
//        return result;
//    }
//}
//#endregion



#region table CoreGameplay

public class TableCoreGameplay : TableData
{
    public class ObjCoreGameplayConfig
    {
        public int mId;      
        public string mName;
        public string mIconName;  
    }

    public readonly string sFilePath = "tCoreGameplay";
    protected override string GetPath()
    {
        return sFilePath;
    }

    Dictionary<int, List<ObjCoreGameplayConfig>> mDataListDic;
    Dictionary<int, ObjCoreGameplayConfig> mDataDic;
    List<ObjCoreGameplayConfig> mListAllData;
    protected override void _ParseData()
    {
        mDataListDic = new Dictionary<int, List<ObjCoreGameplayConfig>>();
        mDataDic = new Dictionary<int, ObjCoreGameplayConfig>();
        mListAllData = new List<ObjCoreGameplayConfig>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjCoreGameplayConfig info = new ObjCoreGameplayConfig();
            info.mId = mTableData.GetInt(i, DataDefine.Game_CoreGameplay_Id);          
            info.mName = mTableData.GetStr(i, DataDefine.Game_CoreGameplay_Name);
            info.mIconName = mTableData.GetStr(i, DataDefine.Game_CoreGameplay_IconName);            

            mDataDic[info.mId] = info;
            mListAllData.Add(info);
        }
    }
    public ObjCoreGameplayConfig GetCoreGameplayConfigById(int _id)
    {
        if (null != mDataDic && mDataDic.ContainsKey(_id))
            return mDataDic[_id];

        return null;
    }

    public List<ObjCoreGameplayConfig> GetCoreGameplayConfigListByType(int _type)
    {
        List<ObjCoreGameplayConfig> listResult = new List<ObjCoreGameplayConfig>();
        if (null != mDataListDic && mDataListDic.ContainsKey(_type))
        {
            List<ObjCoreGameplayConfig> listData = mDataListDic[_type];
            if (null != listData && listData.Count > 0)
            {
                for (int i = 0; i < listData.Count; i++)
                {                   
                    listResult.Add(listData[i]);
                }
            }
        }

        return listResult;
    }

    public List<ObjCoreGameplayConfig> GetAllData()
    {
        return mListAllData;
    }
}

#endregion

#region layout rooms
public class TableRooms : TableData
{
    public class ObjRoomConfigInfo
    {
        public int mId;
        public ERoomType mRoomType;
        public int mLev;
        public Vector3 mDefaultPos;
        public bool mReposEnable;
        public Vector3 mExtendPos;
        public string mObjName;
        public int mWidth;
        public int mHeight;

        public string mName;
        public string mIconName;
        public string mDesc;
        public int mActionPoint;
        public int mMoney;
        public int mAdminPoint;
        public bool mIsActive;

        //fun
        public ERoomFunParamType mFunParamType;
        public float mFunValue;
    }
    public readonly string sFilePath = "tRoom";
    protected override string GetPath()
    {
        return sFilePath;
    }

    Dictionary<int, ObjRoomConfigInfo> mDataDic;
    Dictionary<string, ObjRoomConfigInfo> mInfoDic;
    protected override void _ParseData()
    {
        mDataDic = new Dictionary<int, ObjRoomConfigInfo>();
        mInfoDic = new Dictionary<string, ObjRoomConfigInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjRoomConfigInfo info = new ObjRoomConfigInfo();
            info.mId = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_Id);
            info.mRoomType = (ERoomType)mTableData.GetInt(i, DataDefine.OfficeLayout_Room_Type);
            info.mLev = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_Lev);
            info.mObjName = mTableData.GetStr(i, DataDefine.OfficeLayout_Room_ObjName);
            info.mWidth = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_Width);
            info.mHeight = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_Height);

            info.mName = mTableData.GetStr(i, DataDefine.OfficeLayout_Room_Name);
            info.mIconName = mTableData.GetStr(i, DataDefine.OfficeLayout_Room_IconName);
            info.mDesc = mTableData.GetStr(i, DataDefine.OfficeLayout_Room_Desc);
            info.mActionPoint = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_ActionPoint);
            info.mMoney = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_Money);
            info.mIsActive = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_Active) == 1;
            info.mAdminPoint = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_LevUpCostPoint);
            info.mFunParamType = (ERoomFunParamType)mTableData.GetInt(i, DataDefine.OfficeLayout_Room_FunType);
            info.mFunValue = mTableData.GetFloat(i, DataDefine.OfficeLayout_Room_FunValues);


            string strpos = mTableData.GetStr(i, DataDefine.OfficeLayout_Room_LayoutPos);

            string mTempStr = strpos.Remove(strpos.Length - 1, 1);
            mTempStr = mTempStr.Remove(0, 1);
            info.mReposEnable = mTableData.GetInt(i, DataDefine.OfficeLayout_Room_ReposeEnable) == 1;

            if (!string.IsNullOrEmpty(mTempStr) && mTempStr != "-")
            {
                string[] strPosData = mTempStr.Split(',');

                int posX;
                int posY;
                int.TryParse(strPosData[0], out posX);
                int.TryParse(strPosData[1], out posY);
                info.mDefaultPos = new Vector3(posX,0.0f, posY);
                if(info.mReposEnable)
                    info.mExtendPos = new Vector3(posX + 20, 0.0f, posY);
            }
          
            mDataDic[info.mId] = info;
            string key = info.mRoomType + "_" + info.mLev;
            mInfoDic[key] = info;
        }
    }

    public ObjRoomConfigInfo GetRoomInfoById(int _id)
    {
        if (null != mDataDic && mDataDic.ContainsKey(_id))
            return mDataDic[_id];

        return null;
    }

    public ObjRoomConfigInfo GetRoomInfoByTypeAndLev(ERoomType _type,int _lev)
    {
        string key = _type + "_" + _lev;
        if (null != mInfoDic && mInfoDic.ContainsKey(key))
            return mInfoDic[key];
        return null;
    }
}
#endregion


#region HomeFurnishing
public class TableHomeFurnishingConfigInfo : TableData
{
    public class ObjHomeFurnishingConfigInfo
    {
        public int mID;
        public EHomeFurnishingType mType;
        public string mName;
      
        public string mObjName;
        public int mPrice;
        public int mRoomlevLimit;
        public List<int> mFunctionList;
        public List<int> mInteractiveList;

    }
    public readonly string sFilePath = "tHomeFurnishing";
    protected override string GetPath()
    {
        return sFilePath;
    }
    Dictionary<int, ObjHomeFurnishingConfigInfo> mDataDic;
    Dictionary<string, ObjHomeFurnishingConfigInfo> mStrDataDic;
    Dictionary<EHomeFurnishingType, List<ObjHomeFurnishingConfigInfo>> mDicListData;
    List<ObjHomeFurnishingConfigInfo> mListAllFurnishing;
    protected override void _ParseData()
    {
        mDataDic = new Dictionary<int, ObjHomeFurnishingConfigInfo>();
        mStrDataDic = new Dictionary<string, ObjHomeFurnishingConfigInfo>();
        mDicListData = new Dictionary<EHomeFurnishingType, List<ObjHomeFurnishingConfigInfo>>();
        mListAllFurnishing = new List<ObjHomeFurnishingConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjHomeFurnishingConfigInfo info = new ObjHomeFurnishingConfigInfo();
            info.mID = mTableData.GetInt(i, DataDefine.Items_HomeFurnishing_ID);
            info.mType = (EHomeFurnishingType)mTableData.GetInt(i, DataDefine.Items_HomeFurnishing_Type);
            info.mName = mTableData.GetStr(i, DataDefine.Items_HomeFurnishing_Name);
            info.mObjName = mTableData.GetStr(i, DataDefine.Items_HomeFurnishing_ObjName);
            info.mPrice = mTableData.GetInt(i, DataDefine.Items_HomeFurnishing_Price);
            info.mRoomlevLimit = mTableData.GetInt(i, DataDefine.Items_HomeFurnishing_RoomlevLimit);           

            string homeFurnishingFunctionListStr =  mTableData.GetStr(i, DataDefine.Items_HomeFurnishing_FunctionList);
            info.mFunctionList = new List<int>();
            if (!string.IsNullOrEmpty(homeFurnishingFunctionListStr) && homeFurnishingFunctionListStr != "-")
            {
                homeFurnishingFunctionListStr = homeFurnishingFunctionListStr.Remove(0,1);
                homeFurnishingFunctionListStr = homeFurnishingFunctionListStr.Remove(homeFurnishingFunctionListStr.Length - 1, 1);
                string[] dataStrArr = homeFurnishingFunctionListStr.Split('|');
                for (int m = 0; m < dataStrArr.Length; m++)
                {
                    int value = -1;
                    int.TryParse(dataStrArr[m], out value);
                    info.mFunctionList.Add(value);
                }
            }

            string homeFurnishingInteractivityListStr = mTableData.GetStr(i, DataDefine.Items_HomeFurnishing_Interactivity);
            info.mInteractiveList = new List<int>();
            if (!string.IsNullOrEmpty(homeFurnishingInteractivityListStr) && homeFurnishingInteractivityListStr != "-")
            {
                homeFurnishingInteractivityListStr = homeFurnishingInteractivityListStr.Remove(0, 1);
                homeFurnishingInteractivityListStr = homeFurnishingInteractivityListStr.Remove(homeFurnishingInteractivityListStr.Length - 1, 1);
                string[] dataStrArr = homeFurnishingInteractivityListStr.Split('|');
                for (int m = 0; m < dataStrArr.Length; m++)
                {
                    int value = -1;
                    int.TryParse(dataStrArr[m], out value);
                    info.mInteractiveList.Add(value);
                }
            }


             mStrDataDic[info.mObjName] = info;
            mDataDic[info.mID] = info;
            mListAllFurnishing.Add(info);
            if (!mDicListData.ContainsKey(info.mType))
                mDicListData[info.mType] = new List<ObjHomeFurnishingConfigInfo>();
            mDicListData[info.mType].Add(info);
        }
    }

    public ObjHomeFurnishingConfigInfo GetHomeFurnishingInfoById(int _id)
    {
        if (null != mDataDic && mDataDic.ContainsKey(_id))
            return mDataDic[_id];

        return null;
    }
    public ObjHomeFurnishingConfigInfo GetHomeFurnishingInfoByObjName(string _objName)
    {
        if (null != mStrDataDic && mStrDataDic.ContainsKey(_objName))
            return mStrDataDic[_objName];

        return null;
    }
    public List<ObjHomeFurnishingConfigInfo> GetHomeFurnishingListByType(EHomeFurnishingType _type)
    {
        if (null != mDicListData && mDicListData.ContainsKey(_type))
            return mDicListData[_type];

        return null;
    }
    public List<ObjHomeFurnishingConfigInfo> GetAllHomeFurnishing()
    {
        return mListAllFurnishing;
    }

}
#endregion

#region PlayableGames
public class TablePlayableGamesConfigInfo : TableData
{
    public class ObjPlayableGamesConfigInfo
    {
        public int mId;
        public EPlayableGamesType mType;
        public List<int> mYearSection;
        public string mName;
        public string mDesc;
        public int mPrice;
        public List<int> mCardList;
        public List<float> mCardProbabilityList;
    }

    public readonly string sFilePath = "tPlayableGames";
    public Dictionary<EPlayableGamesType, List<ObjPlayableGamesConfigInfo>> mDicTypeData;
    public Dictionary<int, ObjPlayableGamesConfigInfo> mDicData;
    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mDicTypeData = new Dictionary<EPlayableGamesType, List<ObjPlayableGamesConfigInfo>>();
        mDicData = new Dictionary<int, ObjPlayableGamesConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjPlayableGamesConfigInfo info = new ObjPlayableGamesConfigInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Items_PlayableGames_Id);
            info.mType = (EPlayableGamesType)mTableData.GetInt(i, DataDefine.Items_PlayableGames_Type);
            info.mName = mTableData.GetStr(i, DataDefine.Items_PlayableGames_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Items_PlayableGames_Desc);
            info.mPrice = mTableData.GetInt(i, DataDefine.Items_PlayableGames_Price);
            info.mCardList = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Items_PlayableGames_Card));
            if (info.mId == 1000)
                Debug.LogError("-------info.mCardList--------:" + info.mCardList.Count);

            info.mCardProbabilityList = DataParseUtils.GetFloatCompositeData(mTableData.GetStr(i, DataDefine.Items_PlayableGames_Probability));
            if (!mDicTypeData.ContainsKey(info.mType))
                mDicTypeData[info.mType] = new List<ObjPlayableGamesConfigInfo>();

            mDicTypeData[info.mType].Add(info);

            mDicData[info.mId] = info;
        }
    }

    public List<ObjPlayableGamesConfigInfo> GetListPlayableGamesByType(EPlayableGamesType _type)
    {
        if (null != mDicTypeData && mDicTypeData.ContainsKey(_type))
            return mDicTypeData[_type];

        return null;
    }
    public ObjPlayableGamesConfigInfo GetPlayableGamesInfoById(int _id)
    {
        if (null != mDicData && mDicData.ContainsKey(_id))
            return mDicData[_id];

        return null;
    }

}
#endregion

#region  Live broadcast
public class TableLiveBroadcastConfigInfo : TableData
{
    public class ObjLiveBroadcastConfigInfo
    {
        public int mId;
        public string mName;
        public string mDesc;
        public int mPrice;
        public List<int> mCardList;
        public List<float> mCardProbabilityList;
    }

    public readonly string sFilePath = "tLiveBroadcast";
    public Dictionary<int, ObjLiveBroadcastConfigInfo> mDicData;
    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mDicData = new Dictionary<int, ObjLiveBroadcastConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjLiveBroadcastConfigInfo info = new ObjLiveBroadcastConfigInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Items_LiveBroadcast_Id);
         
            info.mName = mTableData.GetStr(i, DataDefine.Items_LiveBroadcast_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Items_LiveBroadcast_Desc);
            info.mPrice = mTableData.GetInt(i, DataDefine.Items_LiveBroadcast_Price);
            info.mCardList = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Items_LiveBroadcast_Card));
            info.mCardProbabilityList = DataParseUtils.GetFloatCompositeData(mTableData.GetStr(i, DataDefine.Items_LiveBroadcast_Probability));
            mDicData[info.mId] = info;
        }
    }

    public List<ObjLiveBroadcastConfigInfo> GetAllLiveBroadcast()
    {
        List<ObjLiveBroadcastConfigInfo> result = new List<ObjLiveBroadcastConfigInfo>();
        foreach(ObjLiveBroadcastConfigInfo info in mDicData.Values)
        {
            result.Add(info);
        }
        return result;
    }

    public ObjLiveBroadcastConfigInfo GetLiveBroadcastInfoById(int _id)
    {
        if (null != mDicData && mDicData.ContainsKey(_id))
            return mDicData[_id];
        return null;
    }
}
#endregion

#region  ComicBooks
public class TableComicBooksConfigInfo : TableData
{
    public class ObjComicBooksConfigInfo
    {
        public int mId;
        public string mName;
        public string mDesc;
        public int mPrice;
        public List<int> mCardList;
        public List<float> mCardProbabilityList;
    }
    public readonly string sFilePath = "tComicBooks";
    public Dictionary<int, ObjComicBooksConfigInfo> mDicData;
    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mDicData = new Dictionary<int, ObjComicBooksConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjComicBooksConfigInfo info = new ObjComicBooksConfigInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Items_ComicBooks_Id);

            info.mName = mTableData.GetStr(i, DataDefine.Items_ComicBooks_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Items_ComicBooks_Desc);
            info.mPrice = mTableData.GetInt(i, DataDefine.Items_ComicBooks_Price);
            info.mCardList = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Items_ComicBooks_Card));
            info.mCardProbabilityList = DataParseUtils.GetFloatCompositeData(mTableData.GetStr(i, DataDefine.Items_ComicBooks_Probability));
            mDicData[info.mId] = info;
        }
    }
    public List<ObjComicBooksConfigInfo> GetAllComicBooks()
    {
        List<ObjComicBooksConfigInfo> result = new List<ObjComicBooksConfigInfo>();
        foreach (ObjComicBooksConfigInfo info in mDicData.Values)
        {
            result.Add(info);
        }
        return result;
    }

    public ObjComicBooksConfigInfo GetComicBookInfoById(int _id)
    {
        if (null != mDicData && mDicData.ContainsKey(_id))
            return mDicData[_id];
        return null;
    }

}
#endregion



#region  BoardGames
public class TableBoardGamesConfigInfo : TableData
{
    public class ObjBoardGamesConfigInfo
    {
        public int mId;
        public string mName;
        public string mDesc;
        public int mPrice;
    }
    public readonly string sFilePath = "tBoardGames";
    public Dictionary<int, ObjBoardGamesConfigInfo> mDicData;
    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mDicData = new Dictionary<int, ObjBoardGamesConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjBoardGamesConfigInfo info = new ObjBoardGamesConfigInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Items_BoardGames_Id);

            info.mName = mTableData.GetStr(i, DataDefine.Items_BoardGames_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Items_BoardGames_Desc);
            info.mPrice = mTableData.GetInt(i, DataDefine.Items_BoardGames_Price);
            mDicData[info.mId] = info;
        }
    }
    public List<ObjBoardGamesConfigInfo> GetAllBoardGames()
    {
        List<ObjBoardGamesConfigInfo> result = new List<ObjBoardGamesConfigInfo>();
        foreach (ObjBoardGamesConfigInfo info in mDicData.Values)
        {
            result.Add(info);
        }
        return result;
    }

}
#endregion

#region TakeOutFood
public class TableTakeOutFoodConfigInfo : TableData
{
    public class ObjTakeOutFoodConfigInfo
    {
        public int mId;
        public string mName;
        public string mDesc;
        public int mPrice;
        public float mTime;
        public float mHunger;
    }

    public readonly string sFilePath = "tTakeOutFood";
    public Dictionary<int, ObjTakeOutFoodConfigInfo> mDicData;
    List<ObjTakeOutFoodConfigInfo> mListAllFoodInfo;
    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mListAllFoodInfo = new List<ObjTakeOutFoodConfigInfo>();
        mDicData = new Dictionary<int, ObjTakeOutFoodConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTakeOutFoodConfigInfo info = new ObjTakeOutFoodConfigInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Items_TakeOutFood_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Items_TakeOutFood_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Items_TakeOutFood_Desc);
            info.mPrice = mTableData.GetInt(i, DataDefine.Items_TakeOutFood_Price);
            info.mTime = mTableData.GetFloat(i, DataDefine.Items_TakeOutFood_Time);
            info.mHunger = mTableData.GetFloat(i, DataDefine.Items_TakeOutFood_Hunger);

            mListAllFoodInfo.Add(info);
            mDicData[info.mId] = info;
        }
    }

    public List<ObjTakeOutFoodConfigInfo> GetAllTakeOutFoodInfo()
    {
        return mListAllFoodInfo;
    }

    public ObjTakeOutFoodConfigInfo GetTakeOutFoodConfigInfoById(int _id)
    {
        if (null != mDicData && mDicData.ContainsKey(_id))
            return mDicData[_id];
        return null;
    }
}

#endregion

#region SnacksDrink
public class TableSnacksDrinkConfigInfo : TableData
{
    public class ObjSnacksDrinkConfigInfo
    {
        public int mId;
        //1:冰箱 2：贩卖机
        public int mType;

        public string mName;
        public string mIconName;
        public string mDesc;
        public int mPrice;
        public float mTime;
        public float mHunger;
        public float mStrength;
        public float mRecreation;
        public float mSocialContact;
    }
    public readonly string sFilePath = "tSnacksDrink";
    public Dictionary<int, ObjSnacksDrinkConfigInfo> mDicData;
    List<ObjSnacksDrinkConfigInfo> mListAllFoodInfo;

    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mListAllFoodInfo = new List<ObjSnacksDrinkConfigInfo>();
        mDicData = new Dictionary<int, ObjSnacksDrinkConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjSnacksDrinkConfigInfo info = new ObjSnacksDrinkConfigInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Items_SnacksDrink_Id);
            info.mType = mTableData.GetInt(i, DataDefine.Items_SnacksDrink_Type);
            info.mIconName = mTableData.GetStr(i, DataDefine.Items_SnacksDrink_Icon);

            info.mName = mTableData.GetStr(i, DataDefine.Items_SnacksDrink_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Items_SnacksDrink_Desc);
            info.mPrice = mTableData.GetInt(i, DataDefine.Items_SnacksDrink_Price);
            info.mTime = mTableData.GetFloat(i, DataDefine.Items_SnacksDrink_Time);
            info.mHunger = mTableData.GetFloat(i, DataDefine.Items_SnacksDrink_Hunger);
            info.mStrength = mTableData.GetFloat(i, DataDefine.Items_SnacksDrink_Strength);
            info.mRecreation = mTableData.GetFloat(i, DataDefine.Items_SnacksDrink_Recreation);
            info.mSocialContact = mTableData.GetFloat(i, DataDefine.Items_SnacksDrink_SocialContact);

            mListAllFoodInfo.Add(info);
            mDicData[info.mId] = info;
        }
    }


    public List<ObjSnacksDrinkConfigInfo> GetAllSnacksDrinkInfo(int _type)
    {
        List<ObjSnacksDrinkConfigInfo> result = new List<ObjSnacksDrinkConfigInfo>();
        for (int i = 0; i < mListAllFoodInfo.Count; i++)
        {
            if (mListAllFoodInfo[i].mType == _type)
                result.Add(mListAllFoodInfo[i]);
        }
        return result;
    }

    public ObjSnacksDrinkConfigInfo GetSnacksDrinkConfigInfoById(int _id)
    {
        if (null != mDicData && mDicData.ContainsKey(_id))
            return mDicData[_id];
        return null;
    }
}
#endregion

//#region CoreplaySetting
//public class TableCoreplaySettingConfigInfo : TableData
//{
//    public class ObjCoreplaySettingConfigInfo
//    {
//        public int mId;      
//        public List<float> mListSettingValue;
//    }

//    public readonly string sFilePath = "tCoreplaySetting";
//    public Dictionary<int, List<float>> mDicData;
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    protected override void _ParseData()
//    {
//        mDicData = new Dictionary<int, List<float>>();

//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            int id = mTableData.GetInt(i, DataDefine.Combination_CoreplaySetting_CorePlayId);
//            List<float> listSettingValue = new List<float>();
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_1));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_2));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_3));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_4));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_5));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_6));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_7));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_8));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_9));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_10));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_11));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_12));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_13));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_14));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_15));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_16));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_17));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_18));
//            listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_19));
//            listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_20));
//            listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_21));
//            //listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_22));
//            listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_23));
//            listSettingValue.Add(mTableData.GetFloat(i, DataDefine.Combination_CoreplaySetting_Setting_24));

//            mDicData[id] = listSettingValue;
//        }
//    }

//    public float GetSettingValue(int _coreplayId,int _settingId)
//    {
//        float result = 0.0f;
      
//        List<float> listSettingValue = null;
//        if (null != mDicData && mDicData.ContainsKey(_coreplayId))
//            listSettingValue = mDicData[_coreplayId];
//        if (null != listSettingValue)
//        {
//            ESettingId settingId = (ESettingId)_settingId;
//            switch (settingId)
//            {
//                case ESettingId.eOperational:
//                    result = listSettingValue[0];
//                    break;
//                case ESettingId.eOriginal:
//                    result = listSettingValue[1];
//                    break;
//                case ESettingId.eStrategyPlay:
//                    result = listSettingValue[2];
//                    break;
//                case ESettingId.eCollectionCultivation:
//                    result = listSettingValue[3];
//                    break;
//                case ESettingId.ePay:
//                    result = listSettingValue[4];
//                    break;
//            }
//        }
//        return result;
//    }
//}

//#endregion



//#region EXP
//public class TableCompanyExpConfigInfo : TableData
//{
//    public class ObjCompanyExpConfigInfo
//    {
//        public int mLev;
//        public float mExpValue;
//        public List<int> mListCoreGamePlay;
//        public int mEmployeeMax;
//        public int mRoomLevLimit;
//        public bool mWorkingAreaLevUp;
//        public int mUnLockRoomId;
//    }
//    public readonly string sFilePath = "tCompanyExp";
//    public Dictionary<int, ObjCompanyExpConfigInfo> mDicData;
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    protected override void _ParseData()
//    {
//        mDicData = new Dictionary<int, ObjCompanyExpConfigInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjCompanyExpConfigInfo info = new ObjCompanyExpConfigInfo();
//            info.mLev = mTableData.GetInt(i, DataDefine.Exp_CompanyExp_Lev);
//            info.mExpValue = mTableData.GetInt(i, DataDefine.Exp_CompanyExp_ExpValue) / Constants.COMPANY_LEV_UP_DEBUG_PARAM;
            
//            info.mListCoreGamePlay = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Exp_CompanyExp_GameType));
//            info.mEmployeeMax = mTableData.GetInt(i, DataDefine.Exp_CompanyExp_EmployeeMax);
//            info.mRoomLevLimit = mTableData.GetInt(i, DataDefine.Exp_CompanyExp_RoomLevLimit);
//            info.mWorkingAreaLevUp = mTableData.GetInt(i, DataDefine.Exp_CompanyExp_WorkingAreaLevUp) == 1;          
//            info.mUnLockRoomId = mTableData.GetInt(i, DataDefine.Exp_CompanyExp_UnLockRoomId);
//            mDicData[info.mLev] = info;
//        }
//    }

//    public ObjCompanyExpConfigInfo GetCompanyExpInfoByLev(int _lev)
//    {
//        if (null != mDicData && mDicData.ContainsKey(_lev))
//            return mDicData[_lev];
//        return null;
//    }
//}
//#endregion

#region OfficeLayoutWall
public class TableOfficeLayoutWallConfigInfo : TableData
{
    public class ObjOfficeLayoutWallConfigInfo
    {
        public int mExtensionWallId;
        public int mCompanyLev;
        public string mObjName;
        public List<int> mPosInfo;
        public int mRotation;
    }

    Dictionary<int, List<ObjOfficeLayoutWallConfigInfo>> mDicWallInfo;
    public readonly string sFilePath = "tOfficeLayoutWall";
    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mDicWallInfo = new Dictionary<int, List<ObjOfficeLayoutWallConfigInfo>>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjOfficeLayoutWallConfigInfo info = new ObjOfficeLayoutWallConfigInfo();
            info.mExtensionWallId = mTableData.GetInt(i, DataDefine.OfficeLayout_OfficeLayoutWall_ExtensionWallId);
            info.mCompanyLev = mTableData.GetInt(i, DataDefine.OfficeLayout_OfficeLayoutWall_CompanyLev);
            info.mObjName = mTableData.GetStr(i, DataDefine.OfficeLayout_OfficeLayoutWall_ObjName);
            info.mPosInfo = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.OfficeLayout_OfficeLayoutWall_Pos));
            info.mRotation = mTableData.GetInt(i, DataDefine.OfficeLayout_OfficeLayoutWall_Rotation);

            if(!mDicWallInfo.ContainsKey(info.mCompanyLev))
                mDicWallInfo[info.mCompanyLev] = new List<ObjOfficeLayoutWallConfigInfo>();
            mDicWallInfo[info.mCompanyLev].Add(info);
        }
    }

    public List<ObjOfficeLayoutWallConfigInfo> GetExtendWallInfoByLev(int _lev)
    {
        if (null != mDicWallInfo && mDicWallInfo.ContainsKey(_lev))
            return mDicWallInfo[_lev];

        return null;
    }
}
#endregion

//#region Outsourcing
//public class TableOutsourcingConfigInfo : TableData
//{
//    public class ObjOutsourcingConfigInfo
//    {
//        public int mId;
//        public string mGameName;
//        //public E_RoleType mOutsourcingType;
//        //public string mDesc;
//        public string mCompanyName;
//        public int mCoreGameplayId;
//        public int mContentId;
//        public int mPrice;
//        public int mDesignScoreLimit;
//        public int mArtScoreLimit;

//        //public int mWorkload;
//        //public int mTimeLimit;
//    }
//    public readonly string sFilePath = "tOutsourcing";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    //Dictionary<E_RoleType, List<ObjOutsourcingConfigInfo>> mDicListInfo;
//    Dictionary<int, ObjOutsourcingConfigInfo> mDicInfo;
//    List<ObjOutsourcingConfigInfo> mListAllInfo;
//    protected override void _ParseData()
//    {
//        //mDicListInfo = new Dictionary<E_RoleType, List<ObjOutsourcingConfigInfo>>();
//        mListAllInfo = new List<ObjOutsourcingConfigInfo>();
//        mDicInfo = new Dictionary<int, ObjOutsourcingConfigInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjOutsourcingConfigInfo info = new ObjOutsourcingConfigInfo();
//            info.mId = mTableData.GetInt(i, DataDefine.Outsourcing_Outsourcing_Id);
//            info.mGameName = mTableData.GetStr(i, DataDefine.Outsourcing_Outsourcing_GameName);
//            //info.mDesc = mTableData.GetStr(i, DataDefine.Outsourcing_Outsourcing_Desc);
//            //info.mOutsourcingType = (E_RoleType)mTableData.GetInt(i, DataDefine.Outsourcing_Outsourcing_OutsourcingType);
//            info.mCompanyName = mTableData.GetStr(i, DataDefine.Outsourcing_Outsourcing_CompanyName);
//            info.mCoreGameplayId = mTableData.GetInt(i, DataDefine.Outsourcing_Outsourcing_CoreGameplayId);
//            info.mPrice = mTableData.GetInt(i, DataDefine.Outsourcing_Outsourcing_Price);
//            info.mContentId = mTableData.GetInt(i, DataDefine.Outsourcing_Outsourcing_GameContent);
//            //info.mScoreLimit = mTableData.GetInt(i, DataDefine.Outsourcing_Outsourcing_ScoreLimit);
//            //info.mWorkload = mTableData.GetInt(i, DataDefine.Outsourcing_Outsourcing_Workload);
//            //info.mTimeLimit = mTableData.GetInt(i, DataDefine.Outsourcing_Outsourcing_TimeLimit);

//            //if (!mDicListInfo.ContainsKey(info.mOutsourcingType))
//            //{             
//            //    mDicListInfo[info.mOutsourcingType] = new List<ObjOutsourcingConfigInfo>();
//            //    mDicListInfo[info.mOutsourcingType].Add(info);
//            //}               
//            //else
//            //    mDicListInfo[info.mOutsourcingType].Add(info);
//            mDicInfo[info.mId] = info;
//            mListAllInfo.Add(info);
//        }
//    }

//    public List<ObjOutsourcingConfigInfo> GetAllOutsourcingConfigList()
//    {
//        return mListAllInfo;
//    }
//    public ObjOutsourcingConfigInfo GetOutsourcingConfigInfoById(int _id)
//    {
//        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
//            return mDicInfo[_id];
//        return null;
//    }

//}
//#endregion

#region Interactive

public class TableInteractiveInfo : TableData
{
    public class ObjInteractiveConfigInfo
    {
        public EfurnitureInteractiveId mId;
        public string mName;
    }
    public readonly string sFilePath = "tInteractive";
    protected override string GetPath()
    {
        return sFilePath;
    }
    Dictionary<EfurnitureInteractiveId, ObjInteractiveConfigInfo> mDicInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<EfurnitureInteractiveId, ObjInteractiveConfigInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjInteractiveConfigInfo info = new ObjInteractiveConfigInfo();
            info.mId = (EfurnitureInteractiveId)mTableData.GetInt(i, DataDefine.Items_Interactive_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Items_Interactive_Content);

            mDicInfo[info.mId] = info;
        }
    }

    public ObjInteractiveConfigInfo GetInteractiveConfigInfoById(int _Id)
    {
        EfurnitureInteractiveId id = (EfurnitureInteractiveId)_Id;
        if (null != mDicInfo && mDicInfo.ContainsKey(id))
            return mDicInfo[id];
        return null;
    }
}

#endregion

//#region artworklord

//public class TableArtworklordInfo : TableData
//{
//    public class ObjTableArtworklordInfoConfigInfo
//    {
//        public int mCorePlayId;
//        public float mSetting1Param;
//        //public float mSetting20Param;
//        public float mSetting2Param;
//        //public float mSetting22Param;
//        public float mSetting3Param;
//        public float mSetting4Param;
//    }

//    public readonly string sFilePath = "tArtWorklord";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }

//    Dictionary<int, ObjTableArtworklordInfoConfigInfo> mDicInfo;
//    protected override void _ParseData()
//    {
//        mDicInfo = new Dictionary<int, ObjTableArtworklordInfoConfigInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjTableArtworklordInfoConfigInfo info = new ObjTableArtworklordInfoConfigInfo();
//            info.mCorePlayId = mTableData.GetInt(i, DataDefine.Combination_ArtWorklord_CorePlayId);
//            info.mSetting1Param = mTableData.GetFloat(i, DataDefine.Combination_ArtWorklord_Setting1);
//            //info.mSetting20Param = mTableData.GetFloat(i, DataDefine.Combination_ArtWorklord_Setting20);
//            info.mSetting2Param = mTableData.GetFloat(i, DataDefine.Combination_ArtWorklord_Setting2);
//            //info.mSetting22Param = mTableData.GetFloat(i, DataDefine.Combination_ArtWorklord_Setting22);
//            info.mSetting3Param = mTableData.GetFloat(i, DataDefine.Combination_ArtWorklord_Setting3);
//            info.mSetting4Param = mTableData.GetFloat(i, DataDefine.Combination_ArtWorklord_Setting4);

//            mDicInfo[info.mCorePlayId] = info;
//        }
//    }


//    public ObjTableArtworklordInfoConfigInfo GetArtworklordInfoConfigById(int _id)
//    {
//        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
//            return mDicInfo[_id];

//        return null;
//    }
//}
//#endregion

#region  tRoleExp
public class TableRoleExpInfo : TableData
{
    public readonly string sFilePath = "tRoleExp";

    Dictionary<int, int> mDicInfo;

    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, int>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            int lev = mTableData.GetInt(i, DataDefine.Exp_RoleExp_Lev);
            int exp = mTableData.GetInt(i, DataDefine.Exp_RoleExp_Exp);

            mDicInfo[lev] = exp;
        }
    }

    public int GetRoleExpByLev(int _lev)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_lev))
            return mDicInfo[_lev];

        return int.MaxValue;
    }

    public int GetRoleLevByExp(float _exp)
    {
        int lev = 1;
        foreach(int key in mDicInfo.Keys)
        {
            if (_exp >= mDicInfo[key])
                lev = key;
        }
        return lev;
    }
}
#endregion




#region EmployeeEvent
public class TableEmployeeEventInfo : TableData
{
    public readonly string sFilePath = "tEmployeeEvent";
    public class ObjEmployeeEventInfo
    {
        public int mId;
        public EEmployeeEventType mType;
        public List<int> mProjectProgress;
        public EEventContentType mContentType;
        //public int mContentValue;
        public int mCostValue;
        public int mDummyTime;
        public int mTime;

        public string mDesc;
        public EReferenceType mReferenceType;
        public int mSuccessProp;
        public EEventEffectType mSuccessRewardType;
        public int mSuccessRewardValue;
        public EEventEffectType mFailepunishType;
        public int mFailepunishValue;
        public EEventEffectType mRefuseLoseType;
        public float mRefuseLoseValue;
        public string mSuccessDesc;
        public string mFaileDesc;
        public string mRefuseDesc;
    }

    Dictionary<int, ObjEmployeeEventInfo> mDicInfo;
    List<ObjEmployeeEventInfo> mListAllInfo;
    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        //Debug.LogError("----TableEmployeeEventInfo--_ParseData-:" + mTableData._nRows);
        mDicInfo = new Dictionary<int, ObjEmployeeEventInfo>();
        mListAllInfo = new List<ObjEmployeeEventInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjEmployeeEventInfo info = new ObjEmployeeEventInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_Id);
            info.mType = (EEmployeeEventType)mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_Type);
            info.mProjectProgress = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Event_EmployeeEvent_ProjectProgress));
          
            info.mContentType = (EEventContentType)mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_ContentType);
          
            info.mCostValue = mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_CostValue);
            info.mDummyTime = mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_DummyTime);
            info.mTime = mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_Time);

            info.mDesc = mTableData.GetStr(i, DataDefine.Event_EmployeeEvent_Desc);
            info.mReferenceType = (EReferenceType)mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_ReferenceType);
            info.mSuccessProp = mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_SuccessProp);
            info.mSuccessRewardType = (EEventEffectType)mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_SuccessRewardType);
            info.mSuccessRewardValue = mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_SuccessRewardValue);
            info.mFailepunishType = (EEventEffectType)mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_FailepunishType);
            info.mFailepunishValue = mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_FailepunishValue);
            info.mRefuseLoseType = (EEventEffectType)mTableData.GetInt(i, DataDefine.Event_EmployeeEvent_RefuseLoseType);
            info.mRefuseLoseValue = mTableData.GetFloat(i, DataDefine.Event_EmployeeEvent_RefuseLoseValue);
            info.mSuccessDesc = mTableData.GetStr(i, DataDefine.Event_EmployeeEvent_SuccessDesc);
            info.mFaileDesc = mTableData.GetStr(i, DataDefine.Event_EmployeeEvent_FaileDesc);
            info.mRefuseDesc = mTableData.GetStr(i, DataDefine.Event_EmployeeEvent_RefuseDesc);

            //if (info.mType == EEmployeeEventType.ePersonal)
            {
                mDicInfo[info.mId] = info;
                mListAllInfo.Add(info);
            }
        }
    }

    public ObjEmployeeEventInfo GetEmployeeEventInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }

    public List<ObjEmployeeEventInfo> GetAllEmployeeEventInfo()
    {
        //Debug.LogError("------mListAllInfo----------:" + mListAllInfo.Count);
        return mListAllInfo;
    }
}
#endregion



#region PayRiseEvent
public class TablePayRiseEventInfo : TableData
{
    public readonly string sFilePath = "tPayRiseEvent";
    public class ObjPayRiseEventInfo
    {
        public int mId;
        public List<int> mValueSection;
        public int mProp;
        public EPayRiseEventType mEventType;
        public int mEventValue;
        public string mDesc;
        public int mAgreeRiseValue;
    }
    Dictionary<int, ObjPayRiseEventInfo> mDicInfo;
  
    protected override string GetPath()
    {
        return sFilePath;
    }
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjPayRiseEventInfo>();
       
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjPayRiseEventInfo info = new ObjPayRiseEventInfo();

            info.mId = mTableData.GetInt(i, DataDefine.Event_PayRiseEvent_id);
            info.mValueSection = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Event_PayRiseEvent_ValueSection));
            info.mProp = mTableData.GetInt(i, DataDefine.Event_PayRiseEvent_Prop);
            info.mEventType =(EPayRiseEventType) mTableData.GetInt(i, DataDefine.Event_PayRiseEvent_EventType);
            info.mEventValue = mTableData.GetInt(i, DataDefine.Event_PayRiseEvent_EventValue);
            info.mDesc = mTableData.GetStr(i, DataDefine.Event_PayRiseEvent_Desc);
            info.mAgreeRiseValue = mTableData.GetInt(i, DataDefine.Event_PayRiseEvent_AgreeRiseValue);

            mDicInfo[info.mId] = info;
        }
    }
    public ObjPayRiseEventInfo GetPayRiseEventInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];
        return null;
    }

    public ObjPayRiseEventInfo GetPayRiseEventInfoByValue(float _value)
    {
        ObjPayRiseEventInfo result = null;
        foreach (int id in mDicInfo.Keys)
        {
            ObjPayRiseEventInfo info = mDicInfo[id];
         
            if (_value > info.mValueSection[0] && _value < info.mValueSection[1])
            {
                result = info;
                break;
            }
        }
        return result;
    }
}
#endregion

//#region tArtPeriphery
//public class TableArtPeripheryInfo : TableData
//{
//    public readonly string sFilePath = "tArtPeriphery";
//    public class ObjArtPeripheryInfo
//    {
//        public int mId;
//        public string mName;
//        public string mIcon;
//        public float mPrice;
//        public int mCost;
//    }

//    Dictionary<int, ObjArtPeripheryInfo> mDicInfo;
//    List<ObjArtPeripheryInfo> mListAllInfo;
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    protected override void _ParseData()
//    {
//        mDicInfo = new Dictionary<int, ObjArtPeripheryInfo>();
//        mListAllInfo = new List<ObjArtPeripheryInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjArtPeripheryInfo info = new ObjArtPeripheryInfo();
//            info.mId = mTableData.GetInt(i, DataDefine.Game_Periphery_id);
//            info.mName = mTableData.GetStr(i, DataDefine.Game_Periphery_Name);
//            info.mIcon = mTableData.GetStr(i, DataDefine.Game_Periphery_Icon);
//            info.mPrice = mTableData.GetFloat(i, DataDefine.Game_Periphery_Price);
//            info.mCost = mTableData.GetInt(i, DataDefine.Game_Periphery_Cost);

//            mDicInfo[info.mId] = info;
//            mListAllInfo.Add(info);
//        }
//    }

//    public ObjArtPeripheryInfo GetArtPeripheryInfoById(int _id)
//    {
//        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
//            return mDicInfo[_id];
//        return null;
//    }

//    public List<ObjArtPeripheryInfo> GetAllArtPeripheryInfo()
//    {
//        return mListAllInfo;
//    }
//}
//#endregion

#region tEmployeePayRise
public class TableEmployeePayRiseInfo : TableData
{
    public readonly string sFilePath = "tEmployeePayRise";
    public class ObjEmployeePayRiseInfo
    {
        public int mId;
        public int mPayRiseValue;
        public int mLoyalAdd;
    }
    protected override string GetPath()
    {
        return sFilePath;
    }

    Dictionary<int, ObjEmployeePayRiseInfo> mDicInfo;
    List<ObjEmployeePayRiseInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjEmployeePayRiseInfo>();
        mListAllInfo = new List<ObjEmployeePayRiseInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
           
            ObjEmployeePayRiseInfo info = new ObjEmployeePayRiseInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Role_EmployeePayRise_Id);
            Debug.LogError("-----info.mId------:" + info.mId);
            info.mPayRiseValue = mTableData.GetInt(i, DataDefine.Role_EmployeePayRise_PayRiseValue);
            info.mLoyalAdd = mTableData.GetInt(i, DataDefine.Role_EmployeePayRise_LoyalAdd);

            mDicInfo[info.mId] = info;
            mListAllInfo.Add(info);
        }
    }

    public List<ObjEmployeePayRiseInfo> GetAllPayRiseInfo()
    {
        return mListAllInfo;
    }

    public ObjEmployeePayRiseInfo GetPayRiseInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }
}
#endregion

#region tFire
public class TableFireEmployeeInfo : TableData
{
    public readonly string sFilePath = "tFire";
    public class ObjFireEmployeeInfo
    {
        public int mId;
        public ECompensateType mCompensateType;
        public string mName;
        public int mCompanyRepute;
    }
    protected override string GetPath()
    {
        return sFilePath;
    }
    Dictionary<int, ObjFireEmployeeInfo> mDicInfo;
    List<ObjFireEmployeeInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjFireEmployeeInfo>();
        mListAllInfo = new List<ObjFireEmployeeInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjFireEmployeeInfo info = new ObjFireEmployeeInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Role_Fire_Id);
            info.mCompensateType = (ECompensateType)mTableData.GetInt(i, DataDefine.Role_Fire_CompensateType);
            info.mName = mTableData.GetStr(i, DataDefine.Role_Fire_Name);
            info.mCompanyRepute = mTableData.GetInt(i, DataDefine.Role_Fire_CompanyRepute);

            mDicInfo[info.mId] = info;
            mListAllInfo.Add(info);
        }
    }
    public List<ObjFireEmployeeInfo> GetAllFireInfo()
    {
        return mListAllInfo;
    }
}

#endregion

//#region tMaterial
//public class TableGameMaterialInfo : TableData
//{
//    public readonly string sFilePath = "tMaterial";
//    public class ObjGameMaterialInfo
//    {
//        public int mId;
//        public EMaterialType mMaterialType;
//        public int mCounter;
//    }
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    Dictionary<int, ObjGameMaterialInfo> mDicInfo;
//    List<ObjGameMaterialInfo> mListAllGameMaterialInfo;
//    protected override void _ParseData()
//    {
//        mDicInfo = new Dictionary<int, ObjGameMaterialInfo>();
//        mListAllGameMaterialInfo = new List<ObjGameMaterialInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjGameMaterialInfo info = new ObjGameMaterialInfo();
//            info.mId = mTableData.GetInt(i, DataDefine.Game_Material_Id);
//            info.mMaterialType = (EMaterialType)mTableData.GetInt(i, DataDefine.Game_Material_MaterialType);
//            info.mCounter = mTableData.GetInt(i, DataDefine.Game_Material_Counter);

//            mDicInfo[info.mId] = info;
//            mListAllGameMaterialInfo.Add(info);
//        }
//    }

//    public ObjGameMaterialInfo GetGameMaterialInfoById(int _id)
//    {
//        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
//            return mDicInfo[_id];

//        return null;
//    }
//    public List<ObjGameMaterialInfo> GetAllGameMaterialInfo()
//    {
//        return mListAllGameMaterialInfo;
//    }

//}
//#endregion

#region ReduceByAge
public class TableReduceByAgeInfo : TableData
{
    public readonly string sFilePath = "tReduceByAge";
    public class ObjReduceByAgeInfo
    {
        public int mAge;
        public List<int> mStrengthReduce;
        //public List<int> mLearnAblityReduce;
    }
    protected override string GetPath()
    {
        return sFilePath;
    }
    Dictionary<int, ObjReduceByAgeInfo> mDicInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjReduceByAgeInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjReduceByAgeInfo info = new ObjReduceByAgeInfo();
            info.mAge = mTableData.GetInt(i, DataDefine.Role_ReduceByAge_Age);
            info.mStrengthReduce = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Role_ReduceByAge_StrengthReduce));
            //info.mLearnAblityReduce = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Role_ReduceByAge_LearnAblityReduce));

            mDicInfo[info.mAge] = info;
        }
    }

    public ObjReduceByAgeInfo GetReduceByAgeInfoByAge(int _age)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_age))
            return mDicInfo[_age];

        return null;
    }
}
#endregion

//#region tProjectGetFans
//public class TableProjectGetFansInfo : TableData
//{
//    public readonly string sFilePath = "tProjectGetFans";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    public class ObjProjectGetFansInfo
//    {
//        public int mId;
//        public int mProjectNum;
//        public int mYear;
//        public int mFansNum;
//        public string mDesc;
//    }

//    Dictionary<int, ObjProjectGetFansInfo> mDicInfo;

//    List<ObjProjectGetFansInfo> mAllInfo;
//    protected override void _ParseData()
//    {
//        mDicInfo = new Dictionary<int, ObjProjectGetFansInfo>();
//        mAllInfo = new List<ObjProjectGetFansInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjProjectGetFansInfo info = new ObjProjectGetFansInfo();
//            info.mId = mTableData.GetInt(i, DataDefine.Milestone_ProjectGetFans_Id);
//            info.mProjectNum = mTableData.GetInt(i, DataDefine.Milestone_ProjectGetFans_ProjectNum);
//            info.mYear = mTableData.GetInt(i, DataDefine.Milestone_ProjectGetFans_Year);
//            info.mFansNum = mTableData.GetInt(i, DataDefine.Milestone_ProjectGetFans_FansNum);
//            info.mDesc = mTableData.GetStr(i, DataDefine.Milestone_ProjectGetFans_Desc);

//            mDicInfo[info.mId] = info;
//            mAllInfo.Add(info);
//        }
//    }

//    public ObjProjectGetFansInfo GetProjectGetFansInfoById(int _id)
//    {
//        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
//            return mDicInfo[_id];

//        return null;
//    }


//    public List<ObjProjectGetFansInfo> GetAllProjectGetFansInfo()
//    {
//        return mAllInfo;
//    }
//}

//#endregion

//#region fansunlock
//public class TableFansUnLockInfo : TableData
//{
//    public readonly string sFilePath = "tFansUnLock";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }

//    public class ObjFansUnlockInfo
//    {
//        public int mFansNum;
//        public EFansUnlockTypeEnum mContent1;
//        public List<int> mContentValue1;
//        public EFansUnlockTypeEnum mContent2;
//        public List<int> mContentValue2;
//        public string mDesc;
//    }

//    List<ObjFansUnlockInfo> mListAllData;
//    protected override void _ParseData()
//    {
//        mListAllData = new List<ObjFansUnlockInfo>();
//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjFansUnlockInfo info = new ObjFansUnlockInfo();
//            info.mFansNum = mTableData.GetInt(i, DataDefine.Fans_FansUnLock_FansNum);
//            info.mContent1 = (EFansUnlockTypeEnum)mTableData.GetInt(i, DataDefine.Fans_FansUnLock_Content1);
//            info.mContentValue1 = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Fans_FansUnLock_ContentValue1));

//            info.mContent2 = (EFansUnlockTypeEnum)mTableData.GetInt(i, DataDefine.Fans_FansUnLock_Content2);
//            info.mContentValue2 = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Fans_FansUnLock_ContentValue2));

//            info.mDesc = mTableData.GetStr(i, DataDefine.Fans_FansUnLock_Desc);

//            mListAllData.Add(info);
//        }
//    }

//    public ObjFansUnlockInfo GetCurrentFanUnlockInfoByNums(int _fansNum)
//    {
//        ObjFansUnlockInfo info = null;
//        if (null != mListAllData && mListAllData.Count > 0)
//        {
//            for (int i = 0; i < mListAllData.Count; i++)
//            {
//                if (_fansNum <= mListAllData[i].mFansNum)
//                {
//                    info = mListAllData[i];
//                    break;
//                }

//            }
//        }
//        return info;
//    }

//    public ObjFansUnlockInfo GetNextFanUnlockInfoByNums(int _fansNum)
//    {
//        ObjFansUnlockInfo info = null;
//        if (null != mListAllData && mListAllData.Count > 0)
//        {
//            for (int i = 0;i < mListAllData.Count; i++)
//            {
//                if (_fansNum < mListAllData[i].mFansNum)
//                {
//                    info = mListAllData[i];
//                    break;
//                }

//            }
//        }
//        return info;
//    }

//    public List<ObjFansUnlockInfo> GetAllFansUnlockInfo()
//    {
//        return mListAllData;
//    }
//}
//#endregion

//#region role actions
//public class TableRoleActionInfo : TableData
//{
//    public readonly string sFilePath = "tRoleActions";
//    protected override string GetPath()
//    {
//        return sFilePath;
//    }
//    public class ObjRoleActionInfo
//    {
//        public ERoleActionTypeEnum mActionType;
//        public string mIcon;
//        public string mEffectObj;
//        public string mName;
//        public string mDesc;
//        public int mEffectType;
//        public float mEffectValue;
//        public float mStayTime;
//        public int mPress;
//    }

//    Dictionary<ERoleActionTypeEnum, ObjRoleActionInfo> mDicInfo;
//    protected override void _ParseData()
//    {
//        mDicInfo = new Dictionary<ERoleActionTypeEnum, ObjRoleActionInfo>();

//        for (int i = 0; i < mTableData._nRows; i++)
//        {
//            ObjRoleActionInfo info = new ObjRoleActionInfo();

//            info.mActionType = (ERoleActionTypeEnum)mTableData.GetInt(i, DataDefine.Role_RoleActions_ActionType);
//            info.mIcon = mTableData.GetStr(i, DataDefine.Role_RoleActions_Icon);
//            info.mEffectObj = mTableData.GetStr(i, DataDefine.Role_RoleActions_EffectObj);
//            info.mName = mTableData.GetStr(i, DataDefine.Role_RoleActions_Name);
//            info.mDesc = mTableData.GetStr(i, DataDefine.Role_RoleActions_Desc);
//            info.mEffectType = mTableData.GetInt(i, DataDefine.Role_RoleActions_EffectType);
//            info.mEffectValue = mTableData.GetFloat(i, DataDefine.Role_RoleActions_EffectValue);
//            info.mPress = mTableData.GetInt(i, DataDefine.Role_RoleActions_Press);
//            info.mStayTime = mTableData.GetFloat(i, DataDefine.Role_RoleActions_StayTime);

//            mDicInfo[info.mActionType] = info;
//        }
//    }

//    public ObjRoleActionInfo GetRoleActionInfoById(ERoleActionTypeEnum _id)
//    {
//        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
//            return mDicInfo[_id];
//        return null;
//    }
//}
//#endregion

#region tRoleBadState
public class TableRoleBadStateInfo : TableData
{
    public readonly string sFilePath = "tRoleBadState";
    protected override string GetPath()
    {
        return sFilePath;
    }

    public class ObjRoleBadStateInfo
    {
        public int mId;
        public List<int> mValueSection;
        public float mProp;
        public List<int> mAction;
        public int mType;
        public int mStayTime;
        public string mObjEffectName;
        public string mDesc;
        public float mStrength;
        public float mPress;
        public float mAllRolePress;
        public float mloyal;
        public int mTempGameDesign;
        public int mTempTech;
        public int mTempArt;
        public E_EmployeeMentalityType mMentalityType;
    }
    Dictionary<int, ObjRoleBadStateInfo> mDicInfo;
    Dictionary<E_EmployeeMentalityType, List<ObjRoleBadStateInfo>> mDicMentalityBadStateInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjRoleBadStateInfo>();
        mDicMentalityBadStateInfo = new Dictionary<E_EmployeeMentalityType, List<ObjRoleBadStateInfo>>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjRoleBadStateInfo info = new ObjRoleBadStateInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Role_BadState_id);
            info.mValueSection = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Role_BadState_ValueSection));
            info.mProp = mTableData.GetFloat(i, DataDefine.Role_BadState_Prop);
            info.mAction = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Role_BadState_Action));
            info.mType = mTableData.GetInt(i, DataDefine.Role_BadState_Type);
            info.mStayTime = mTableData.GetInt(i, DataDefine.Role_BadState_StayTime);
            info.mObjEffectName = mTableData.GetStr(i, DataDefine.Role_BadState_ObjEffectName);
            info.mDesc = mTableData.GetStr(i, DataDefine.Role_BadState_Desc);
            info.mStrength = mTableData.GetFloat(i, DataDefine.Role_BadState_Strength);
            info.mPress = mTableData.GetFloat(i, DataDefine.Role_BadState_Press);
            info.mAllRolePress = mTableData.GetFloat(i, DataDefine.Role_BadState_AllRolePress);
            info.mloyal = mTableData.GetFloat(i, DataDefine.Role_BadState_loyal);
            info.mTempGameDesign = mTableData.GetInt(i, DataDefine.Role_BadState_TempGameDesign);
            info.mTempTech = mTableData.GetInt(i, DataDefine.Role_BadState_TempTech);
            info.mTempArt = mTableData.GetInt(i, DataDefine.Role_BadState_TempArt);
            info.mMentalityType = (E_EmployeeMentalityType)mTableData.GetInt(i, DataDefine.Role_BadState_MentalityState);


            if (!mDicMentalityBadStateInfo.ContainsKey(info.mMentalityType))
                mDicMentalityBadStateInfo[info.mMentalityType] = new List<ObjRoleBadStateInfo>();

            mDicMentalityBadStateInfo[info.mMentalityType].Add(info);

            mDicInfo[info.mId] = info;
        }
    }

    public ObjRoleBadStateInfo GetRoleBadStateInfo(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }

    public List<ObjRoleBadStateInfo> GetRoleBadStateInfoByType(E_EmployeeMentalityType _type)
    {

        if (null != mDicMentalityBadStateInfo && mDicMentalityBadStateInfo.ContainsKey(_type))
            return mDicMentalityBadStateInfo[_type];

        return null;
    }
}
#endregion

#region Atmosphere
public class TableAtmosphereInfo : TableData
{
    public readonly string sFilePath = "tAtmosphere";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjAtmosphereInfo
    {
        public int mId;
        public List<int> mValueRange;
        public float mStrength;
        public float mHunger;
        public float mPress;
        public float mLoyal;
        public string mDesc;

    }
    List<ObjAtmosphereInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mListAllInfo = new List<ObjAtmosphereInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjAtmosphereInfo info = new ObjAtmosphereInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Atmosphere_Atmosphere_Id);
            info.mValueRange = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Atmosphere_Atmosphere_ValueRange));
            info.mStrength = mTableData.GetFloat(i, DataDefine.Atmosphere_Atmosphere_Strength);
            info.mHunger = mTableData.GetFloat(i, DataDefine.Atmosphere_Atmosphere_Hunger);
            info.mPress = mTableData.GetFloat(i, DataDefine.Atmosphere_Atmosphere_Press);
            info.mLoyal = mTableData.GetFloat(i, DataDefine.Atmosphere_Atmosphere_Loyal);
            info.mDesc = mTableData.GetStr(i, DataDefine.Atmosphere_Atmosphere_Desc);
            mListAllInfo.Add(info);
        }
    }

    public ObjAtmosphereInfo GetAtmosphereInfoByValue(int _value)
    {
        ObjAtmosphereInfo info = new ObjAtmosphereInfo();

        for (int i = 0; i < mListAllInfo.Count; i++)
        {
            if (_value >= mListAllInfo[i].mValueRange[0] && _value <= mListAllInfo[i].mValueRange[1])
                info = mListAllInfo[i];
        }
        return info;
    }
}
#endregion

#region publisher
public class TablePublisherInfo : TableData
{
    public readonly string sFilePath = "tPublisher";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjPublisherInfo
    {
        public string mId;
        //public string mName;
        public string mSkinName;
        public int mStartPortion;
        public int mEndPortion;
        public int mYear;
        public EWorldSubregion mMapRegion;
        public string mOpeningRemarks;
        public string mScore25;
        public string mScore50; 
        public string mScore75;
        public string mScore95;
        public string mScore100;
    }
    List<ObjPublisherInfo> mListAllInfo;
    Dictionary<string, ObjPublisherInfo> mDicPublisherInfo;

    protected override void _ParseData()
    {
        mDicPublisherInfo = new Dictionary<string, ObjPublisherInfo>();
        mListAllInfo = new List<ObjPublisherInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjPublisherInfo info = new ObjPublisherInfo();
            info.mId = mTableData.GetStr(i, DataDefine.Npc_Publisher_id);          
            info.mYear = mTableData.GetInt(i, DataDefine.Npc_Publisher_Year);
            info.mMapRegion = (EWorldSubregion)mTableData.GetInt(i, DataDefine.Npc_Publisher_MapRegion);
            info.mStartPortion = mTableData.GetInt(i, DataDefine.Npc_Publisher_StartPortion);
            info.mEndPortion = mTableData.GetInt(i, DataDefine.Npc_Publisher_EndPortion);
            info.mOpeningRemarks = mTableData.GetStr(i, DataDefine.Npc_Publisher_OpeningRemarks);
            info.mScore25 = mTableData.GetStr(i, DataDefine.Npc_Publisher_Score25);
            info.mScore50 = mTableData.GetStr(i, DataDefine.Npc_Publisher_Score50);
            info.mScore75 = mTableData.GetStr(i, DataDefine.Npc_Publisher_Score75);
            info.mScore95 = mTableData.GetStr(i, DataDefine.Npc_Publisher_Score95);
            info.mScore100 = mTableData.GetStr(i, DataDefine.Npc_Publisher_Score100);

            mDicPublisherInfo[info.mId] = info;
            mListAllInfo.Add(info);
        }
    }

    public List<ObjPublisherInfo> GetListPublisherInfoByYear(int _year)
    {
        List<ObjPublisherInfo> yearInfo = new List<ObjPublisherInfo>();
        if (null != mListAllInfo && mListAllInfo.Count > 0)
        {
            for (int i = 0; i < mListAllInfo.Count; i++)
            {
                if (mListAllInfo[i].mYear <= _year)
                    yearInfo.Add(mListAllInfo[i]);
            }
        }
        return yearInfo;
    }

    public ObjPublisherInfo GetPublisherInfoById(string _id)
    {
        if (null != mDicPublisherInfo && mDicPublisherInfo.ContainsKey(_id))
            return mDicPublisherInfo[_id];
        return null;
    }

}

#endregion
#region RolePassiveSkills
public class TableRolePassiveSkillsInfo : TableData
{
    public readonly string sFilePath = "tRolePassiveSkills";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjRolePassiveSkillsInfo
    {
        public int mId;
        public ERolePassiveSkillsTypeEnum mType;
        public int mSubType;
        public float mValue;
        public string mName;
        public string mDesc;
        public string mObjName;
        public string mIconName;
        public int mSalary;


        public E_GetSkill_ActionType mGetSkillActionType;
        public int mGetSkillProp;

    }
    Dictionary<int, ObjRolePassiveSkillsInfo> mDicInfo;
    List<ObjRolePassiveSkillsInfo> mListPassiveSkills;

    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjRolePassiveSkillsInfo>();
        mListPassiveSkills = new List<ObjRolePassiveSkillsInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjRolePassiveSkillsInfo info = new ObjRolePassiveSkillsInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Role_PassiveSkills_id);
            info.mType = (ERolePassiveSkillsTypeEnum)mTableData.GetInt(i, DataDefine.Role_PassiveSkills_Type);
            info.mSubType = mTableData.GetInt(i, DataDefine.Role_PassiveSkills_SubType);
            info.mValue = mTableData.GetFloat(i, DataDefine.Role_PassiveSkills_Value);
            info.mName = mTableData.GetStr(i, DataDefine.Role_PassiveSkills_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Role_PassiveSkills_Desc);
            info.mObjName = mTableData.GetStr(i, DataDefine.Role_PassiveSkills_ObjName);
            info.mIconName = mTableData.GetStr(i, DataDefine.Role_PassiveSkills_IconName);
            info.mSalary = mTableData.GetInt(i, DataDefine.Role_PassiveSkills_Salary);

            List<int> listProp = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Role_PassiveSkills_ActionProp));
            info.mGetSkillActionType = (E_GetSkill_ActionType)listProp[0];
            info.mGetSkillProp = listProp[1];
            info.mGetSkillProp = 10;

            mDicInfo[info.mId] = info;
            mListPassiveSkills.Add(info);
        }
    }
    public List<ObjRolePassiveSkillsInfo> GetAllPassiveSkills()
    {
        return mListPassiveSkills;
    }

    public ObjRolePassiveSkillsInfo GetRolePassiveSkillsInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }

    public int GetRoleRandomGameTypeSkills()
    {
        List<int> gametimekill = new List<int>();
        foreach (int key in mDicInfo.Keys)
        {
            if (mDicInfo[key].mType == ERolePassiveSkillsTypeEnum.eGameType )
                gametimekill.Add(key);
        }

        int index = Random.Range(0, gametimekill.Count);
        //return gametimekill[0];
        return gametimekill[index];
    }

    public int GetRoleRandomTopicSkills()
    {
        List<int> topickill = new List<int>();

        foreach (int key in mDicInfo.Keys)
        {
            if (mDicInfo[key].mType == ERolePassiveSkillsTypeEnum.eGameTopic)
                topickill.Add(key);

        }

        int index = Random.Range(0, topickill.Count);
        //return topickill[2];
        return topickill[index];
    }
}

#endregion

#region  worldGame
public class TableWorldGameInfo : TableData
{
    public readonly string sFilePath = "tWorldGame";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTableWorldGameInfo
    {
        public int mId;
        public int mYear;
        public string mName;
        public int mIncome;
        public bool mImportant;
        public int mCoreplayId;

        public float mSettingValue1;
        public float mSettingValue2;
        public float mSettingValue3;
        public float mSettingValue4;
        public float mSettingValue5;
        public float mSettingValue6;
    }
    Dictionary<int, ObjTableWorldGameInfo> mDicInfo;
    Dictionary<int, List<ObjTableWorldGameInfo>> mDicYearGameList;

    List<ObjTableWorldGameInfo> allWorldGameInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjTableWorldGameInfo>();
        mDicYearGameList = new Dictionary<int, List<ObjTableWorldGameInfo>>();
        allWorldGameInfo = new List<ObjTableWorldGameInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTableWorldGameInfo info = new ObjTableWorldGameInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Game_WorldGame_Id);
            info.mYear = mTableData.GetInt(i, DataDefine.Game_WorldGame_Year);
            info.mName = mTableData.GetStr(i, DataDefine.Game_WorldGame_Name);
            info.mIncome = mTableData.GetInt(i, DataDefine.Game_WorldGame_Income);
            info.mImportant = mTableData.GetInt(i, DataDefine.Game_WorldGame_Important) == 1;
            info.mCoreplayId = mTableData.GetInt(i, DataDefine.Game_WorldGame_CoreplayId);
            info.mSettingValue1 = mTableData.GetFloat(i, DataDefine.Game_WorldGame_Setting1);
            info.mSettingValue2 = mTableData.GetFloat(i, DataDefine.Game_WorldGame_Setting2);
            info.mSettingValue3 = mTableData.GetFloat(i, DataDefine.Game_WorldGame_Setting3);          
            
            info.mSettingValue4 = mTableData.GetFloat(i, DataDefine.Game_WorldGame_Setting4);
            info.mSettingValue5 = mTableData.GetFloat(i, DataDefine.Game_WorldGame_Setting5);
            info.mSettingValue6 = mTableData.GetFloat(i, DataDefine.Game_WorldGame_Setting6);

            allWorldGameInfo.Add(info);

            mDicInfo[info.mId] = info;

            if (!mDicYearGameList.ContainsKey(info.mYear))
                mDicYearGameList[info.mYear] = new List<ObjTableWorldGameInfo>();
            mDicYearGameList[info.mYear].Add(info);
        }
    }

    public ObjTableWorldGameInfo GetWorldGameInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }

    public List<ObjTableWorldGameInfo> GetWorldGameListByYear(int _year)
    {
        if (null != mDicYearGameList && mDicYearGameList.ContainsKey(_year))
            return mDicYearGameList[_year];

        return null;
    }

    public List<ObjTableWorldGameInfo> GetAllWorldGameInfo()
    {
        return allWorldGameInfo;
    }
}
#endregion

#region gameshowlayout
public class TabletGameShowShowcaseInfo : TableData
{
    public readonly string sFilePath = "tGameShowShowcase";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTableGameShowShowcaseInfo
    {
        public int mId;
        public string mObjName;
        public int Lev;
        public bool mHaibao;
        public bool mYiLaBao;
        public bool mLogo;
        public bool mBanner;
    }

    Dictionary<int, ObjTableGameShowShowcaseInfo> mDicInfo;
    Dictionary<int, List<ObjTableGameShowShowcaseInfo>> mDicLevInfo;

    protected override void _ParseData()
    {
        mDicLevInfo = new Dictionary<int, List<ObjTableGameShowShowcaseInfo>>();
        mDicInfo = new Dictionary<int, ObjTableGameShowShowcaseInfo>();     
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTableGameShowShowcaseInfo info = new ObjTableGameShowShowcaseInfo();
            info.mId = mTableData.GetInt(i, DataDefine.GameShowLayout_Showcase_Id);
            info.mObjName = mTableData.GetStr(i, DataDefine.GameShowLayout_Showcase_ObjName);
            info.Lev = mTableData.GetInt(i, DataDefine.GameShowLayout_Showcase_Lev);
            info.mHaibao = mTableData.GetInt(i, DataDefine.GameShowLayout_Showcase_Haibao) == 1;
            info.mYiLaBao = mTableData.GetInt(i, DataDefine.GameShowLayout_Showcase_YiLaBao) == 1;

            info.mLogo = mTableData.GetInt(i, DataDefine.GameShowLayout_Showcase_Logo) == 1;
            info.mBanner = mTableData.GetInt(i, DataDefine.GameShowLayout_Showcase_Banner) == 1;

            mDicInfo[info.mId] = info;

            if (!mDicLevInfo.ContainsKey(info.Lev))
                mDicLevInfo[info.Lev] = new List<ObjTableGameShowShowcaseInfo>();
            mDicLevInfo[info.Lev].Add(info);
        }
    }

    public ObjTableGameShowShowcaseInfo GetShowcaseInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];
        return null;
    }
    public List<ObjTableGameShowShowcaseInfo> GetShowcaseInfoByLev(int _lev)
    {
        if (null != mDicLevInfo && mDicLevInfo.ContainsKey(_lev))
            return mDicLevInfo[_lev];
        return null;
    }
}

public class TabletGameShowShowcaseLogoInfo : TableData
{
    public readonly string sFilePath = "tGameShowLogo";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTableGameShowShowcaseLogoInfo
    {
        public int mId;
        public string mObjName;
    }
    List<ObjTableGameShowShowcaseLogoInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mListAllInfo = new List<ObjTableGameShowShowcaseLogoInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTableGameShowShowcaseLogoInfo info = new ObjTableGameShowShowcaseLogoInfo();
            info.mId = mTableData.GetInt(i, DataDefine.GameShowLayout_Logo_Id);
            info.mObjName = mTableData.GetStr(i, DataDefine.GameShowLayout_Logo_ObjName);
            mListAllInfo.Add(info);
        }
    }

    public List<ObjTableGameShowShowcaseLogoInfo> GetAllShowcaseLogoInfo()
    {
        return mListAllInfo;
    }
}
public class TabletGameShowShowcaseBannerInfo : TableData
{
    public readonly string sFilePath = "tGameShowBanner";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTableGameShowShowcaseBannerInfo
    {
        public int mId;
        public string mObjName;
    }
    List<ObjTableGameShowShowcaseBannerInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mListAllInfo = new List<ObjTableGameShowShowcaseBannerInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTableGameShowShowcaseBannerInfo info = new ObjTableGameShowShowcaseBannerInfo();
            info.mId = mTableData.GetInt(i, DataDefine.GameShowLayout_Banner_Id);
            info.mObjName = mTableData.GetStr(i, DataDefine.GameShowLayout_Banner_ObjName);
            mListAllInfo.Add(info);
        }
    }

    public List<ObjTableGameShowShowcaseBannerInfo> GetAllShowcaseBannerInfo()
    {
        return mListAllInfo;
    }
}
public class TabletGameShowShowcaseYiLabaoInfo : TableData
{
    public readonly string sFilePath = "tGameShowYiLaBao";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTableGameShowShowcaseYiLaBaoInfo
    {
        public int mId;
        public string mObjName;
        public bool mIsVer;
    }
    List<ObjTableGameShowShowcaseYiLaBaoInfo> mListAllInfo;
    List<ObjTableGameShowShowcaseYiLaBaoInfo> mListAllVerInfo;
    protected override void _ParseData()
    {
        mListAllInfo = new List<ObjTableGameShowShowcaseYiLaBaoInfo>();
        mListAllVerInfo = new List<ObjTableGameShowShowcaseYiLaBaoInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTableGameShowShowcaseYiLaBaoInfo info = new ObjTableGameShowShowcaseYiLaBaoInfo();
            info.mId = mTableData.GetInt(i, DataDefine.GameShowLayout_YiLaBao_Id);
            info.mObjName = mTableData.GetStr(i, DataDefine.GameShowLayout_YiLaBao_ObjName);
            info.mIsVer = mTableData.GetInt(i, DataDefine.GameShowLayout_YiLaBao_Ver) == 1;

            if(info.mIsVer)
                mListAllVerInfo.Add(info);
            else
                mListAllInfo.Add(info);
        }
    }

    public List<ObjTableGameShowShowcaseYiLaBaoInfo> GetAllShowcaseYiLaBaoInfo(bool _ver)
    {
        if (_ver)
            return mListAllVerInfo;
        else
            return mListAllInfo;
    }
}

public class TabletGameShowStatueInfo : TableData
{
    public readonly string sFilePath = "tGameShowStatue";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletGameShowStatueInfo
    {
        public int mId;
        public string mObjName;
    }
    List<ObjTabletGameShowStatueInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mListAllInfo = new List<ObjTabletGameShowStatueInfo>();
       
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletGameShowStatueInfo info = new ObjTabletGameShowStatueInfo();
            info.mId = mTableData.GetInt(i, DataDefine.GameShowLayout_Statue_Id);
            info.mObjName = mTableData.GetStr(i, DataDefine.GameShowLayout_Statue_ObjName);
            mListAllInfo.Add(info);
        }
    }

    public List<ObjTabletGameShowStatueInfo> GetAllGameShowStatueInfo()
    {
        return mListAllInfo;
    }
}




public class TabletGameShowHaiBaoInfo : TableData
{
    public readonly string sFilePath = "tGameShowHaibao";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletGameShowHaiBaoInfo
    {
        public int mId;
        public string mObjName;
    }
    List<ObjTabletGameShowHaiBaoInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mListAllInfo = new List<ObjTabletGameShowHaiBaoInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletGameShowHaiBaoInfo info = new ObjTabletGameShowHaiBaoInfo();
            info.mId = mTableData.GetInt(i, DataDefine.GameShowLayout_Haibao_Id);
            info.mObjName = mTableData.GetStr(i, DataDefine.GameShowLayout_Haibao_ObjName);
            mListAllInfo.Add(info);
        }
    }

    public ObjTabletGameShowHaiBaoInfo GetRandomHaiBaoInfo()
    {
        if (null != mListAllInfo && mListAllInfo.Count > 0)
        {
            int index = Random.Range(0, mListAllInfo.Count);
            return mListAllInfo[index];
        }
        return null;
    }
}
#endregion

#region tGameIncome
public class TabletIncomeInfo : TableData
{
    public readonly string sFilePath = "tGameIncome";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletIncomeInfo
    {
        public int mScore;
        public int mIncomeValue;
    }
    List<ObjTabletIncomeInfo> allIncomeInfo;
    protected override void _ParseData()
    {
        allIncomeInfo = new List<ObjTabletIncomeInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletIncomeInfo info = new ObjTabletIncomeInfo();
            info.mScore = mTableData.GetInt(i, DataDefine.Game_Income_Score);
            info.mIncomeValue = mTableData.GetInt(i, DataDefine.Game_Income_Income);
            allIncomeInfo.Add(info);
        }
    }

    public ObjTabletIncomeInfo GetTargetIncomeInfoByScore(float _score)
    {
        ObjTabletIncomeInfo mTargetInfo = null;
        int minScore = 9999;
        for (int i = 0; i < allIncomeInfo.Count; i++)
        {
            if (_score < allIncomeInfo[i].mScore)
            {
                if (minScore > allIncomeInfo[i].mScore)
                {
                    minScore = allIncomeInfo[i].mScore;
                    mTargetInfo = allIncomeInfo[i];
                }
            }
        }
        return mTargetInfo;
    }

}
#endregion

#region tNpcAppraise
public class TabletNpcAppraiseInfo : TableData
{
    public readonly string sFilePath = "tNpcAppraise";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletNpcAppraiseInfo
    {
        public int mItemScore;
        public string mSetting1Appraise;
        public string mSetting2Appraise;
        public string mSetting3Appraise;
        public string mSetting4Appraise;
        public string mSetting5Appraise;
        public string mSetting6Appraise;
    }
    List<ObjTabletNpcAppraiseInfo> mAllAppraiseInfo;
 
    protected override void _ParseData()
    {
        mAllAppraiseInfo = new List<ObjTabletNpcAppraiseInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletNpcAppraiseInfo info = new ObjTabletNpcAppraiseInfo();
            info.mItemScore = mTableData.GetInt(i, DataDefine.Npc_Appraise_ItemScore);
            info.mSetting1Appraise = mTableData.GetStr(i, DataDefine.Npc_Appraise_Setting1);
            info.mSetting2Appraise = mTableData.GetStr(i, DataDefine.Npc_Appraise_Setting2);
            info.mSetting3Appraise = mTableData.GetStr(i, DataDefine.Npc_Appraise_Setting3);
            info.mSetting4Appraise = mTableData.GetStr(i, DataDefine.Npc_Appraise_Setting4);
            info.mSetting5Appraise = mTableData.GetStr(i, DataDefine.Npc_Appraise_Setting5);
            info.mSetting6Appraise = mTableData.GetStr(i, DataDefine.Npc_Appraise_Setting6);

            mAllAppraiseInfo.Add(info);
        }
    }

    public ObjTabletNpcAppraiseInfo GetNpcAppraiseInfoByScore(float _score)
    {
        ObjTabletNpcAppraiseInfo result = null;
        if (null != mAllAppraiseInfo && mAllAppraiseInfo.Count > 0)
        {
            for (int i = 0; i < mAllAppraiseInfo.Count; i++)
            {
                if (_score >= mAllAppraiseInfo[i].mItemScore)
                    result = mAllAppraiseInfo[i];
            }
        }

        return result;
    }
}
#endregion

#region active skill
public class TabletRoleActiveSkillInfo : TableData
{
    public readonly string sFilePath = "tRoleActiveSkill";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletRoleActiveSkillInfo
    {
        public int mId;
        public string mName;
        public string mDesc;

        public string mIconName;

        public ERoleActiveSkillTypeEnum mType;
        //public E_RoleType mRoomType;
        public int mWorkLoad;
        public E_RoleType mProfessionType;
        //public float mPressLimit;
        public float mLoyalLimit;
        public int mStayYear;

      
        public int mSettingOperation;
        public int mSettingstrategy;
        public int mSettingCollect;
        public int mSettingArtRole;
        public int mSettingAnima;
        public int mSettingScen;

        public List<int> mProfessionCounter;

        public int mPressValue;
        public int mStrengthValue;
        //public int mPressValue;


    }

    Dictionary<int, ObjTabletRoleActiveSkillInfo> mDicRoleActiveSkillInfo;
    List<ObjTabletRoleActiveSkillInfo> mListAllRoleActiveSkillInfo;
    protected override void _ParseData()
    {
        mDicRoleActiveSkillInfo = new Dictionary<int, ObjTabletRoleActiveSkillInfo>();
        mListAllRoleActiveSkillInfo = new List<ObjTabletRoleActiveSkillInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletRoleActiveSkillInfo info = new ObjTabletRoleActiveSkillInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Role_ActiveSkill_Name);
            info.mDesc = mTableData.GetStr(i, DataDefine.Role_ActiveSkill_Desc);

            info.mType = (ERoleActiveSkillTypeEnum)mTableData.GetInt(i, DataDefine.Role_ActiveSkill_Type);
            info.mIconName = mTableData.GetStr(i, DataDefine.Role_ActiveSkill_IconName);
            //info.mWorkLoad = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_WorkLoad);
            info.mProfessionType = (E_RoleType)mTableData.GetInt(i, DataDefine.Role_ActiveSkill_ProfessionType);
            //info.mPressLimit = mTableData.GetFloat(i, DataDefine.Role_ActiveSkill_PressValue);
            info.mLoyalLimit = mTableData.GetFloat(i, DataDefine.Role_ActiveSkill_LoyalValue);
            info.mStayYear = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_Year);

            //info.mTechCounter = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_TechCounter);
            //info.mArtCounter = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_ArtCounter);
            info.mPressValue = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_PressValue);
            info.mStrengthValue = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_StrengthValue);

            info.mSettingOperation = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_SettingOperation);
            info.mSettingstrategy = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_Settingstrategy);
            info.mSettingCollect = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_SettingCollect);
            info.mSettingArtRole = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_SettingArtRole);
            info.mSettingAnima = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_SettingAnima);
            info.mSettingScen = mTableData.GetInt(i, DataDefine.Role_ActiveSkill_SettingScen);
            info.mProfessionCounter = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Role_ActiveSkill_ProfessionComb));
           



            mDicRoleActiveSkillInfo[info.mId] = info;
            mListAllRoleActiveSkillInfo.Add(info);
        }
    }
    public ObjTabletRoleActiveSkillInfo GetRoleActiveSkillInfoById(int _id)
    {
        if (null != mDicRoleActiveSkillInfo && mDicRoleActiveSkillInfo.ContainsKey(_id))
            return mDicRoleActiveSkillInfo[_id];
        return null;
    }
    public List<ObjTabletRoleActiveSkillInfo> GetAllRoleActiveSkillInfo()
    {
        return mListAllRoleActiveSkillInfo;
    }
}
#endregion

#region talent
public class TabletGameTalentInfo : TableData
{
    public readonly string sFilePath = "tGameTalent";
    protected override string GetPath()
    {
        return sFilePath;
    }

    public class ObjTabletGameTalentInfo
    {
        public int mId;
        public string mName;
        public EGameTalentType mType;
        public string mDesc;
        public string mIconName;
    }
    Dictionary<int, ObjTabletGameTalentInfo> mDicInfo;
    Dictionary<EGameTalentType, List<ObjTabletGameTalentInfo>> mDicTypeListInfo;

    List<ObjTabletGameTalentInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mListAllInfo = new List<ObjTabletGameTalentInfo>();
        mDicInfo = new Dictionary<int, ObjTabletGameTalentInfo>();
        mDicTypeListInfo = new Dictionary<EGameTalentType, List<ObjTabletGameTalentInfo>>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletGameTalentInfo info = new ObjTabletGameTalentInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Game_Talent_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Game_Talent_Name);
            info.mType =(EGameTalentType) mTableData.GetInt(i, DataDefine.Game_Talent_Type);
            info.mDesc = mTableData.GetStr(i, DataDefine.Game_Talent_Desc);
            info.mIconName = mTableData.GetStr(i, DataDefine.Game_Talent_Icon);
            mListAllInfo.Add(info);
            mDicInfo[info.mId] = info;
            if (mDicTypeListInfo.ContainsKey(info.mType))
                mDicTypeListInfo[info.mType].Add(info);
            else
            {
                mDicTypeListInfo[info.mType] = new List<ObjTabletGameTalentInfo>();
                mDicTypeListInfo[info.mType].Add(info);
            }
        }
    }


    public ObjTabletGameTalentInfo GetGameTalentInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];
        return null;
    }

    public List<ObjTabletGameTalentInfo> GetAllGameTalentInfo()
    {
        return mListAllInfo;
    }

    public List<ObjTabletGameTalentInfo> GetGameTalentListInfoByType(EGameTalentType _type)
    {
        if (null != mDicTypeListInfo && mDicTypeListInfo.ContainsKey(_type))
            return mDicTypeListInfo[_type];
        return null;
    }
}
#endregion

#region Furnishing
public class TabletFurnishingInfo : TableData
{
    public readonly string sFilePath = "tFurnishing";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletFurnishingInfo
    {
        public int mId;
        public ERoomType mRoomType;
        public int mItemType;
        public string mName;
        public string mObjName;
        public int mPrice;
        public EFurnitureEffectType mEffectType;
        public float mEffect;
        public bool mDefaultHas;

    }

    Dictionary<int, ObjTabletFurnishingInfo> mDicInfo;
    Dictionary<string, ObjTabletFurnishingInfo> mObjNameDicInfo;
    List<ObjTabletFurnishingInfo> mListForSale;
    protected override void _ParseData()
    {
        mListForSale = new List<ObjTabletFurnishingInfo>();
        mDicInfo = new Dictionary<int, ObjTabletFurnishingInfo>();
        mObjNameDicInfo = new Dictionary<string, ObjTabletFurnishingInfo>();
        //Debug.LogError("----mTableData._nRows----:" + mTableData._nRows);
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletFurnishingInfo info = new ObjTabletFurnishingInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Furnishing_Furnishing_Id);
            info.mPrice = mTableData.GetInt(i, DataDefine.Furnishing_Furnishing_Price);
            info.mRoomType = (ERoomType)mTableData.GetInt(i, DataDefine.Furnishing_Furnishing_RoomType);
            info.mItemType = mTableData.GetInt(i, DataDefine.Furnishing_Furnishing_ItemType);
            info.mName = mTableData.GetStr(i, DataDefine.Furnishing_Furnishing_Name);
            info.mObjName = mTableData.GetStr(i, DataDefine.Furnishing_Furnishing_ObjName);
            info.mEffectType = (EFurnitureEffectType)mTableData.GetInt(i, DataDefine.Furnishing_Furnishing_EffectType);
            info.mEffect = mTableData.GetFloat(i, DataDefine.Furnishing_Furnishing_Effect);
            info.mDefaultHas = mTableData.GetInt(i, DataDefine.Furnishing_Furnishing_DefaultHas) == 1;

            mObjNameDicInfo[info.mObjName] = info;
            if(!info.mDefaultHas)
                mListForSale.Add(info);
            mDicInfo[info.mId] = info;
        }
    }

    public List<ObjTabletFurnishingInfo> GetAllFurnishingForSale()     
    {
        //Debug.LogError("-----mListForSale---------:" + mListForSale.Count);
        return mListForSale;
    }

    public ObjTabletFurnishingInfo GetFurnishingInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];
        return null;
    }

    public ObjTabletFurnishingInfo GetFurnishingInfoByObjName(string _objName)
    {
        if (null != mObjNameDicInfo && mObjNameDicInfo.ContainsKey(_objName))
            return mObjNameDicInfo[_objName];
        return null;
    }
}
#endregion

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
        //public int mExp;
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

#region Gametype
public class TabletGametypeInfo : TableData
{
    public readonly string sFilePath = "tGametype";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletGametypeInfo
    {
        public int mId;
        public string mName;
        public string mIconName;
        public int mCoreplayType;
        public int mLev;
        public float mSetting1;
        public float mSetting2;
        public float mSetting3;
        public float mSetting4;
        public float mSetting5;
        public float mSetting6;
        public int mIncome;
        public int mLevUpFans;
        public int mLevMaxFans;
        public string mReward;
        public string mRewardDesc;
        public List<int> mRewardRegion;
        public int mRewardTopic;
        public string mRewardEmployeeId;
        public int mRewardCorePlayId;

    }
    Dictionary<string, ObjTabletGametypeInfo> mDicInfo;
    Dictionary<int, ObjTabletGametypeInfo> mDicGameTypeInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<string, ObjTabletGametypeInfo>();
        mDicGameTypeInfo = new Dictionary<int, ObjTabletGametypeInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletGametypeInfo info = new ObjTabletGametypeInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Game_Gametype_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Game_Gametype_Name);
            info.mIconName = mTableData.GetStr(i, DataDefine.Game_Gametype_Icon);
            info.mCoreplayType = mTableData.GetInt(i, DataDefine.Game_Gametype_Type);
            info.mLev = mTableData.GetInt(i, DataDefine.Game_Gametype_Lev);
            info.mSetting1 = mTableData.GetFloat(i, DataDefine.Game_Gametype_Setting1);
            info.mSetting2 = mTableData.GetFloat(i, DataDefine.Game_Gametype_Setting2);
            info.mSetting3 = mTableData.GetFloat(i, DataDefine.Game_Gametype_Setting3);
            info.mSetting4 = mTableData.GetFloat(i, DataDefine.Game_Gametype_Setting4);
            info.mSetting5 = mTableData.GetFloat(i, DataDefine.Game_Gametype_Setting5);
            info.mSetting6 = mTableData.GetFloat(i, DataDefine.Game_Gametype_Setting6);
            info.mIncome = mTableData.GetInt(i, DataDefine.Game_Gametype_Income);
            info.mLevUpFans = mTableData.GetInt(i, DataDefine.Game_Gametype_LevFans);
            info.mLevMaxFans = mTableData.GetInt(i, DataDefine.Game_Gametype_TypeMaxFans);

            info.mReward = mTableData.GetStr(i, DataDefine.Game_Gametype_Reward);
            info.mRewardDesc = mTableData.GetStr(i, DataDefine.Game_Gametype_RewardDesc);

            info.mRewardRegion = DataParseUtils.GetIntCompositeData(mTableData.GetStr(i, DataDefine.Game_Gametype_RewardRegion));
            info.mRewardTopic = mTableData.GetInt(i, DataDefine.Game_Gametype_RewardTopic);
            info.mRewardEmployeeId = mTableData.GetStr(i, DataDefine.Game_Gametype_RewardEmployee); 
            info.mRewardCorePlayId = mTableData.GetInt(i, DataDefine.Game_Gametype_RewardCorePlay);

            string key = info.mCoreplayType + "_" + info.mLev;
            mDicInfo[key] = info;
            mDicGameTypeInfo[info.mId] = info;
        }
    }

    public ObjTabletGametypeInfo GetTabletGametypeInfoById(int _id)
    {
        if (null != mDicGameTypeInfo && mDicGameTypeInfo.ContainsKey(_id))
            return mDicGameTypeInfo[_id];

        return null;
    }

    public ObjTabletGametypeInfo GetTabletGametypeInfoByIdAndLev(int _coreplayId,int _lev)
    {
        string key = _coreplayId + "_" + _lev;
        if (null != mDicInfo && mDicInfo.ContainsKey(key))
            return mDicInfo[key];

        return null;
    }
}
#endregion

#region RoleActionsEffect
public class TabletRoleActionsEffectInfo : TableData
{
    public readonly string sFilePath = "rRoleActionsEffect";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletRoleActionsEffectInfo
    {
        public int mId;
        public string mName;
        public int mType;
        public int mRoomId;
        public int mEnergyCost;
        public string mDesc;
        public E_EmployeeMentalityType mCleanState;
    }
    Dictionary<int, ObjTabletRoleActionsEffectInfo> mDicInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjTabletRoleActionsEffectInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletRoleActionsEffectInfo info = new ObjTabletRoleActionsEffectInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Role_RoleActionsEffect_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Role_RoleActionsEffect_Name);
            info.mType = mTableData.GetInt(i, DataDefine.Role_RoleActionsEffect_Type);
            info.mRoomId = mTableData.GetInt(i, DataDefine.Role_RoleActionsEffect_RoomId);
            //info.mEnergyCost = mTableData.GetInt(i, DataDefine.Role_RoleActionsEffect_EnergyCost);
            info.mDesc = mTableData.GetStr(i, DataDefine.Role_RoleActionsEffect_Desc);
            info.mCleanState = (E_EmployeeMentalityType)mTableData.GetInt(i, DataDefine.Role_RoleActionsEffect_CleanBadState);


            //Debug.LogError("---info.mDesc--:" + info.mDesc);
            mDicInfo[info.mId] = info;
        }
    }
    public ObjTabletRoleActionsEffectInfo GetTabletRoleActionsEffectInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }
}

#endregion

#region gamepoint

public class TabletGamePointInfo : TableData
{
    public readonly string sFilePath = "tMainPoints";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletGamePointInfo
    {
        public int mId;
        public List<string> mDesignerContent;
        public List<string> mProgrammerContent;
        public List<string> mArtContent;

        public int mDesignerPress;
        public int mProgrammerPress;
        public int mArtPress;

    }
    Dictionary<int, ObjTabletGamePointInfo> mDicInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjTabletGamePointInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletGamePointInfo info = new ObjTabletGamePointInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Game_MainPoints_GameTypeId);
            info.mDesignerContent = DataParseUtils.GetStringCompositeData(mTableData.GetStr(i, DataDefine.Game_MainPoints_DesignerContent));
            info.mProgrammerContent = DataParseUtils.GetStringCompositeData(mTableData.GetStr(i, DataDefine.Game_MainPoints_ProgrammerContent));
            info.mArtContent = DataParseUtils.GetStringCompositeData(mTableData.GetStr(i, DataDefine.Game_MainPoints_ArtContent));

            info.mDesignerPress = mTableData.GetInt(i, DataDefine.Game_MainPoints_DesignerPress);
            info.mProgrammerPress = mTableData.GetInt(i, DataDefine.Game_MainPoints_ProgrammerPress);
            info.mArtPress = mTableData.GetInt(i, DataDefine.Game_MainPoints_ArtPress);


            mDicInfo[info.mId] = info;
        }
    }
    public ObjTabletGamePointInfo GetTabletGamePointInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }
}
#endregion

#region BossActiveSkills
public class TabletBossActiveSkillsInfo : TableData
{
    public readonly string sFilePath = "tBossActiveSkills";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletBossActiveSkillsInfo
    {
        public EActiveSkillType mId;
        public string mName;
        public string mIconName;

        public string mDesc;

        //public int mLazy;
        //public int mAnxious;
        //public int mIrritability;
        public int mPress;
        public int mStrength;
        public int mCostMoney;
    }

    Dictionary<EActiveSkillType, ObjTabletBossActiveSkillsInfo> mDicInfo;
    List<ObjTabletBossActiveSkillsInfo> mListAllInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<EActiveSkillType, ObjTabletBossActiveSkillsInfo>();
        mListAllInfo = new List<ObjTabletBossActiveSkillsInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletBossActiveSkillsInfo info = new ObjTabletBossActiveSkillsInfo();
            info.mId = (EActiveSkillType)mTableData.GetInt(i, DataDefine.Role_BossActiveSkills_Id);
            info.mName = mTableData.GetStr(i, DataDefine.Role_BossActiveSkills_Name);
            info.mIconName = mTableData.GetStr(i, DataDefine.Role_BossActiveSkills_IconName);
            info.mDesc = mTableData.GetStr(i, DataDefine.Role_BossActiveSkills_Desc);

            //info.mLazy = mTableData.GetInt(i, DataDefine.Role_BossActiveSkills_Lazy);
            //info.mAnxious = mTableData.GetInt(i, DataDefine.Role_BossActiveSkills_Anxious);
            //info.mIrritability = mTableData.GetInt(i, DataDefine.Role_BossActiveSkills_Irritability);
            info.mPress = mTableData.GetInt(i, DataDefine.Role_BossActiveSkills_Press);
            info.mStrength = mTableData.GetInt(i, DataDefine.Role_BossActiveSkills_Strength);

            info.mCostMoney = mTableData.GetInt(i, DataDefine.Role_BossActiveSkills_CostMoney);


            mDicInfo[info.mId] = info;
            mListAllInfo.Add(info);
        }
    }

    public ObjTabletBossActiveSkillsInfo GetBossActiveSkillsInfoById(EActiveSkillType _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];
        return null;
    }
    public List<ObjTabletBossActiveSkillsInfo> GetAllBossActiveSkillsInfo()
    {
        return mListAllInfo;
    }
}

#endregion

#region OperateEvent
public class TabletOperateEventInfo : TableData
{
    public readonly string sFilePath = "tOperateEvent";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletOperateEventInfo
    {
        public int mId;
        public string mDesc;
        public string mChoiceA;
        public string mChoiceB;
        public string mResultA;
        public string mResultB;
    }

    Dictionary<int, ObjTabletOperateEventInfo> mDicInfo;
    List<ObjTabletOperateEventInfo> mListAllInfo;

    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjTabletOperateEventInfo>();
        mListAllInfo = new List<ObjTabletOperateEventInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletOperateEventInfo info = new ObjTabletOperateEventInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Event_OperateEvent_Id);
            info.mDesc = mTableData.GetStr(i, DataDefine.Event_OperateEvent_Desc);
            info.mChoiceA = mTableData.GetStr(i, DataDefine.Event_OperateEvent_ChoiceA);
            info.mChoiceB = mTableData.GetStr(i, DataDefine.Event_OperateEvent_ChoiceB);

            info.mResultA = mTableData.GetStr(i, DataDefine.Event_OperateEvent_ResultA);
            info.mResultB = mTableData.GetStr(i, DataDefine.Event_OperateEvent_ResultB);

            mDicInfo[info.mId] = info;
            mListAllInfo.Add(info);
        }
    }

    public List<ObjTabletOperateEventInfo> GetAllEvent()
    {
        return mListAllInfo;
    }

    public ObjTabletOperateEventInfo GetEventInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }
}
#endregion

#region die result
public class TabletDieReportInfo : TableData
{
    public readonly string sFilePath = "tDieResult";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletDieReportInfo
    {
        public int mId;
        public string mDesc;
    }
    List<ObjTabletDieReportInfo> mListAllInfo;
    Dictionary<int, ObjTabletDieReportInfo> mDicInfo;
    protected override void _ParseData()
    {
     
        mListAllInfo = new List<ObjTabletDieReportInfo>();
        mDicInfo = new Dictionary<int, ObjTabletDieReportInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletDieReportInfo info = new ObjTabletDieReportInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Event_DieResult_Id);
            info.mDesc = mTableData.GetStr(i, DataDefine.Event_DieResult_Desc);

            mListAllInfo.Add(info);
            mDicInfo[info.mId] = info;
        }
    }

    public ObjTabletDieReportInfo GetRandomResult()
    {
        int index = Random.Range(0, mListAllInfo.Count);
        return mListAllInfo[index];
    }


    public ObjTabletDieReportInfo GetDieReportInfoById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id];

        return null;
    }
}
#endregion

#region CommentType
public class TabletCommentTypetInfo : TableData
{
    public readonly string sFilePath = "tCommentType";
    protected override string GetPath()
    {
        return sFilePath;
    }

    public class ObjTabletCommentTypetInfo
    {
        public int mId;
        public List<string> mContent;
    }

    Dictionary<int, ObjTabletCommentTypetInfo> mDicInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjTabletCommentTypetInfo>();     
       
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletCommentTypetInfo info = new ObjTabletCommentTypetInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Event_CommentType_Type);
            info.mContent = new List<string>();
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentType_Comment1));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentType_Comment2));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentType_Comment3));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentType_Comment4));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentType_Comment5));


            mDicInfo[info.mId] = info;
        }
    }

    public List<string> GetCommentTypetContentById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id].mContent;
        return null;
    }
}
#endregion

#region CommentTopic
public class TabletCommentTopicInfo : TableData
{
    public readonly string sFilePath = "tCommentTopic";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletCommentTopicInfo
    {
        public int mId;
        public List<string> mContent;
    }
    Dictionary<int, ObjTabletCommentTopicInfo> mDicInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjTabletCommentTopicInfo>();

        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletCommentTopicInfo info = new ObjTabletCommentTopicInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Event_CommentTopic_TopicId);
            info.mContent = new List<string>();
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentTopic_Comment1));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentTopic_Comment2));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentTopic_Comment3));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_CommentTopic_Comment4));
           

            mDicInfo[info.mId] = info;
        }
    }
    public List<string> GetCommentTopicById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id].mContent;
        return null;
    }
}
#endregion

#region score
public class TabletCommentScoreInfo : TableData
{
    public readonly string sFilePath = "tGameScore";
    protected override string GetPath()
    {
        return sFilePath;
    }
    public class ObjTabletCommentScoreInfo
    {
        public int mId;
        public List<string> mContent;
    }
    Dictionary<int, ObjTabletCommentScoreInfo> mDicInfo;
    protected override void _ParseData()
    {
        mDicInfo = new Dictionary<int, ObjTabletCommentScoreInfo>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            ObjTabletCommentScoreInfo info = new ObjTabletCommentScoreInfo();
            info.mId = mTableData.GetInt(i, DataDefine.Event_GameScore_ScoreType);
            info.mContent = new List<string>();
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_GameScore_Comment1));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_GameScore_Comment2));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_GameScore_Comment3));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_GameScore_Comment4));
            info.mContent.Add(mTableData.GetStr(i, DataDefine.Event_GameScore_Comment5));

            mDicInfo[info.mId] = info;
        }
    }

    public List<string> GetCommentScoreById(int _id)
    {
        if (null != mDicInfo && mDicInfo.ContainsKey(_id))
            return mDicInfo[_id].mContent;
        return null;
    }
}

#endregion

#region dirtyword
public class TabletDirtyword : TableData
{
    public readonly string sFilePath = "tDirtyWords";
    protected override string GetPath()
    {
        return sFilePath;
    }
    List<string> allDirtyWord = new List<string>();
    protected override void _ParseData()
    {
        allDirtyWord = new List<string>();
        for (int i = 0; i < mTableData._nRows; i++)
        {
            allDirtyWord.Add(mTableData.GetStr(i, DataDefine.DirtyWords_DirtyWords_Content));
        }
    }
    public List<string> GetDirtyWordList()
    {
        return allDirtyWord;
    }
}
#endregion