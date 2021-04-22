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

    //data after read
    public TableGameProperty m_TableGameProperty;
    public TableRoleInfoConfig mTableRoleInfoConfig;
    //public TableGameTypeInfoConfig mTableGameTypeInfoConfig;
    public TableGameContentInfoConfig mTableGameContentInfoConfig;


    //public TableCommonEvent             mTableCommonEvent;
    //public TableSpecEvent               mTableSpecEvent;
    //public TableRolemission             mTableRolemission;
    //public TableRandomEvent             mTableRandomEvent;
    //public TableGameFeatures mTableGameFeatures;
    //public TableCompanyTalent           mTableCompanyTalent;

    //public TableGamePlatform mTableGamePlatform;
    //public TableRoleAction              mTableRoleAction;
    //public TableBossStory mTableBossStory;
    public TableBossInfo mTableBossInfo;
    //public TableEmployeeStoryInfo mTableEmployeeStoryInfo;
    public TableWorldMapInfo mTableWorldMapInfo;
    public TableSpreadTypeInfo mTableSpreadTypeInfo;
    public TableFansInfo mTableFansInfo;
    //public TableEmployeeGoap mTableEmployeeGoap;
    //public TableEmployeeSalary mTableEmployeeSalary;
    //public TableEventBuff               mTableEventBuff;
    //public TableGameTalent mTableGameTalent;
    public TableCoreGameplay mTableCoreGameplay;
    //public TableRoleLevup mTableRoleLevup;
    public TableRooms mTableRooms;
    //public TableGameTech mTableGameTech;
    //public TableCombinationContentStyle mTableCombinationContentStyle;
    //public TableCombinationContentSetting mTableCombinationContentSetting;
    //public TableSettingContentInfo mTableSettingContentInfo;
    //public TableContentSettingPlayerTypeInfo mTableContentSettingPlayerTypeInfo;
    //public TableContentSettingPlatformInfo mTableContentSettingPlatformInfo;
    public TableRoleItemAction mTableRoleAction;
    public TableHomeFurnishingConfigInfo mTableHomeFurnishingConfigInfo;
    public TablePlayableGamesConfigInfo mTablePlayableGamesConfigInfo;
    public TableLiveBroadcastConfigInfo mTableLiveBroadcastConfigInfo;
    public TableComicBooksConfigInfo mTableComicBooksConfigInfo;
    public TableBoardGamesConfigInfo mTableBoardGamesConfigInfo;
    public TableTakeOutFoodConfigInfo mTableTakeOutFoodConfigInfo;
    public TableSnacksDrinkConfigInfo mTableSnacksDrinkConfigInfo;
    //public TableCoreplaySettingConfigInfo mTableCoreplaySettingConfigInfo;
    //public TableCardConfigInfo          mTableCardConfigInfo;
    //public TableCompanyExpConfigInfo    mTableCompanyExpConfigInfo;
    public TableOfficeLayoutWallConfigInfo mTableOfficeLayoutWallConfigInfo;
    //public TableOutsourcingConfigInfo mTableOutsourcingConfigInfo;
    public TableInteractiveInfo mTableInteractiveInfo;
    //public TableTalentExpInfo           mTableTalentExpInfo;

    //public TableArtworklordInfo mTableArtworklordInfo;
    //public TableMilestoneInfo           mTableMilestoneInfo;
    public TableRoleExpInfo mTableRoleExpInfo;
    //public TableContentExpInfo mTableContentExpInfo;
    //public TableGameplayLevUpInfo       mTableGameplayLevUpInfo;
    //public TableArtLevUpInfo mTableArtLevUpInfo;
    //public TableTechLevUpInfo mTableTechLevUpInfo;
    //public TableGameplayMilestoneInfo   mTableGameplayMilestoneInfo;
    //public TableQualityMilestoneInfo    mTableQualityMilestoneInfo;
    //public TableIncomeMilestoneInfo     mTableIncomeMilestoneInfo;
    //public TableProjectProgressEventInfo mTableProjectProgressEventInfo;
    public TableEmployeeEventInfo mTableEmployeeEventInfo;
    //public TableMilestoneUnLockInfo     mTableMilestoneUnLockInfo;
    public TablePayRiseEventInfo mTablePayRiseEventInfo;
    //public TableArtPeripheryInfo        mTableArtPeripheryInfo;
    public TableEmployeePayRiseInfo mTableEmployeePayRiseInfo;
    public TableFireEmployeeInfo mTableFireEmployeeInfo;
    //public TableMilestonePrestigeInfo   mTableMilestonePrestigeInfo;
    //public TableGameMaterialInfo        mTableGameMaterialInfo;
    public TableReduceByAgeInfo mTableReduceByAgeInfo;
    //public TableProjectGetFansInfo      mTableProjectGetFansInfo;
    //public TableFansUnLockInfo mTableFansUnLockInfo;
    //public TableRoleActionInfo mTableRoleActionInfo;
    public TableRoleBadStateInfo mTableRoleBadStateInfo;
    public TableAtmosphereInfo mTableAtmosphereInfo;
    public TableRolePassiveSkillsInfo mTableRolePassiveSkillsInfo;
    public TableWorldGameInfo mTableWorldGameInfo;
    public TabletGameShowShowcaseInfo mTabletGameShowShowcaseInfo;
    public TabletGameShowShowcaseLogoInfo mTabletGameShowShowcaseLogoInfo;
    public TabletGameShowShowcaseBannerInfo mTabletGameShowShowcaseBannerInfo;
    public TabletGameShowShowcaseYiLabaoInfo mTabletGameShowShowcaseLiLaBaoInfo;
    public TabletGameShowStatueInfo mTabletGameShowStatueInfo;
    public TabletGameShowHaiBaoInfo mTabletGameShowHaiBaoInfo;
    public TabletIncomeInfo mTabletIncomeInfo;
    public TablePublisherInfo mTablePublisherInfo;
    public TabletNpcAppraiseInfo mTabletNpcAppraiseInfo;
    public TabletRoleActiveSkillInfo mTabletRoleActiveSkillInfo;
    public TabletGameTalentInfo mTabletGameTalentInfo;
    public TabletFurnishingInfo mTabletFurnishingInfo;
    public TabletDutiesInfo mTabletDutiesInfo;
    public TabletBossDutiesInfo mTabletBossDutiesInfo;
    public TabletBossDutiesUnlockInfo mTabletBossDutiesUnlockInfo;
    public TabletBossDutiesUnlockItemInfo mTabletBossDutiesUnlockItemInfo;
    public TabletGametypeInfo mTabletGametypeInfo;
    public TabletRoleActionsEffectInfo mTabletRoleActionsEffectInfo;

    public TabletGamePointInfo mTabletGamePointInfo;
    public TabletBossActiveSkillsInfo mTabletBossActiveSkillsInfo;
    public TabletOperateEventInfo mTabletOperateEventInfo;

    public TabletDieReportInfo mTabletDieReportInfo;
    public TabletCommentTypetInfo mTabletCommentTypetInfo;
    public TabletCommentTopicInfo mTabletCommentTopicInfo;
    public TabletCommentScoreInfo mTabletCommentScoreInfo;
    public TabletDirtyword mTabletDirtyword;

    public bool sInited = false;
#if !(UNITY_WP8 || UNITY_METRO)
    Thread mReadThread = null;
    int mThreadCount = 0;
#endif

    public void Init()
    {
        if (!sInited)
        {
            InitGameProperty();
            sInited = true;
        }
    }

    public void InitGameProperty()
    {
        if (null == m_TableGameProperty)
        {
            m_TableGameProperty = new TableGameProperty();
            m_TableGameProperty.ReadTable();
            m_TableGameProperty.ParseData();
        }
    }

    public TableRoleInfoConfig.ObjRoleConfigInfo GetRoleInfoById(string _id)
    {
        if (null == mTableRoleInfoConfig)
        {
            mTableRoleInfoConfig = new TableRoleInfoConfig();
            mTableRoleInfoConfig.ReadTable();
            mTableRoleInfoConfig.ParseData();
        }

        return mTableRoleInfoConfig.GetRoleInfoById(_id);
    }

    public List<TableRoleInfoConfig.ObjRoleConfigInfo> GetAllRoleInfoByHireLev(int _hireLev)
    {
        if (null == mTableRoleInfoConfig)
        {
            mTableRoleInfoConfig = new TableRoleInfoConfig();
            mTableRoleInfoConfig.ReadTable();
            mTableRoleInfoConfig.ParseData();
        }
        return mTableRoleInfoConfig.GetAllRoleInfoByHireLev(_hireLev);
    }

    public List<TableRoleInfoConfig.ObjRoleConfigInfo> GetAllRoleInfo()
    {
        if (null == mTableRoleInfoConfig)
        {
            mTableRoleInfoConfig = new TableRoleInfoConfig();
            mTableRoleInfoConfig.ReadTable();
            mTableRoleInfoConfig.ParseData();
        }
        return mTableRoleInfoConfig.GetAllRoleInfo();
    }

    public List<TableGameContentInfoConfig.ObjGameContentConfigInfo> GetAllGameContent()
    {
        if (null == mTableGameContentInfoConfig)
        {
            mTableGameContentInfoConfig = new TableGameContentInfoConfig();
            mTableGameContentInfoConfig.ReadTable();
            mTableGameContentInfoConfig.ParseData();
        }

        return mTableGameContentInfoConfig.GetAllGameContent();
    }

    public TableGameContentInfoConfig.ObjGameContentConfigInfo GetGameContentInfoById(int _id)
    {
        if (null == mTableGameContentInfoConfig)
        {
            mTableGameContentInfoConfig = new TableGameContentInfoConfig();
            mTableGameContentInfoConfig.ReadTable();
            mTableGameContentInfoConfig.ParseData();
        }
        return mTableGameContentInfoConfig.GetGameContentInfoById(_id);
    }

    public List<TableGameContentInfoConfig.ObjGameContentConfigInfo> GetGameContentConfigInfoByType(ETopiclType _type)
    {
        if (null == mTableGameContentInfoConfig)
        {
            mTableGameContentInfoConfig = new TableGameContentInfoConfig();
            mTableGameContentInfoConfig.ReadTable();
            mTableGameContentInfoConfig.ParseData();
        }
        return mTableGameContentInfoConfig.GetGameContentConfigInfoByType(_type);
    }


    public TableBossInfo.ObjBossInfo GetBossInfoById(string _id)
    {
        if (null == mTableBossInfo)
        {
            mTableBossInfo = new TableBossInfo();
            mTableBossInfo.ReadTable();
            mTableBossInfo.ParseData();
        }
        return mTableBossInfo.GetBossById(_id);
    }
    public TableWorldMapInfo.ObjWorldMapInfo GetWorldMapInfoById(EWorldSubregion _id)
    {
        if (null == mTableWorldMapInfo)
        {
            mTableWorldMapInfo = new TableWorldMapInfo();
            mTableWorldMapInfo.ReadTable();
            mTableWorldMapInfo.ParseData();
        }

        return mTableWorldMapInfo.GetWorldMapInfoById(_id);
    }


    public List<TableWorldMapInfo.ObjWorldMapInfo> GetAllWorldMapInfo()
    {
        if (null == mTableWorldMapInfo)
        {
            mTableWorldMapInfo = new TableWorldMapInfo();
            mTableWorldMapInfo.ReadTable();
            mTableWorldMapInfo.ParseData();
        }
        return mTableWorldMapInfo.GetAllWorldMapInfo();
    }
    public List<TableSpreadTypeInfo.ObjSpreadTypeInfo> GetAllSpreadType()
    {
        if (null == mTableSpreadTypeInfo)
        {
            mTableSpreadTypeInfo = new TableSpreadTypeInfo();
            mTableSpreadTypeInfo.ReadTable();
            mTableSpreadTypeInfo.ParseData();
        }

        return mTableSpreadTypeInfo.GetAllSpreadType();
    }
    public TableSpreadTypeInfo.ObjSpreadTypeInfo GetSpreadTypeInfoById(ESpreadType _id)
    {
        if (null == mTableSpreadTypeInfo)
        {
            mTableSpreadTypeInfo = new TableSpreadTypeInfo();
            mTableSpreadTypeInfo.ReadTable();
            mTableSpreadTypeInfo.ParseData();
        }

        return mTableSpreadTypeInfo.GetpreadTypeInfoById(_id);
    }

    public TableFansInfo.ObjFansInfo GetFansInfoById(int _lev)
    {
        if (null == mTableFansInfo)
        {
            mTableFansInfo = new TableFansInfo();
            mTableFansInfo.ReadTable();
            mTableFansInfo.ParseData();
        }
        return mTableFansInfo.GetFansInfoByLev(_lev);
    }

    //public TableEmployeeGoap.ObjRoleGoapInfo GetEmployeeGOAPInfoById(int _id)
    //{
    //    if (null == mTableEmployeeGoap)
    //    {
    //        mTableEmployeeGoap = new TableEmployeeGoap();
    //        mTableEmployeeGoap.ReadTable();
    //        mTableEmployeeGoap.ParseData();
    //    }
    //    return mTableEmployeeGoap.GetRoleGoapById(_id);
    //}

    //public int GetSalaryByAbility(int _ability)
    //{
    //    if (null == mTableEmployeeSalary)
    //    {
    //        mTableEmployeeSalary = new TableEmployeeSalary();
    //        mTableEmployeeSalary.ReadTable();
    //        mTableEmployeeSalary.ParseData();
    //    }
    //    return mTableEmployeeSalary.GetSalaryByAbility(_ability);
    //}




    public TableCoreGameplay.ObjCoreGameplayConfig GetCoreGameplayConfigById(int _id)
    {
        if (null == mTableCoreGameplay)
        {
            mTableCoreGameplay = new TableCoreGameplay();
            mTableCoreGameplay.ReadTable();
            mTableCoreGameplay.ParseData();
        }
        return mTableCoreGameplay.GetCoreGameplayConfigById(_id);
    }

    public List<TableCoreGameplay.ObjCoreGameplayConfig> GetCoreGameplayConfigListByGameTypeAndEmployeeNum(int _type)
    {
        if (null == mTableCoreGameplay)
        {
            mTableCoreGameplay = new TableCoreGameplay();
            mTableCoreGameplay.ReadTable();
            mTableCoreGameplay.ParseData();
        }
        return mTableCoreGameplay.GetCoreGameplayConfigListByType(_type);
    }

    public List<TableCoreGameplay.ObjCoreGameplayConfig> GetAllCoreGameplayConfig()
    {
        if (null == mTableCoreGameplay)
        {
            mTableCoreGameplay = new TableCoreGameplay();
            mTableCoreGameplay.ReadTable();
            mTableCoreGameplay.ParseData();
        }
        return mTableCoreGameplay.GetAllData();
    }
    public TableRooms.ObjRoomConfigInfo GetRoomInfoById(int _id)
    {
        if (null == mTableRooms)
        {
            mTableRooms = new TableRooms();
            mTableRooms.ReadTable();
            mTableRooms.ParseData();
        }

        return mTableRooms.GetRoomInfoById(_id);
    }

    public TableRooms.ObjRoomConfigInfo GetRoomInfoByTypeAndLev(ERoomType _type, int _lev)
    {
        if (null == mTableRooms)
        {
            mTableRooms = new TableRooms();
            mTableRooms.ReadTable();
            mTableRooms.ParseData();
        }

        return mTableRooms.GetRoomInfoByTypeAndLev(_type, _lev);
    }

    public TableHomeFurnishingConfigInfo.ObjHomeFurnishingConfigInfo GetHomeFurnishingInfoById(int _id)
    {
        if (null == mTableHomeFurnishingConfigInfo)
        {
            mTableHomeFurnishingConfigInfo = new TableHomeFurnishingConfigInfo();
            mTableHomeFurnishingConfigInfo.ReadTable();
            mTableHomeFurnishingConfigInfo.ParseData();
        }
        return mTableHomeFurnishingConfigInfo.GetHomeFurnishingInfoById(_id);
    }
    public TableHomeFurnishingConfigInfo.ObjHomeFurnishingConfigInfo GetHomeFurnishingInfoByObjName(string _objName)
    {
        if (null == mTableHomeFurnishingConfigInfo)
        {
            mTableHomeFurnishingConfigInfo = new TableHomeFurnishingConfigInfo();
            mTableHomeFurnishingConfigInfo.ReadTable();
            mTableHomeFurnishingConfigInfo.ParseData();
        }
        return mTableHomeFurnishingConfigInfo.GetHomeFurnishingInfoByObjName(_objName);
    }

    public List<TableHomeFurnishingConfigInfo.ObjHomeFurnishingConfigInfo> GetHomeFurnishingListByType(EHomeFurnishingType _type)
    {
        if (null == mTableHomeFurnishingConfigInfo)
        {
            mTableHomeFurnishingConfigInfo = new TableHomeFurnishingConfigInfo();
            mTableHomeFurnishingConfigInfo.ReadTable();
            mTableHomeFurnishingConfigInfo.ParseData();
        }
        return mTableHomeFurnishingConfigInfo.GetHomeFurnishingListByType(_type);
    }

    public List<TableHomeFurnishingConfigInfo.ObjHomeFurnishingConfigInfo> GetAllHomeFurnishing()
    {
        if (null == mTableHomeFurnishingConfigInfo)
        {
            mTableHomeFurnishingConfigInfo = new TableHomeFurnishingConfigInfo();
            mTableHomeFurnishingConfigInfo.ReadTable();
            mTableHomeFurnishingConfigInfo.ParseData();
        }
        return mTableHomeFurnishingConfigInfo.GetAllHomeFurnishing();
    }

    public TableRoleItemAction.ObjRoleItemActionInfo GetActionInfoById(int _id)
    {
        if (null == mTableRoleAction)
        {
            mTableRoleAction = new TableRoleItemAction();
            mTableRoleAction.ReadTable();
            mTableRoleAction.ParseData();
        }

        return mTableRoleAction.GetActionInfoById(_id);
    }

    public List<TablePlayableGamesConfigInfo.ObjPlayableGamesConfigInfo> GetPlayableGamesByType(EPlayableGamesType _type)
    {
        if (null == mTablePlayableGamesConfigInfo)
        {
            mTablePlayableGamesConfigInfo = new TablePlayableGamesConfigInfo();
            mTablePlayableGamesConfigInfo.ReadTable();
            mTablePlayableGamesConfigInfo.ParseData();
        }

        return mTablePlayableGamesConfigInfo.GetListPlayableGamesByType(_type);
    }


    public TablePlayableGamesConfigInfo.ObjPlayableGamesConfigInfo GetPlayableGamesInfoById(int _id)
    {
        if (null == mTablePlayableGamesConfigInfo)
        {
            mTablePlayableGamesConfigInfo = new TablePlayableGamesConfigInfo();
            mTablePlayableGamesConfigInfo.ReadTable();
            mTablePlayableGamesConfigInfo.ParseData();
        }

        return mTablePlayableGamesConfigInfo.GetPlayableGamesInfoById(_id);
    }


    public List<TableLiveBroadcastConfigInfo.ObjLiveBroadcastConfigInfo> GetAllLiveBroadcast()
    {
        if (null == mTableLiveBroadcastConfigInfo)
        {
            mTableLiveBroadcastConfigInfo = new TableLiveBroadcastConfigInfo();
            mTableLiveBroadcastConfigInfo.ReadTable();
            mTableLiveBroadcastConfigInfo.ParseData();
        }

        return mTableLiveBroadcastConfigInfo.GetAllLiveBroadcast();
    }

    public TableLiveBroadcastConfigInfo.ObjLiveBroadcastConfigInfo GetLiveBroadcastInfoById(int _id)
    {
        if (null == mTableLiveBroadcastConfigInfo)
        {
            mTableLiveBroadcastConfigInfo = new TableLiveBroadcastConfigInfo();
            mTableLiveBroadcastConfigInfo.ReadTable();
            mTableLiveBroadcastConfigInfo.ParseData();
        }

        return mTableLiveBroadcastConfigInfo.GetLiveBroadcastInfoById(_id);
    }

    public List<TableComicBooksConfigInfo.ObjComicBooksConfigInfo> GetAllComicBooks()
    {
        if (null == mTableComicBooksConfigInfo)
        {
            mTableComicBooksConfigInfo = new TableComicBooksConfigInfo();
            mTableComicBooksConfigInfo.ReadTable();
            mTableComicBooksConfigInfo.ParseData();
        }
        return mTableComicBooksConfigInfo.GetAllComicBooks();
    }


    public TableComicBooksConfigInfo.ObjComicBooksConfigInfo GetComicBookInfoById(int _id)
    {
        if (null == mTableComicBooksConfigInfo)
        {
            mTableComicBooksConfigInfo = new TableComicBooksConfigInfo();
            mTableComicBooksConfigInfo.ReadTable();
            mTableComicBooksConfigInfo.ParseData();
        }
        return mTableComicBooksConfigInfo.GetComicBookInfoById(_id);
    }




    public List<TableBoardGamesConfigInfo.ObjBoardGamesConfigInfo> GetAllBoardGames()
    {
        if (null == mTableBoardGamesConfigInfo)
        {
            mTableBoardGamesConfigInfo = new TableBoardGamesConfigInfo();
            mTableBoardGamesConfigInfo.ReadTable();
            mTableBoardGamesConfigInfo.ParseData();
        }
        return mTableBoardGamesConfigInfo.GetAllBoardGames();
    }

    public List<TableTakeOutFoodConfigInfo.ObjTakeOutFoodConfigInfo> GetAllakeOutFood()
    {
        if (null == mTableTakeOutFoodConfigInfo)
        {
            mTableTakeOutFoodConfigInfo = new TableTakeOutFoodConfigInfo();
            mTableTakeOutFoodConfigInfo.ReadTable();
            mTableTakeOutFoodConfigInfo.ParseData();
        }
        return mTableTakeOutFoodConfigInfo.GetAllTakeOutFoodInfo();
    }

    public TableTakeOutFoodConfigInfo.ObjTakeOutFoodConfigInfo GetTakeOutFoodConfigInfoById(int _id)
    {
        if (null == mTableTakeOutFoodConfigInfo)
        {
            mTableTakeOutFoodConfigInfo = new TableTakeOutFoodConfigInfo();
            mTableTakeOutFoodConfigInfo.ReadTable();
            mTableTakeOutFoodConfigInfo.ParseData();
        }
        return mTableTakeOutFoodConfigInfo.GetTakeOutFoodConfigInfoById(_id);
    }

    /// <summary>
    /// //1:冰箱 2：贩卖机
    /// </summary>
    /// <param name="_type"></param>
    /// <returns></returns>
    public List<TableSnacksDrinkConfigInfo.ObjSnacksDrinkConfigInfo> GetAllSnacksDrinkInfo(int _type)
    {
        if (null == mTableSnacksDrinkConfigInfo)
        {
            mTableSnacksDrinkConfigInfo = new TableSnacksDrinkConfigInfo();
            mTableSnacksDrinkConfigInfo.ReadTable();
            mTableSnacksDrinkConfigInfo.ParseData();
        }
        return mTableSnacksDrinkConfigInfo.GetAllSnacksDrinkInfo(_type);
    }

    public TableSnacksDrinkConfigInfo.ObjSnacksDrinkConfigInfo GetSnacksDrinkInfoById(int _id)
    {
        if (null == mTableSnacksDrinkConfigInfo)
        {
            mTableSnacksDrinkConfigInfo = new TableSnacksDrinkConfigInfo();
            mTableSnacksDrinkConfigInfo.ReadTable();
            mTableSnacksDrinkConfigInfo.ParseData();
        }
        return mTableSnacksDrinkConfigInfo.GetSnacksDrinkConfigInfoById(_id);
    }



    public List<TableOfficeLayoutWallConfigInfo.ObjOfficeLayoutWallConfigInfo> GetExtendWallByLev(int _lev)
    {
        if (null == mTableOfficeLayoutWallConfigInfo)
        {
            mTableOfficeLayoutWallConfigInfo = new TableOfficeLayoutWallConfigInfo();
            mTableOfficeLayoutWallConfigInfo.ReadTable();
            mTableOfficeLayoutWallConfigInfo.ParseData();
        }

        return mTableOfficeLayoutWallConfigInfo.GetExtendWallInfoByLev(_lev);
    }


    //public List<TableOutsourcingConfigInfo.ObjOutsourcingConfigInfo> GetAllOutsourcingConfigList()
    //{
    //    if (null == mTableOutsourcingConfigInfo)
    //    {
    //        mTableOutsourcingConfigInfo = new TableOutsourcingConfigInfo();
    //        mTableOutsourcingConfigInfo.ReadTable();
    //        mTableOutsourcingConfigInfo.ParseData();
    //    }

    //    return mTableOutsourcingConfigInfo.GetAllOutsourcingConfigList();
    //}

    //public TableOutsourcingConfigInfo.ObjOutsourcingConfigInfo GetOutsourcingConfigInfoById(int _id)
    //{
    //    if (null == mTableOutsourcingConfigInfo)
    //    {
    //        mTableOutsourcingConfigInfo = new TableOutsourcingConfigInfo();
    //        mTableOutsourcingConfigInfo.ReadTable();
    //        mTableOutsourcingConfigInfo.ParseData();
    //    }

    //    return mTableOutsourcingConfigInfo.GetOutsourcingConfigInfoById(_id);
    //}

    //public TableInteractiveInfo.ObjInteractiveConfigInfo GetInteractiveConfigInfoById(int _id)
    //{
    //    if (null == mTableInteractiveInfo)
    //    {
    //        mTableInteractiveInfo = new TableInteractiveInfo();
    //        mTableInteractiveInfo.ReadTable();
    //        mTableInteractiveInfo.ParseData();
    //    }
    //    return mTableInteractiveInfo.GetInteractiveConfigInfoById(_id);
    //}

    //public int GetRoomRoleExpValueByRoomLev(int _lev)
    //{
    //    if (null == mTableRoomLevRoleExpInfo)
    //    {
    //        mTableRoomLevRoleExpInfo = new TableRoomLevRoleExpInfo();
    //        mTableRoomLevRoleExpInfo.ReadTable();
    //        mTableRoomLevRoleExpInfo.ParseData();
    //    }
    //    return mTableRoomLevRoleExpInfo.GetExpByRoomLev(_lev);
    //}

    //public List<TableProjectProgressEventInfo.ObjProjectProgressEvent> GetAllProjectProgressEventInfo()
    //{
    //    if (null == mTableProjectProgressEventInfo)
    //    {
    //        mTableProjectProgressEventInfo = new TableProjectProgressEventInfo();
    //        mTableProjectProgressEventInfo.ReadTable();
    //        mTableProjectProgressEventInfo.ParseData();
    //    }

    //    return mTableProjectProgressEventInfo.GetAllProjectProgressEvent();
    //}
    //public TableProjectProgressEventInfo.ObjProjectProgressEvent GetProjectProgressEventInfoById(int _id)
    //{
    //    if (null == mTableProjectProgressEventInfo)
    //    {
    //        mTableProjectProgressEventInfo = new TableProjectProgressEventInfo();
    //        mTableProjectProgressEventInfo.ReadTable();
    //        mTableProjectProgressEventInfo.ParseData();
    //    }
    //    return mTableProjectProgressEventInfo.GetProjectProgressEventById(_id);
    //}

    public TableEmployeeEventInfo.ObjEmployeeEventInfo GetEmployeeEventInfoById(int _id)
    {
        if (null == mTableEmployeeEventInfo)
        {
            mTableEmployeeEventInfo = new TableEmployeeEventInfo();
            mTableEmployeeEventInfo.ReadTable();
            mTableEmployeeEventInfo.ParseData();
        }

        return mTableEmployeeEventInfo.GetEmployeeEventInfoById(_id);
    }
    public List<TableEmployeeEventInfo.ObjEmployeeEventInfo> GetAllEmployeeEventInfo()
    {
        if (null == mTableEmployeeEventInfo)
        {
            mTableEmployeeEventInfo = new TableEmployeeEventInfo();
            mTableEmployeeEventInfo.ReadTable();
            mTableEmployeeEventInfo.ParseData();
        }

        return mTableEmployeeEventInfo.GetAllEmployeeEventInfo();
    }


    //public List<TableMilestoneUnLockInfo.ObjMilestoneUnLockInfo> GetAllMilestoneUnLockInfo()
    //{
    //    if (null == mTableMilestoneUnLockInfo)
    //    {
    //        mTableMilestoneUnLockInfo = new TableMilestoneUnLockInfo();
    //        mTableMilestoneUnLockInfo.ReadTable();
    //        mTableMilestoneUnLockInfo.ParseData();
    //    }

    //    return mTableMilestoneUnLockInfo.GetAllInfo();
    //}
    //public TableMilestoneUnLockInfo.ObjMilestoneUnLockInfo GetMilestoneUnLockInfoById(int _id)
    //{
    //    if (null == mTableMilestoneUnLockInfo)
    //    {
    //        mTableMilestoneUnLockInfo = new TableMilestoneUnLockInfo();
    //        mTableMilestoneUnLockInfo.ReadTable();
    //        mTableMilestoneUnLockInfo.ParseData();
    //    }

    //    return mTableMilestoneUnLockInfo.GetMilestoneUnLockInfoById(_id);
    //}
    public TablePayRiseEventInfo.ObjPayRiseEventInfo GetPayRiseEventInfoById(int _id)
    {
        if (null == mTablePayRiseEventInfo)
        {
            mTablePayRiseEventInfo = new TablePayRiseEventInfo();
            mTablePayRiseEventInfo.ReadTable();
            mTablePayRiseEventInfo.ParseData();
        }

        return mTablePayRiseEventInfo.GetPayRiseEventInfoById(_id);
    }

    public TablePayRiseEventInfo.ObjPayRiseEventInfo GetPayRiseEventInfoByValueSection(float _value)
    {
        if (null == mTablePayRiseEventInfo)
        {
            mTablePayRiseEventInfo = new TablePayRiseEventInfo();
            mTablePayRiseEventInfo.ReadTable();
            mTablePayRiseEventInfo.ParseData();
        }

        return mTablePayRiseEventInfo.GetPayRiseEventInfoByValue(_value);
    }

    //public TableArtPeripheryInfo.ObjArtPeripheryInfo GetArtPeripheryInfoById(int _id)
    //{
    //    if (null == mTableArtPeripheryInfo)
    //    {
    //        mTableArtPeripheryInfo = new TableArtPeripheryInfo();
    //        mTableArtPeripheryInfo.ReadTable();
    //        mTableArtPeripheryInfo.ParseData();
    //    }

    //    return mTableArtPeripheryInfo.GetArtPeripheryInfoById(_id);
    //}

    //public List<TableArtPeripheryInfo.ObjArtPeripheryInfo> GetAllArtPeripheryInfo()
    //{
    //    if (null == mTableArtPeripheryInfo)
    //    {
    //        mTableArtPeripheryInfo = new TableArtPeripheryInfo();
    //        mTableArtPeripheryInfo.ReadTable();
    //        mTableArtPeripheryInfo.ParseData();
    //    }

    //    return mTableArtPeripheryInfo.GetAllArtPeripheryInfo();
    //}

    public List<TableEmployeePayRiseInfo.ObjEmployeePayRiseInfo> GetAllPayRiseInfo()
    {
        if (null == mTableEmployeePayRiseInfo)
        {
            mTableEmployeePayRiseInfo = new TableEmployeePayRiseInfo();
            mTableEmployeePayRiseInfo.ReadTable();
            mTableEmployeePayRiseInfo.ParseData();
        }

        return mTableEmployeePayRiseInfo.GetAllPayRiseInfo();
    }

    public List<TableFireEmployeeInfo.ObjFireEmployeeInfo> GetAllFireEmployeeInfo()
    {
        if (null == mTableFireEmployeeInfo)
        {
            mTableFireEmployeeInfo = new TableFireEmployeeInfo();
            mTableFireEmployeeInfo.ReadTable();
            mTableFireEmployeeInfo.ParseData();
        }

        return mTableFireEmployeeInfo.GetAllFireInfo();
    }


    //public List<TableMilestonePrestigeInfo.ObjMilestonePrestigeInfo> GetAllMilestonePrestigeInfo()
    //{
    //    if (null == mTableMilestonePrestigeInfo)
    //    {
    //        mTableMilestonePrestigeInfo = new TableMilestonePrestigeInfo();
    //        mTableMilestonePrestigeInfo.ReadTable();
    //        mTableMilestonePrestigeInfo.ParseData();
    //    }

    //    return mTableMilestonePrestigeInfo.GetAllMilestonePrestigeInfo();
    //}

    //public TableMilestonePrestigeInfo.ObjMilestonePrestigeInfo GetMilestonePrestigeInfoById(int _id)
    //{
    //    if (null == mTableMilestonePrestigeInfo)
    //    {
    //        mTableMilestonePrestigeInfo = new TableMilestonePrestigeInfo();
    //        mTableMilestonePrestigeInfo.ReadTable();
    //        mTableMilestonePrestigeInfo.ParseData();
    //    }

    //    return mTableMilestonePrestigeInfo.GetMilestonePrestigeInfoById(_id);
    //}

    //public TableGameMaterialInfo.ObjGameMaterialInfo GetGameMaterialInfoById(int _id)
    //{
    //    if (null == mTableGameMaterialInfo)
    //    {
    //        mTableGameMaterialInfo = new TableGameMaterialInfo();
    //        mTableGameMaterialInfo.ReadTable();
    //        mTableGameMaterialInfo.ParseData();
    //    }
    //   return mTableGameMaterialInfo.GetGameMaterialInfoById(_id);
    //}

    //public List<TableGameMaterialInfo.ObjGameMaterialInfo> GetAllGameMaterialInfo()
    //{
    //    if (null == mTableGameMaterialInfo)
    //    {
    //        mTableGameMaterialInfo = new TableGameMaterialInfo();
    //        mTableGameMaterialInfo.ReadTable();
    //        mTableGameMaterialInfo.ParseData();
    //    }
    //    return mTableGameMaterialInfo.GetAllGameMaterialInfo();
    //}

    public TableReduceByAgeInfo.ObjReduceByAgeInfo GetReduceByAgeInfoByAge(int _age)
    {
        if (null == mTableReduceByAgeInfo)
        {
            mTableReduceByAgeInfo = new TableReduceByAgeInfo();
            mTableReduceByAgeInfo.ReadTable();
            mTableReduceByAgeInfo.ParseData();
        }
        return mTableReduceByAgeInfo.GetReduceByAgeInfoByAge(_age);
    }

    //public List<TableProjectGetFansInfo.ObjProjectGetFansInfo> GetAllProjectGetFansInfo()
    //{
    //    if (null == mTableProjectGetFansInfo)
    //    {
    //        mTableProjectGetFansInfo = new TableProjectGetFansInfo();
    //        mTableProjectGetFansInfo.ReadTable();
    //        mTableProjectGetFansInfo.ParseData();
    //    }

    //    return mTableProjectGetFansInfo.GetAllProjectGetFansInfo();
    //}

    //public TableProjectGetFansInfo.ObjProjectGetFansInfo GetProjectGetFansInfoById(int _id)
    //{
    //    if (null == mTableProjectGetFansInfo)
    //    {
    //        mTableProjectGetFansInfo = new TableProjectGetFansInfo();
    //        mTableProjectGetFansInfo.ReadTable();
    //        mTableProjectGetFansInfo.ParseData();
    //    }

    //    return mTableProjectGetFansInfo.GetProjectGetFansInfoById(_id);
    //}

    //public TableFansUnLockInfo.ObjFansUnlockInfo GetNextFanUnlockInfoByNums(int _num)
    //{
    //    if (null == mTableFansUnLockInfo)
    //    {
    //        mTableFansUnLockInfo = new TableFansUnLockInfo();
    //        mTableFansUnLockInfo.ReadTable();
    //        mTableFansUnLockInfo.ParseData();
    //    }

    //    return mTableFansUnLockInfo.GetNextFanUnlockInfoByNums(_num);
    //}
    //public TableFansUnLockInfo.ObjFansUnlockInfo GetCurrentFanUnlockInfoByNums(int _num)
    //{
    //    if (null == mTableFansUnLockInfo)
    //    {
    //        mTableFansUnLockInfo = new TableFansUnLockInfo();
    //        mTableFansUnLockInfo.ReadTable();
    //        mTableFansUnLockInfo.ParseData();
    //    }

    //    return mTableFansUnLockInfo.GetCurrentFanUnlockInfoByNums(_num);
    //}


    //public List<TableFansUnLockInfo.ObjFansUnlockInfo> GetAllFansUnlockInfo()
    //{
    //    if (null == mTableFansUnLockInfo)
    //    {
    //        mTableFansUnLockInfo = new TableFansUnLockInfo();
    //        mTableFansUnLockInfo.ReadTable();
    //        mTableFansUnLockInfo.ParseData();
    //    }

    //    return mTableFansUnLockInfo.GetAllFansUnlockInfo();
    //}

    //public TableRoleActionInfo.ObjRoleActionInfo GetRoleActionInfoById(ERoleActionTypeEnum _id)
    //{
    //    if (null == mTableRoleActionInfo)
    //    {
    //        mTableRoleActionInfo = new TableRoleActionInfo();
    //        mTableRoleActionInfo.ReadTable();
    //        mTableRoleActionInfo.ParseData();
    //    }

    //    return mTableRoleActionInfo.GetRoleActionInfoById(_id);
    //}

    public TableRoleBadStateInfo.ObjRoleBadStateInfo GetRoleBadStateInfo(int _id)
    {
        if (null == mTableRoleBadStateInfo)
        {
            mTableRoleBadStateInfo = new TableRoleBadStateInfo();
            mTableRoleBadStateInfo.ReadTable();
            mTableRoleBadStateInfo.ParseData();
        }

        return mTableRoleBadStateInfo.GetRoleBadStateInfo(_id);
    }

    public List<TableRoleBadStateInfo.ObjRoleBadStateInfo> GetRoleBadStateInfoByType(E_EmployeeMentalityType _typeId)
    {
        if (null == mTableRoleBadStateInfo)
        {
            mTableRoleBadStateInfo = new TableRoleBadStateInfo();
            mTableRoleBadStateInfo.ReadTable();
            mTableRoleBadStateInfo.ParseData();
        }

        return mTableRoleBadStateInfo.GetRoleBadStateInfoByType(_typeId);

    }

    public TableAtmosphereInfo.ObjAtmosphereInfo GetAtmosphereInfoByValue(int _value)
    {
        if (null == mTableAtmosphereInfo)
        {
            mTableAtmosphereInfo = new TableAtmosphereInfo();
            mTableAtmosphereInfo.ReadTable();
            mTableAtmosphereInfo.ParseData();
        }

        return mTableAtmosphereInfo.GetAtmosphereInfoByValue(_value);
    }



    public List<TableRolePassiveSkillsInfo.ObjRolePassiveSkillsInfo> GetAllRolePassiveSkills()
    {
        if (null == mTableRolePassiveSkillsInfo)
        {
            mTableRolePassiveSkillsInfo = new TableRolePassiveSkillsInfo();
            mTableRolePassiveSkillsInfo.ReadTable();
            mTableRolePassiveSkillsInfo.ParseData();
        }
        return mTableRolePassiveSkillsInfo.GetAllPassiveSkills();
    }

    public TableRolePassiveSkillsInfo.ObjRolePassiveSkillsInfo GetRolePassiveSkillsInfoById(int _id)
    {
        if (null == mTableRolePassiveSkillsInfo)
        {
            mTableRolePassiveSkillsInfo = new TableRolePassiveSkillsInfo();
            mTableRolePassiveSkillsInfo.ReadTable();
            mTableRolePassiveSkillsInfo.ParseData();
        }
        return mTableRolePassiveSkillsInfo.GetRolePassiveSkillsInfoById(_id);
    }

    public int GetRoleRandomGameTypeSkill()
    {
        if (null == mTableRolePassiveSkillsInfo)
        {
            mTableRolePassiveSkillsInfo = new TableRolePassiveSkillsInfo();
            mTableRolePassiveSkillsInfo.ReadTable();
            mTableRolePassiveSkillsInfo.ParseData();
        }
        return mTableRolePassiveSkillsInfo.GetRoleRandomGameTypeSkills();
    }
    public int GetRoleRandomTopicSkill()
    {
        if (null == mTableRolePassiveSkillsInfo)
        {
            mTableRolePassiveSkillsInfo = new TableRolePassiveSkillsInfo();
            mTableRolePassiveSkillsInfo.ReadTable();
            mTableRolePassiveSkillsInfo.ParseData();
        }
        return mTableRolePassiveSkillsInfo.GetRoleRandomTopicSkills();
    }


    public TableWorldGameInfo.ObjTableWorldGameInfo GetWorldGameInfoById(int _id)
    {
        if (null == mTableWorldGameInfo)
        {
            mTableWorldGameInfo = new TableWorldGameInfo();
            mTableWorldGameInfo.ReadTable();
            mTableWorldGameInfo.ParseData();
        }

        return mTableWorldGameInfo.GetWorldGameInfoById(_id);
    }

    public List<TableWorldGameInfo.ObjTableWorldGameInfo> GetWorldGameListByYear(int _year)
    {
        if (null == mTableWorldGameInfo)
        {
            mTableWorldGameInfo = new TableWorldGameInfo();
            mTableWorldGameInfo.ReadTable();
            mTableWorldGameInfo.ParseData();
        }
        return mTableWorldGameInfo.GetWorldGameListByYear(_year);
    }


    public List<TableWorldGameInfo.ObjTableWorldGameInfo> GetAllWorldGameInfo()
    {
        if (null == mTableWorldGameInfo)
        {
            mTableWorldGameInfo = new TableWorldGameInfo();
            mTableWorldGameInfo.ReadTable();
            mTableWorldGameInfo.ParseData();
        }
        return mTableWorldGameInfo.GetAllWorldGameInfo();
    }
    public List<TabletGameShowShowcaseInfo.ObjTableGameShowShowcaseInfo> GetShowcaseInfoByLev(int _lev)
    {
        if (null == mTabletGameShowShowcaseInfo)
        {
            mTabletGameShowShowcaseInfo = new TabletGameShowShowcaseInfo();
            mTabletGameShowShowcaseInfo.ReadTable();
            mTabletGameShowShowcaseInfo.ParseData();
        }
        return mTabletGameShowShowcaseInfo.GetShowcaseInfoByLev(_lev);
    }

    public List<TabletGameShowShowcaseLogoInfo.ObjTableGameShowShowcaseLogoInfo> GetAllShowcaseLogoInfo()
    {
        if (null == mTabletGameShowShowcaseLogoInfo)
        {
            mTabletGameShowShowcaseLogoInfo = new TabletGameShowShowcaseLogoInfo();
            mTabletGameShowShowcaseLogoInfo.ReadTable();
            mTabletGameShowShowcaseLogoInfo.ParseData();
        }
        return mTabletGameShowShowcaseLogoInfo.GetAllShowcaseLogoInfo();
    }

    public List<TabletGameShowShowcaseBannerInfo.ObjTableGameShowShowcaseBannerInfo> GetAllShowcaseBannerInfo()
    {
        if (null == mTabletGameShowShowcaseBannerInfo)
        {
            mTabletGameShowShowcaseBannerInfo = new TabletGameShowShowcaseBannerInfo();
            mTabletGameShowShowcaseBannerInfo.ReadTable();
            mTabletGameShowShowcaseBannerInfo.ParseData();
        }
        return mTabletGameShowShowcaseBannerInfo.GetAllShowcaseBannerInfo();
    }

    public List<TabletGameShowShowcaseYiLabaoInfo.ObjTableGameShowShowcaseYiLaBaoInfo> GetAllShowcaseYiLaBaoInfo(bool _ver)
    {
        if (null == mTabletGameShowShowcaseLiLaBaoInfo)
        {
            mTabletGameShowShowcaseLiLaBaoInfo = new TabletGameShowShowcaseYiLabaoInfo();
            mTabletGameShowShowcaseLiLaBaoInfo.ReadTable();
            mTabletGameShowShowcaseLiLaBaoInfo.ParseData();
        }
        return mTabletGameShowShowcaseLiLaBaoInfo.GetAllShowcaseYiLaBaoInfo(_ver);
    }

    public List<TabletGameShowStatueInfo.ObjTabletGameShowStatueInfo> GetAllGameShowStatueInfo()
    {
        if (null == mTabletGameShowStatueInfo)
        {
            mTabletGameShowStatueInfo = new TabletGameShowStatueInfo();
            mTabletGameShowStatueInfo.ReadTable();
            mTabletGameShowStatueInfo.ParseData();
        }
        return mTabletGameShowStatueInfo.GetAllGameShowStatueInfo();
    }

    public TabletGameShowHaiBaoInfo.ObjTabletGameShowHaiBaoInfo GetRandomHaiBaoInfo()
    {
        if (null == mTabletGameShowHaiBaoInfo)
        {
            mTabletGameShowHaiBaoInfo = new TabletGameShowHaiBaoInfo();
            mTabletGameShowHaiBaoInfo.ReadTable();
            mTabletGameShowHaiBaoInfo.ParseData();
        }
        return mTabletGameShowHaiBaoInfo.GetRandomHaiBaoInfo();
    }


    public TabletIncomeInfo.ObjTabletIncomeInfo GetGameTargetIncomeInfoByScore(float _score)
    {
        if (null == mTabletIncomeInfo)
        {
            mTabletIncomeInfo = new TabletIncomeInfo();
            mTabletIncomeInfo.ReadTable();
            mTabletIncomeInfo.ParseData();
        }
        return mTabletIncomeInfo.GetTargetIncomeInfoByScore(_score);
    }

    public List<TablePublisherInfo.ObjPublisherInfo> GetListPublisherInfoByYear(int _year)
    {
        if (null == mTablePublisherInfo)
        {
            mTablePublisherInfo = new TablePublisherInfo();
            mTablePublisherInfo.ReadTable();
            mTablePublisherInfo.ParseData();
        }
        return mTablePublisherInfo.GetListPublisherInfoByYear(_year);
    }

    public TablePublisherInfo.ObjPublisherInfo GetPublisherInfoById(string _id)
    {
        if (null == mTablePublisherInfo)
        {
            mTablePublisherInfo = new TablePublisherInfo();
            mTablePublisherInfo.ReadTable();
            mTablePublisherInfo.ParseData();
        }
        return mTablePublisherInfo.GetPublisherInfoById(_id);
    }

    public TabletNpcAppraiseInfo.ObjTabletNpcAppraiseInfo GetNpcAppraiseInfoByScore(float _score)
    {
        if (null == mTabletNpcAppraiseInfo)
        {
            mTabletNpcAppraiseInfo = new TabletNpcAppraiseInfo();
            mTabletNpcAppraiseInfo.ReadTable();
            mTabletNpcAppraiseInfo.ParseData();
        }
        return mTabletNpcAppraiseInfo.GetNpcAppraiseInfoByScore(_score);
    }

    public TabletRoleActiveSkillInfo.ObjTabletRoleActiveSkillInfo GetTabletRoleActiveSkillInfoById(int _id)
    {
        if (null == mTabletRoleActiveSkillInfo)
        {
            mTabletRoleActiveSkillInfo = new TabletRoleActiveSkillInfo();
            mTabletRoleActiveSkillInfo.ReadTable();
            mTabletRoleActiveSkillInfo.ParseData();
        }
        return mTabletRoleActiveSkillInfo.GetRoleActiveSkillInfoById(_id);
    }

    public List<TabletRoleActiveSkillInfo.ObjTabletRoleActiveSkillInfo> GetAllRoleActiveSkillInfo()
    {
        if (null == mTabletRoleActiveSkillInfo)
        {
            mTabletRoleActiveSkillInfo = new TabletRoleActiveSkillInfo();
            mTabletRoleActiveSkillInfo.ReadTable();
            mTabletRoleActiveSkillInfo.ParseData();
        }
        return mTabletRoleActiveSkillInfo.GetAllRoleActiveSkillInfo();
    }

    public TabletGameTalentInfo.ObjTabletGameTalentInfo GetTabletGameTalentInfoById(int _id)
    {
        if (null == mTabletGameTalentInfo)
        {
            mTabletGameTalentInfo = new TabletGameTalentInfo();
            mTabletGameTalentInfo.ReadTable();
            mTabletGameTalentInfo.ParseData();
        }

        return mTabletGameTalentInfo.GetGameTalentInfoById(_id);
    }


    public List<TabletGameTalentInfo.ObjTabletGameTalentInfo> GetAllGameTalentInfo()
    {
        if (null == mTabletGameTalentInfo)
        {
            mTabletGameTalentInfo = new TabletGameTalentInfo();
            mTabletGameTalentInfo.ReadTable();
            mTabletGameTalentInfo.ParseData();
        }
        return mTabletGameTalentInfo.GetAllGameTalentInfo();
    }

    public List<TabletGameTalentInfo.ObjTabletGameTalentInfo> GetGameTalentListInfoByType(EGameTalentType _type)
    {
        if (null == mTabletGameTalentInfo)
        {
            mTabletGameTalentInfo = new TabletGameTalentInfo();
            mTabletGameTalentInfo.ReadTable();
            mTabletGameTalentInfo.ParseData();
        }
        return mTabletGameTalentInfo.GetGameTalentListInfoByType(_type);
    }

    public List<TabletFurnishingInfo.ObjTabletFurnishingInfo> GetAllFurnishingForSale()
    {
        if (null == mTabletFurnishingInfo)
        {
            mTabletFurnishingInfo = new TabletFurnishingInfo();
            mTabletFurnishingInfo.ReadTable();
            mTabletFurnishingInfo.ParseData();
        }
        return mTabletFurnishingInfo.GetAllFurnishingForSale();
    }
    public TabletFurnishingInfo.ObjTabletFurnishingInfo GetFurnishingInfoById(int _id)
    {
        if (null == mTabletFurnishingInfo)
        {
            mTabletFurnishingInfo = new TabletFurnishingInfo();
            mTabletFurnishingInfo.ReadTable();
            mTabletFurnishingInfo.ParseData();
        }
        return mTabletFurnishingInfo.GetFurnishingInfoById(_id);
    }

    public TabletFurnishingInfo.ObjTabletFurnishingInfo GetFurnishingInfoByObjName(string _objName)
    {
        if (null == mTabletFurnishingInfo)
        {
            mTabletFurnishingInfo = new TabletFurnishingInfo();
            mTabletFurnishingInfo.ReadTable();
            mTabletFurnishingInfo.ParseData();
        }
        return mTabletFurnishingInfo.GetFurnishingInfoByObjName(_objName);
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

    public TabletGametypeInfo.ObjTabletGametypeInfo GetTabletGametypeInfoByIdAndLev(int _coreplayId, int _lev)
    {
        if (null == mTabletGametypeInfo)
        {
            mTabletGametypeInfo = new TabletGametypeInfo();
            mTabletGametypeInfo.ReadTable();
            mTabletGametypeInfo.ParseData();
        }
        return mTabletGametypeInfo.GetTabletGametypeInfoByIdAndLev(_coreplayId, _lev);
    }


    public TabletGametypeInfo.ObjTabletGametypeInfo GetTabletGametypeInfoById(int _id)
    {
        if (null == mTabletGametypeInfo)
        {
            mTabletGametypeInfo = new TabletGametypeInfo();
            mTabletGametypeInfo.ReadTable();
            mTabletGametypeInfo.ParseData();
        }
        return mTabletGametypeInfo.GetTabletGametypeInfoById(_id);
    }


    public TabletRoleActionsEffectInfo.ObjTabletRoleActionsEffectInfo GetTabletRoleActionsEffectInfo(int _id)
    {
        if (null == mTabletRoleActionsEffectInfo)
        {
            mTabletRoleActionsEffectInfo = new TabletRoleActionsEffectInfo();
            mTabletRoleActionsEffectInfo.ReadTable();
            mTabletRoleActionsEffectInfo.ParseData();
        }
        return mTabletRoleActionsEffectInfo.GetTabletRoleActionsEffectInfoById(_id);
    }


    public int GetRoleExpByLev(int _lev)
    {
        if (null == mTableRoleExpInfo)
        {
            mTableRoleExpInfo = new TableRoleExpInfo();
            mTableRoleExpInfo.ReadTable();
            mTableRoleExpInfo.ParseData();
        }
        return mTableRoleExpInfo.GetRoleExpByLev(_lev);
    }
    public int GetRoleLevByExp(float _exp)
    {
        if (null == mTableRoleExpInfo)
        {
            mTableRoleExpInfo = new TableRoleExpInfo();
            mTableRoleExpInfo.ReadTable();
            mTableRoleExpInfo.ParseData();
        }
        return mTableRoleExpInfo.GetRoleLevByExp(_exp);
    }


    public TabletGamePointInfo.ObjTabletGamePointInfo GetTabletGamePointInfoById(int _id)
    {
        if (null == mTabletGamePointInfo)
        {
            mTabletGamePointInfo = new TabletGamePointInfo();
            mTabletGamePointInfo.ReadTable();
            mTabletGamePointInfo.ParseData();
        }
        return mTabletGamePointInfo.GetTabletGamePointInfoById(_id);
    }

    public TabletBossActiveSkillsInfo.ObjTabletBossActiveSkillsInfo GetTabletBossActiveSkillsInfoById(EActiveSkillType _id)
    {
        if (null == mTabletGamePointInfo)
        {
            mTabletBossActiveSkillsInfo = new TabletBossActiveSkillsInfo();
            mTabletBossActiveSkillsInfo.ReadTable();
            mTabletBossActiveSkillsInfo.ParseData();
        }
        return mTabletBossActiveSkillsInfo.GetBossActiveSkillsInfoById(_id);
    }
    public List<TabletBossActiveSkillsInfo.ObjTabletBossActiveSkillsInfo> GetAllBossActiveSkillsInfo()
    {
        if (null == mTabletGamePointInfo)
        {
            mTabletBossActiveSkillsInfo = new TabletBossActiveSkillsInfo();
            mTabletBossActiveSkillsInfo.ReadTable();
            mTabletBossActiveSkillsInfo.ParseData();
        }
        return mTabletBossActiveSkillsInfo.GetAllBossActiveSkillsInfo();
    }

    public TabletOperateEventInfo.ObjTabletOperateEventInfo GetOperateEventInfoById(int _id)
    {
        if (null == mTabletOperateEventInfo)
        {
            mTabletOperateEventInfo = new TabletOperateEventInfo();
            mTabletOperateEventInfo.ReadTable();
            mTabletOperateEventInfo.ParseData();
        }
        return mTabletOperateEventInfo.GetEventInfoById(_id);
    }

    public List<TabletOperateEventInfo.ObjTabletOperateEventInfo> GetAllOperateEventInfo()
    {
        if (null == mTabletOperateEventInfo)
        {
            mTabletOperateEventInfo = new TabletOperateEventInfo();
            mTabletOperateEventInfo.ReadTable();
            mTabletOperateEventInfo.ParseData();
        }
        return mTabletOperateEventInfo.GetAllEvent();

    }

    public TabletDieReportInfo.ObjTabletDieReportInfo GetRandomDieReportInfo()
    {
        if (null == mTabletDieReportInfo)
        {
            mTabletDieReportInfo = new TabletDieReportInfo();
            mTabletDieReportInfo.ReadTable();
            mTabletDieReportInfo.ParseData();
        }
        return mTabletDieReportInfo.GetRandomResult();
    }
    public TabletDieReportInfo.ObjTabletDieReportInfo GetDieReportInfoById(int _id)
    {
        if (null == mTabletDieReportInfo)
        {
            mTabletDieReportInfo = new TabletDieReportInfo();
            mTabletDieReportInfo.ReadTable();
            mTabletDieReportInfo.ParseData();
        }
        return mTabletDieReportInfo.GetDieReportInfoById(_id);
    }

    public List<string> GetCommentTypetContentById(int _id)
    {
        if (null == mTabletCommentTypetInfo)
        {
            mTabletCommentTypetInfo = new TabletCommentTypetInfo();
            mTabletCommentTypetInfo.ReadTable();
            mTabletCommentTypetInfo.ParseData();
        }
        return mTabletCommentTypetInfo.GetCommentTypetContentById(_id);
    }

    public List<string> GetCommentTopicById(int _id)
    {
        if (null == mTabletCommentTopicInfo)
        {
            mTabletCommentTopicInfo = new TabletCommentTopicInfo();
            mTabletCommentTopicInfo.ReadTable();
            mTabletCommentTopicInfo.ParseData();
        }
        return mTabletCommentTopicInfo.GetCommentTopicById(_id);
    }

    public List<string> TabletCommentScoreInfo(int _id)
    {
        if (null == mTabletCommentScoreInfo)
        {
            mTabletCommentScoreInfo = new TabletCommentScoreInfo();
            mTabletCommentScoreInfo.ReadTable();
            mTabletCommentScoreInfo.ParseData();
        }
        return mTabletCommentScoreInfo.GetCommentScoreById(_id);
    }
    public List<string> GetDirtyWordList()
    {
        if (null == mTabletDirtyword)
        {
            mTabletDirtyword = new TabletDirtyword();
            mTabletDirtyword.ReadTable();
            mTabletDirtyword.ParseData();
        }

        return mTabletDirtyword.GetDirtyWordList();
    }
}
