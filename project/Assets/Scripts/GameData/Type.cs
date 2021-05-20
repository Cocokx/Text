using System;

public enum ECameraState
{
    ECamNormal,
    ECamLeft2,
    ECamLeft3,
    ECamLeft4,
    ECamLeft5,
    ECamTrackShip,
    ECamTrackPlane,
    ECamRoomFree,
    ECamRoomNor,
}
public enum E_PlayerState
{
    E_Idle,
    E_Walk,
    E_Climb,
}
public enum E_KeyEffect
{
    E_None,
    E_Unlock,
    E_Creat,
}
public enum E_PropState
{
    E_UnPicked,
    E_PickedUnUsed,
    E_PickedUsed,
}
public enum E_RoomType
{
    E_RoomFloor1,
    E_RoomFloor2,
}
public enum E_Scene
{
    E_Past,
    E_Nor,
    E_Room1,
    E_Room2,
    E_Room3,
}
public enum E_TimeMachine
{
    E_Time1,
    E_Time2,
    E_Time3,
    E_Time4,
}
public enum E_Trigger
{
    E_None,
    E_RoomKey,
    E_PlaneKey,
    E_LiftKey,
    E_Seed,
    E_Room,
    E_Plane,
    
    E_Lift,
    E_Pot,
    E_Gift,
    E_Password,
    E_Door,
    E_TimeMachine,
}
public enum E_PlatForm
{
    ENone,
    EPcOnlineGames,
    EWeb,
    EMobile,
    EVR,
    EPcStandAlone,
}

public enum E_Product_WorkContent
{
    ENone = -1,
    ESetting1,  
    ESetting2,
    ESetting3,
    ESetting4,
    ESetting5,
    ESetting6,
}
public enum E_Product_Quality_Type
{
    ENone,
    EDiversity,
    EExpressiveness,
    EContend,
    EOperation,
    ESocialContact,
    ESubstitution,
}

public enum E_GamePlatFormType
{
    ENone,
    EPcStandalone,
    EPcOnLine,
    EWebGame,
    EMobileGame,
    EVR,
    EConsoleGame,
}


public enum E_RoleType
{
    ENone = 0,
    EGameDesigner,
    EProgrammer,
    EArtist,
  
}

public enum E_Mission_Type
{
    ENone,
    EMakeGame = 1,
    EFullGameRound = 40,
    EScoreReachtoLev = 41,
    EBeingProducer = 42,
    EBeingCommunicationMan = 43,
    EJoinCJ = 44,
    EJoinRecruit = 45,
    EGetYearEndAward = 46,
}

public enum E_Mission_Role_Att_Type
{
    ENone = -1,
    EMainAtt,
    EGameplay,
    ETechnology,
    EArt,
    //Communicate,
    //AudioSkill,
    //Luck,
}

public enum E_Random_Event_Condition
{
    ENone = 0,

    /*
     1：随时
2：发售
3：招聘
4：cj
5：选制作人
6：选音乐人
     */
     EAnyTime,
    EOnSale,
    ERecruit,
    ECJ,
    EChoiceProducer,
    EChoiceMusician,
}

public enum E_Random_Event_ResultType
{
    /*    
     * 1：收益减少
2：收益增加
3：资金损失
     */
    ENone = 0,
    EDecreaseInRevenue,
    EIncreaseInRevenue,
    ECapitalLoss,
}

public enum EGameFeatureState
{
    eNone,
    eDisabel,
    eEnabel,
    eUnlock,
    eUnlocking,
}

public enum ECompanyTalentType
{
    /*
    1：工位
2：公司升级
3：招聘
4：核心用户数
100：策划能力
101：技术能力
102：美术能力
103:全屬性
200：事件
*/
    eNone = 0,
    eWorkstation,
    eOfficeUpgrade,
    eRecruit,
    eCorePlayer,
    eGamePlay = 100,
    eTechnology,
    eArt,
    eAllRoleAtt,
    eEvent = 200,
}
public enum EApprovalSettingType
{
    eNone = 0,
    eGameType,
    eSubjectMatter,
    eStyle,
    ePlatform,
    eDistributionType,
}

public enum EBossEventType
{
    eNone,
    eProjectApproval,
    eAssignJobs,
    eGoOffWorkEvent,
    eRoomArrange,
}
public enum ERoleStoryType
{
    eNone,
    //ePreProjectApproval,
    //eProjectApprovalComplete,
    eBossMonologue,
    eBossAsk,
    eEmployeeMonologue,
    eEmployeeAnswer,
    eEmployeeTalkToEachOther,
}

public enum EBossStoryConditionType
{
    /*
     1：立项
2：立项完成
3：内测
4：公测
5：发行商
6：游戏展会
7：发行
100：员工离职
101：员工请假
102：员工恋爱
200：公司扩张
201：公司被收购
     */
    eNone,
    eProjectApproval,
    eProjectApprovalComplete,
    eCloseBeta,
    eOpenBeta,
    ePublisherCome,
    eGameShow,
    eReleaseEnable,
    eEmployeeTurnover = 100,
    eEmployeeStaffLeave,
    eEmployeeFallInLove,
    eCompanyExpansion = 200,
    eBeBought,
}
public enum EEmployeeStoryConditionType
{
    /*
     1：立项

100：加班
101：体力值小于
102：压力值大于
103：恋爱


         */
    eNone,
    eProjectApprovalComplete,
    eOvertime,
}

public enum EmployeeStoryEffectType
{
    /*
     * 1：压力

     */
    eNone,
    ePressure,
}

public enum EWorldSubregion
{
    /*
     *
     * 中国
东南亚
南美洲
欧洲
北美
日本
非洲

     */
    EAllWorld = 0,
    EChina,    
    ESoutheastAsia,
    ESouthAmerica,
    EEurope,
    ENorthAmerica,
    EJapan,
    EAfrica,
    ECounter,
}

public enum ESpreadType
{
    eNone,
    /*
  户外广告
互联网广告
电视广告
网吧推广
明星代言
社交平台
     */

    eOutdoorAdvertising,
    eInternetAdvertising,
    eTvAdvertising,
    eInternetBar,
    eStarEndorsement,
    eSocialPlatform,
}


public enum ERoleEmotionType
{
    eNone,
    eHappy,
    eUnhappy,
    eExcitement,
    ePuzzled,
    eAngry,
    eRage,
    eSick,


}
public enum EMoveType
{
    eNone,
    eWalk,
    eRun,
}
public enum EFaceDir
{
    eNone,
    eRightTop,
    eLeftTop,
    eRightBottom,
    eLeftBottom
}

public enum EOfficeSpecPosType
{
    eNone,
    eWaterDispenser,

}
public enum ERoleEventHandlerType
{
    eNone,
    eOpA,
    eOpB,
}

public enum ECommonEvtTriggerType
{
/*
1.立项
2.发行
3.全力研发
4.解决bug
5.入职
6.购物
7.研究竞品
*/

    eNone,
    eProjectApproval,
    eGameDistribution,
    eFullStrength,
    eFixBug,
    eEntry,
    eBuySomeThing,
    eResearch,
}

public enum EEvtEffectType
{
    /*
1.体力
1.角色体力
2.公司金钱
3.当前项目亮点
4.当前项目策划内容
5.当前项目程序内容
6.当前项目美术内容
7.当前项目bug
8.当前项目角色对应产出内容
9.角色当前项目对应使用都特殊属性经验值
10.角色梦想值
11.角色金钱值
12.角色工资（百分比）
13.角色心态
14.角色工作能力经验值

*/
    eNone,
    eRolePhysicalStrength,
    eCompanyMoney,
    eProductionBright,
    eProductionGameplay,
    eProductionTel,
    eProductionArt,
    eProductionBug,
    eRoleMainOutPut,
    eRoleSpecExp,
    eRoleDreamValue,
    eRoleMoneyValue,
    eRoleSalary,
    eRoleMentality,
    eRoleMainExp,
}

public enum EEventType
{
    eNone,
    eCommon,
    eSpec,
}

public enum EEmployeeWorkingContent
{
    eNone,
    eFullStrength,
    eFixBug,
    eResearch,
}

public enum EGameTalentType
{
    eNone,
    eGamePlay,
    eTel,
    eArt,
}

public enum EGameTalentState
{
    eNone,
    eHidden,
    eAvailable,
    eNotAvailable,
    eActive,
}

public enum EGameTalentEffectValyeType
{
    /* 
1.策划能力
2.程序能力
3.美术能力
4.当前亮点
5.角色扮演游戏
6.体育游戏
7.电竞游戏
8.沙盒游戏
9.射击游戏
10.动作游戏
11.模拟养成
12.休闲游戏
13.解谜游戏
14.像素画风
15.写实画风
16.卡通画风
17.欧美画风
18.水墨画风
19.和风画风
20.现代画风
21.页游平台
22.手机平台
23.PC平台
24.主机平台
25.多端平台
26.vr平台    
 */

    eNone,
    eGamePlay,
    eTel,
    eArt,
    eBrightSpot,

    eGameType1,
    eGameType2,
    eGameType3,
    eGameType4,
    eGameType5,
    eGameType6,
    eGameType7,
    eGameType8,
    eGameType9,

    eGameStyle1,
    eGameStyle2,
    eGameStyle3,
    eGameStyle4,
    eGameStyle5,
    eGameStyle6,
    eGameStyle7,

    eGamePlatform1,
    eGamePlatform2,
    eGamePlatform3,
    eGamePlatform4,
    eGamePlatform5,
    eGamePlatform6,
}

public enum EGameTalentEffectType
{
    eNone,
    eAbilityToPay,
    ePropaganda,
    eGameTime,
    eBrightSpot,
    eBug,
    eAllEmployeeMoneyValue,
    eAllEmployeeDreamValue,
}


//public enum EProfessionType
//{
//    /*
//    1：系统策划
//    2：玩法策划
//    3：文案策划
//    4：运营策划
//    5：前端程序
//    6：后端程序
//    7：引擎程序
//    8：UI美术
//    9：特效动作美术
//    10：原画美术
//     */
//    eNone,
//    eGameDesignerSubTypeSys,
//    eGameDesignerSubTypeGameplay,
//    eGameDesignerSubTypeCopywriting,
//    eGameDesignerSubTypeOperate,
//    eTelFrontEnd,
//    eTelBackEnd,
//    eTelEngine,
//    eArtUI,
//    eArtAnima,
//    eArtOriginalPainting,
//}
public enum ECorePlayMatchingType
{
    eNone,
    ePerfect,
    eGood,
    eNormal,
    eBad,
}

public enum ECorePlayMatchingValue
{
    eNone,
    ePerfectValue = 200,
    eGoodValue = 150 ,
    eNormalValue = 100,
    eBadValue = 50,
}

public enum ERoomType
{
    /*
     * 0:全体
     * 1:办公区域
2：boss办公室
3：会议室
4：健身房
5：游戏室
6：策划学习室
7：程序学习室
8：美术学习室
9:餐厅
10：桌游室

*/
    eAll = 0,
    eWorkingArea = 1,
    eBossRoom,
    eMeetingRoom,
    eGymRoom,
    eGameRoom,
    eGameDesignerRoom,
    eProgrammerRoom,
    eArtistRoom,
    eTeaRoom,
    eBoardGameRoom,
   
}

public enum EWorkAreaLayoutId
{
    eNone,
    eWorkingAreaLayout1 = 10000,
    eWorkingAreaLayout2,
}

public enum ERoomItemType
{
    eNone,
    eDesk,
    eChair,
}

public enum EGameMode
{
    eNone,
    eGame,
    eBuild,
}
public enum EGameTechType
{
    eNone,
    eGameDesign,
    eProgramming,
    eArt,
}
public enum EResearchType
{
    eNone,
    eGameDesign,
    eTechnique,
    eArt,
    eGameContent,
}

public enum EFoodDrinkType
{
    /*
     1：食物
2：饮料
3：外卖
*/
    eNone,
    eFood,
    eDrink,
    eTakeOutFood,
}
public enum EItemEffectType
{
    /*
    1：饥饿
    2：体力
    3：娱乐
    4：社交
     */
    eNone,
    eHunger,
    ePhysicalPower,
    eAmusement,
    eSocialContact,
}


public enum EHomeFurnishingType
{
    /*
   1：老板办工桌
   2： 椅子
   3： boss沙发
   4： 电脑
   5： 饮水机
   6： 植物
   7： 保险箱
   8： 柜子
   9： 陈列架
   10： 落地灯
   11： 会议室桌子
   12： 会议室柜子
   13： 前台桌子
   14： 墙画
   15： 通用沙发
   16： 画室桌子
   17： 画室工作台
   18： 画室画架
   19： 游戏机
   20： 电视机
   21： 游戏室桌子
   22： 游戏室书架
   23： 游戏室地垫
   24： 街机
   25： 策划书架
   26： 策划室桌子
   27： 床
   28： 策划白板
   29： 漫画书架
   30： 宝箱
   31： 电视机
   32： 服务器
   33： mini服务器
   34： 空调
   35： 美术工作桌
   36： 美术书架
   37： 美术电脑桌
   38:  售货机 
   39:  冰箱
    40: 餐桌
    41:桌游室桌子
    42：游戏室电视机
    43:健身器材类型1
    44:健身器材类型2
    45:健身器材类型3
    46:健身器材类型4
    47:健身器材类型5
*/
    eNone,
    eBossDesk,
    eChair,
    eBossSofa,
    eComputer,
    eWaterDispenser,
    ePlant,
    eSafeDepositBox,
    eCupboard,
    eDisplayRack,
    eFloorLamp,
    eMeetingDesk,
    eMeetingGuizi,
    eQiantaiZhuozi,
    ePainting,
    eCommonSofa,
    eArtTable,
    eArtWorkbench,
    eEasel,
    eGameConsole,
    eTV,
    eGameRoomtable,
    eGameRoomBox,
    eGameroomDiDian,
    eArcade,
    eDesignerBookshelf,
    eDesignerTable,
    eBed,
    eDesignerWhiteboard,
    eComicBookShelf,
    eChest,
    eTelTV,
    eTheServer,
    eMiniServer,
    eAirConditioner,
    eArtWorkTable,
    eArtBookShelf,
    eArtComputerTable,
    eVendingMachine,
    eRefrigerator,
    eDiningTable,
    eTableRoomDesk,
    eGameRoomTv,
    eFitnessEquipmentType1,
    eFitnessEquipmentType2,
    eFitnessEquipmentType3,
    eFitnessEquipmentType4,
    eFitnessEquipmentType5,
}

public enum ERoleStateEnum
{
    eNone,
    eNormal,
    eWeak,
    eInDanger,
}

public enum EInteractiveId
{
    /*
     * 1:工位睡觉
     * 2:吃外卖
     * 3：吃冰箱食物
     * 4：吃售货机食物
     * 10：调整工作时间
     10000	吃零食

40001	更换植物
50001	更换壁画
60001	小睡1小时
60002	小睡2小时
60003	小睡3小时
60004	小睡4小时
70001	随便涂鸦
80001	玩游戏
80002	召唤员工一起游戏
80003	通关一款游戏
90001	观看直播
90002	召唤员工一起观看直播
100001	街机玩游戏
100002	街机召唤员工一起游戏
100003	街机通关一款游戏
110001	研究策划文档
110002	抄袭
120001	翻阅漫画书
130001	膜拜服务器
140001	召唤员工玩桌游
150001  健身
150002  召唤员工一起健身
     */
    eNone,
    eSleepAtWorkstation = 1,
    eEatTakoutFood = 2,
    eEatFoodInRefrigerator = 3,
    eEatFoodInVendingMachine = 4,
    eAdjustWorkingHours = 10,


    eTakeOutFood1 = 30000,
    eTakeOutFood2 = 30001,
    eTakeOutFood3 = 30002,
    eTakeOutFood4 = 30003,

    eReplacementPlants = 40001,
    eReplacementPainting = 50001,

    eSleep1 = 60001,
    eSleep2 = 60002,
    eSleep3 = 60003,
    eSleep4 = 60004,

    eDoodling = 70001,//涂鸦

    ePlayGame = 80001,
    ePlayGamesTogether = 80002,
    eClearanceGame = 80003,


    eWatchLive = 90001,
    eWatchLiveTogether = 90002,

    eArcadePlayGame = 100001,
    eArcadePlayGamesTogether = 100002,
    eArcadeClearanceGame = 100003,


    eResearchDesignDoc = 110001,
    eDesignCopy = 110002,
    eReadComicBooks = 120001,

    eWorshipServer = 130001,
    ePlayBoardGamesTogether = 140001,

    eBodybuilding = 150001,
    eBodybuildingTogether = 150002,
}

public enum EPlayableGamesType
{
    eNone,
    eConsolegame,
    eArcade,
}

public enum EProductionProcessStage
{
    eNone,
    eReady,
    eDesign,
    eCoding,
    eArt,
}

//public enum ECardType
//{
//    /*
//     * 1：设定
//2：角色
//3：策略
//4：程序
//5：动作
//6：系统
//7：明星
//     */
//    eNone,
//    eSetting,
//    eRole,
//    eStrategy,
//    eProgram,
//    eAction,
//    eSystem,
//    eStar,
//}

public enum EInteractionSpecEffectType
{
    /*
     * 体力上限
     */
    eNone = 0,
    eStrengthUpperLimit,
}



public enum EfurnitureInteractiveId
{
    /*
1	升级
10	调整工作时间
100	购买主机游戏
101	更换主机游戏
110	购买街机游戏
111	更换街机游戏
200	购买冰箱食物
210	购买贩卖机食物
300	购买漫画
301	更换漫画
400	购买节目
401	更换节目
500	购买桌游
501	更换桌游
600	点外卖
700  更换盆栽
     */
    eNone,
    eUpgrade = 1,
    eAdjustWorkingHours = 10,
    eBuyHostGame = 100,
    eChangeHostGame = 101,
    eBuyArcadeGame = 110,
    eChangeArcadeGame = 111,
    eBuyFoodForRefrigerator = 200,
    eBuyFoodForVendingMachine = 210,
    eBuyingComics = 300,
    eChangeComics = 301,
    eBuyTvPrograms = 400,
    eChangeTvPrograms = 401,
    eBuyBoardGame = 500,
    eChangeBoardGame = 501,
    eBuyTakeOutFood = 600,
    eReplacePlants = 700,
}

public enum EBeginStoryType
{
    eNone,
    //eOutsource,
    //eBuyGame,
    //eBuyFood,
    eRecruit,
    eCreateCompany,
    eNeedProducer,
    eProducerComplete,
    //ePublisherShame,
    ePublisherComplete,
    eJoinGameShow,
    eGameShowComplete,
    //eNpcVist,
    eGuidChoicecoreplay,
    eGuidChoiceTopic,
    eReleaseEnable,
    eShowSpreadView,
    eCommentComplete,
    eGuidSetting1,
    eGuidSetting2,
    eGuidSetting3,
    eGuidTalentUnlock,
    eOperateStart,
}
public enum EBudgetItemType
{
    eNone,
    eRent,
    eSalary,
    //合同
    eContract,
    eFood,
    eShopping,
    eOfficeItems,
    eSpread,
    eInCome,
    eOther,
    eLevup,
    eActivity,
    eArtPeripheral,
    eFireEmployee,

    eProject,
    eFurnishing,
    eSupportEmployee,
    eBoss,
}
//public enum EProjectPhase
//{
//    eNone,
//    eGetReadyForDesign,
//    eDesignProgress,

//    eGetReadyForArt,
//    eArtProgress,

//    eGetReadyForTech,
//    eTechProgress,
//}

public enum ESettingId
{
    eNone,
    eSetting1,
    eSetting2,
    eSetting3,
    eSetting4,
    eSetting5,
    eSetting6,
    eMax,
}
public enum EArtId
{
    eNone,
    eCharactersPainting,
    eUIEffect,
    eActionPainting,
    eScenePainting,
}
public enum ETechId
{
    eNone,
    /*
     * 策划脚本支持
     * 美术脚本支持
     * 程序脚本支持
     */
    eGamePlaySupport,
    eArtSupport,
    eTechSupport,
}
public enum EGameplayMilestoneId
{
    /*
参加地方游戏展会
参加区域游戏展会
参加chinajoy
参加德国科隆展
参加东京电玩展
参加E3游戏展
主办游戏展览会
     */
    eNone,
    eGameplayMilestone1,
    eGameplayMilestone2,
    eGameplayMilestone3,
    eGameplayMilestone4,
    eGameplayMilestone5,
    eGameplayMilestone6,
    eGameplayMilestone7,
    eMax,
}

//public enum EIncomeMilestoneId
//{
//    eNone,
//    /*
//     公司等级达到2级
//公司等级达到3级
//公司等级达到4级
//公司等级达到5级

//     */

//    eIncomeMilestoneId1,
//    eIncomeMilestoneId2,
//    eIncomeMilestoneId3,
//    eIncomeMilestoneId4,
//    eIncomeMilestoneId5,
//    //eIncomeMilestoneId6,
//    //eIncomeMilestoneId7,
//    //eIncomeMilestoneId8,
//    //eIncomeMilestoneId9,
//    eMax,
//}
//public enum EMilestoneState
//{
//    eNone,
//    eDisActive,
//    eActiveEnable,
//    eActive,
//}
public enum EEventContentType
{
    /*
     * 1.加班时间
        2.灵感
        3.研发
        4.金钱
        5.请假
        6.工作量
     */
    eNone,
    eOvertime,
    eInspiration,
    eResearch,
    eMoney,
    eLeave,
    eWorkload,
}

public enum EReferenceType
{
    /*
     * 1.策划
2.美术
3.程序
4.灵感
5.研发
6.忠诚
7.工作效率
8.娱乐
9.学习能力
10.金钱
     */
    eNone,
    eGameDesignAblity,
    eArtAblity,
    eTechAblity,
    eInspiration,
    eResearch,
    eLoyal,
    eWorkEfficiency,
    eEntertainment,
    eLearnAbilityAblity,
    eMoney,

}

public enum EEventEffectType
{
    /*
     * 1.操作反应
        2.策略玩法
        3.收集养成
        4.付费
        5.灵感
        6.美术评分
        7.玩法评分
        8.研发
        9.策划经验
        10.美术经验
        11.程序经验
        12.灵感等级
        13.研发等级
        14.忠诚
        15.工作效率
        16.收入
     */
    eNone,
    eSettingOperation,
    eSettingStrategy,
    eSettingCollect,
    eSettingPay,
    eInspiration,
    eArtScore,
    eGamePlayScore,
    eResearch,
    eDesignExp,
    eArtExp,
    eTechExp,
    eLoyalLev,
 
    eIncome,
}

public enum EEmployeeEventType
{
    eNone,
    eBug,
    eOptimization,
    ePersonal,
}


//public enum EMilestoneUnLockContentType
//{
//    eNone,
//    /*
//     1.发布游戏
//    2.玩家数量
//    3.美术评分
//     */
//    eReleaseGame,
//    ePlayNum,
//    eArtScore,
//}
//public enum EMilestoneUnLockType
//{
//    eNone,
//    /*
//     * 1：解锁主题等级
//        2：解锁啊u哦有游戏类型
//        3:美术周边
//     */
//    eGameContentLev,
//    eAllCoreplay,
//    eArtPeriphery,
//}

public enum EPayRiseEventType
{
    eNone,
    /*
     * 1.离职
2.加薪
     */
    eQuit,
    ePayRise,
}
public enum ECompensateType
{
    eNone,
    eN1,
    e2N,
}

//public enum EMilestonePrestigeUnLock
//{
//    eNone,
//    eSchoolEnrollment,
//    eHeadhunting,
//}
public enum ETopiclType
{
    eNone = -1,
    /*
     * 
    1000:体育爱好者
    1001:历史爱好者
    1002.日常爱好者
    1003:魔幻爱好者
    1004:恐怖爱好者
    1005:科幻爱好者
     */
    eTopicAll = 999,
    eTopicType1 = 1000,
    eTopicType2,
    eTopicType3,
    eTopicType4,
    eTopicType5,
    eTopicType6,
    eMax,
}

public enum ERoleHobbyType
{
    /*
     * 1.画画
2.研究玩法
3.研究程序
4.玩游戏
5.健身

     */
    eNone,
    eDraw,
    eResearchGameplay,
    eResearchTech,
    ePlayGame,
    eBodybuilding,
}

public enum EGoOffTimeActionType
{
    eNone,
    eFree,
    eOptimization,
    eShareMetting,
}

public enum ERoomFunParamType
{
    eNone,
    /*
     *  1.体力消耗速度
        2.员工数量
        3.碎片数量
        4.饥饿值
        5.灵感消耗速度
     */
    eStrengthValueAttenuation,
    eEmployeeNum,
    eMaterialNum,
    eHungerValue,
    eInspirationValueAttenuation,
}


//public enum EFansUnlockTypeEnum
//{
//    eNone,
//    /*      
//     * 1：工位上限
//2：程序阶段
//3：给一个主题
//4：解锁游戏类型等级
//5：开公司
//6：解锁校招
//7：解锁猎头招聘
//8：解锁房间
//9：房间等级上限
//10：工作区升级
//11：解锁活动
//     */

//    eEmployeeMax,
//    eDevTechPash,
//    eFindATopic,
//    eUnLockCoreplayLev,
//    eStartCompany,
//    eUnlockRoomType,
//    eUnlockRoomLev,
//    eWorkAreaLevUp,
//    eUnlockActivity,
//}

public enum EProjectTypeEnum
{
    eNone,
    /* 1：自主研发
     * 2：合作研发
     */

    eFreeMode,
    eMissionMode,
}
public enum ERoleActionTypeEnum
{
    eNone,
    eNoonBreakEatSnacks,
    eOffWorkEatSnacks,
    eEatFood,
    eSleepOnSofa,
    eWorkNap,
    ePlayGame,
    ePlayArcadeGame,
    eBodyBuilding,
    eReadComicBooks,
    eDoodling,
    eLiveBroadcast,
    eResearchDesignDoc,
    eGotoTechRoom,
    eBoardGame,

    eWorkingHard = 100,
    eBrainstorming,
    eGameDesignCopy,
    eGameDesignResearch,
}
//public enum ERoleBadStateEnum
//{
//    eNone,
  
//    //打架
//    eFight,
//}
public enum ENpcType
{
    eNone,
    ePublisher,
    eTopicSeller,
    eStarDeveloper,
    ePasserBy,

    eVisitPublisher,
    eVisitProducer,
}

public enum ERolePassiveSkillsTypeEnum
{
    /*
     1：游戏类型爱好者
    2：游戏内容爱好者
    3：作为制作人
    4：发布
    5：氛围
    6：总结
    7：使用主动技能

    100：核心玩法达人
    101：游戏内容达人
    200：招聘时效果
    300：薪资压缩
    400：唱歌
    500：项目结束，提升其他员工属性
    600：房间使用次数
    700：展会体力
    800：主题商打折
    900：员工状态增量效果
    1000：发行商爱好者
    1001：老油条
    1002：狂躁症
    */

    eNone,
    eGameType,
    eGameTopic,
    eProducer,
    eRelease,
    eAtmosphere,
    eSummary,
    eActiveSkill,

    eCoreplayMaster = 100,
    eTopicMaster = 101,
    eRecruitEffect = 200,
    eSalaryCut = 300,
    eSing = 400,
    eProjectReleaseShare = 500,
    eRoomActiveNum = 600,
    eGameShowStrength = 700,
    eTopicSellerDiscount = 800,
    eRoleStateIncrementalEffect = 900,
    eProjectMission = 1000,
    eCannotFire = 1001,
    eManic = 1002,
}

public enum EGameShowLayoutPointType
{
    eNone = 0,
    eStatueLev1,
    eStatueLev2,
    eStatueLev3,
    eStatueLev4,
    eStatueLev5,

    eLev1,
    eLev2,
    eLev3,
    eLev4,
    eLev5,
}

public enum ApplicationConditionType
{
    /*
     * 1.发布游戏
2.发布角色扮演
3.发布模拟游戏
4.发布动作游戏
5.发布射击游戏
6.发布益智游戏
7.在美国发布游戏
8.在日本发布游戏
9.在欧洲发布游戏
10.累计收入（不算给发行商的）
11. 游戏评分
12. 公司声望
13. bug总量
     */
    eNone,
    eReleaseGame,
    eReleaseMMoGame,
    eReleaseSimulationGame,
    eReleaseActionGame,
    eReleaseShootingGame,
    eReleasePuzzleGame,
    eReleaseGameAtUsa,
    eReleaseGameAtJapan,
    eReleaseGameAtEurope,
    eTotalInCome,
    ePrestige,
    //eBugTotalNum,
}

public enum EJoinGameShowTypeEnum
{
    eNone,
    eCenter,
    eBig,
    eCorner,
}
public enum EResetArrangeTypeEnum
{   
    eNone,  
    eBodybuilding,
    ePlayGame,
    eLearngameDesign,
    eLearnArt,
    eLearnTech,
    eDinnerParty,
    ePlayBoardGame,
}

public enum ERoleActiveSkillTypeEnum
{
    eNone,
    eProducer,
    eAll,
}
public enum EEmployeeDutiesType
{
    eNone = -1,
    eCommon,
    eGameDesign,
    eTech,
    eArt,
}
public enum EBossDutiesType
{
    /*
     * 1：解锁场景
      2：解锁房间
      3：招聘
      4：解锁市场
      5：解锁购物
      100：举办游戏展
     */
    eNone = 0,
    eNewScene,
    eUnlockRoom,
    eRecruit,
    eUnlockMarket,
    eUnlockShopping,
    eGameShow,

}
public enum EFurnitureEffectType
{
    /*
     * 1.精力恢复速度
2.忠诚
3.压力增加速度
4.策划能力
5.美术能力
6.程序能力
     */

    eNone,
    eEnergyRecoveryRate,
    eLoyal,
    ePressAddRate,
    eGameDesignExp,
    eArtExp,
    eTechExp,
}
public enum EDayPlanType
{
    eNone,
    ePress,
    eCare,
}

public enum ERoleActionType
{
    eNone,
    eWorking,
    eDrinking,
    eEating,
    eSleep,
    eBuildBody,
    ePlayGame,
    eLearnGameDesign,
    eLearhTech,
    eLearhArt,
    eDinnerParty,
    eWatchTv,
    ePlayBoardGame,
    eGotoWork,
    eGoOffWork,

}

public enum EPlayAnimaAnmaType
{
    eNone,
    eDrinkMilkTea,
    eScared,
    eGymHard, 
    eGymHurt,
    eCold,
    eSad,
    eHappy,
    eReady,
    eUnhappy,
    ePuzzle,
    eGetBadState,
}
public enum EActiveSkillType
{
    /*
     * 100	激情演讲
    101	喝奶茶
    102	聚餐
    103	参加展会
    104	团建旅游
    105	团建旅游
     */
    eNone,
    eBossInspireSpeech = 100,
    eDrinkMilkTea = 101,
    eDinnerParty = 102,
    eJoinGameshow = 103,
    eTeamBuildingTravel = 104,
    eWorkingContent = 105,

}

public enum E_EmployeeMentalityType
{
    /*
     * 1.焦虑
2.懒散
3.暴躁
     */
    eNone,
    eAnxious,
    eLaziness,
    eIrritability,
}

public enum E_GetSkill_ActionType
{
    eNone,
    /*
     * 1.选为制作人
2.喝奶茶
3.健身
4.玩游戏
5.桌游
6.头脑风暴
7.制作对应游戏
8.制作对应主题
9.老板画饼
     */
    eBeAProducer,
    eDrinkMilkTea,
    eBuildBody,
    ePlayGame,
    eBoardGame,
    eNodeWork,
    eGameType,
    eGameTopic,
    eBossSpeech,
}

public enum E_Production_Phase
{
    eStart,
    eProducerWorking,
    eProgressing,
    eStartRealse,
    eOperateing,
    eOperateingEnd,

    eEnd,
}