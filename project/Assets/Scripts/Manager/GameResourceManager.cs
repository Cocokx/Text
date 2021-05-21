
using UnityEngine;

public class GameResourceManager
{
    static GameResourceManager instance;

    public static GameResourceManager Instance
    {
        get
        {
            if (null == instance)
                instance = new GameResourceManager();
            return instance;
        }
    }
    public Texture2D GetBackPackIconByName(string _name)
    {
        Texture2D headIcon = Resources.Load<Texture2D>("Icon/BackPackIcon/" + _name);
        return headIcon;
    }
    public AudioClip GetAudioEffectClipByName(string _name)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/AudioEffect/" + _name);
        return audioClip;
    }
    public AudioClip GetBGMByName(string _name)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/BGM/" + _name);
        return audioClip;
    }
    //public Texture2D GetRoleHeadIconByName(string _name)
    //{
    //    Texture2D headIcon = Resources.Load<Texture2D>("Icon/HeaIcon/" + _name);
    //    return headIcon;
    //}


    //public GameObject GetUIViewItemByName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("UI/ViewItem/" + _name);
    //    return GameObject.Instantiate(mPrefabe);
    //}

    //public GameObject GetHudViewItemByName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("UI/Hud/" + _name);
    //    return GameObject.Instantiate(mPrefabe);
    //}

    //public GameObject GetRoleObjByName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("Role/" + _name);
    //    return mPrefabe;
    //}

    //public GameObject GetWorldMapObj()
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("WorldMap/WorldMap");
    //    return GameObject.Instantiate(mPrefabe);
    //}
    //public GameObject GetWorldMapPieGraph()
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("WorldMap/PieGraph");
    //    return GameObject.Instantiate(mPrefabe);
    //}
    //public GameObject GetUniversalWorldMapObj()
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("WorldMap/UniversalWorldMap");
    //    return GameObject.Instantiate(mPrefabe);
    //}



    //public GameObject GetUIPrefabeByName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("UI/" + _name);
    //    return GameObject.Instantiate(mPrefabe);
    //}


    //public Material GetGrayMaterial()
    //{
    //    Material mat = Resources.Load<Material>("Material/GrayMaterial");
    //    return mat;
    //}

    //public Texture GetAttIconByType(E_Product_WorkContent _type)
    //{
    //    Texture2D image = null;
    //    if (_type == E_Product_WorkContent.ESetting1)
    //        image = Resources.Load<Texture2D>("Icon/Attribute/GamePlay");
    //    else if (_type == E_Product_WorkContent.ESetting2)
    //        image = Resources.Load<Texture2D>("Icon/Attribute/Technology");
    //    else if (_type == E_Product_WorkContent.ESetting3)
    //        image = Resources.Load<Texture2D>("Icon/Attribute/Art");

    //    return image;
    //}

    //public Texture GetBusinessModeIconByName(string _name)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/BusinessModel/" + _name);
    //    return image;
    //}
    //public Texture GetCoregamePlayIconByName(string _name)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/CoregGameplay/" + _name);
    //    return image;
    //}

    //public Texture2D GetWorldMapRedDot(bool _isMy)
    //{
    //    Texture2D image = null;
    //    if (_isMy)
    //        image = Resources.Load<Texture2D>("WorldMap/green_dot");
    //    else
    //        image = Resources.Load<Texture2D>("WorldMap/red_dot");
    //    return image;
    //}

    //public Texture2D GetSpreadiconByName(string _name)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/SpreadTypeIcon/" + _name);
    //    return image;
    //}

    //public GameObject GetCoins()
    //{
    //    int randomIndex = Random.Range(1, 5);
    //    GameObject mPrefabe = Resources.Load<GameObject>("Coin/Coin_" + randomIndex);
    //    return GameObject.Instantiate(mPrefabe);
    //}

    //public Texture GetEmojiAtlas()
    //{
    //    Texture image = Resources.Load<Texture>("atlasEmoJi");
    //    return image;
    //}
    //public Texture2D GetEmojiIconById(int _id)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/Emoji/" + _id);
    //    return image;
    //}
    //public GameObject GetGridPreBuyName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("GroundGrid/" + _name);
    //    return mPrefabe;
    //}


    //public Texture2D GetGameTalentIconByName(string _name)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/GameTalent/" + _name);
    //    return texture;
    //}

    //public AudioClip GetAudioClipByName(string _name)
    //{
    //    AudioClip sound = Resources.Load<AudioClip>("Sound/" + _name);
    //    return sound;
    //}

    //public GameObject GetEffectPreByName(string _name)
    //{
    //    //Debug.LogError("----------_name-----:" + _name);
    //    GameObject mPrefabe = Resources.Load<GameObject>("Effect/" + _name);
    //    return GameObject.Instantiate(mPrefabe);
    //}


    //public GameObject GetOfficePrefabByName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("Office/" + _name);
    //    return GameObject.Instantiate(mPrefabe);
    //}

    //public Texture2D GetRoomIconByName(string _name)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/RoomIcon/" + _name);
    //    return texture;
    //}


    //public Texture2D GetGameTopicIconByName(string _name)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/GameContentIcon/" + _name);
    //    return texture;
    //}
    //public Texture2D GetGameTopicTypeIcon(ETopiclType _type, bool _color = false)
    //{
    //    string iconCame = "";

    //    if (!_color)
    //    {
    //        switch (_type)
    //        {
    //            case ETopiclType.eTopicType1:
    //                iconCame = "icon_topic_53";
    //                break;
    //            case ETopiclType.eTopicType2:
    //                iconCame = "icon_topic_54";
    //                break;
    //            case ETopiclType.eTopicType3:
    //                iconCame = "icon_topic_55";
    //                break;
    //            case ETopiclType.eTopicType4:
    //                iconCame = "icon_topic_56";
    //                break;
    //            case ETopiclType.eTopicType5:
    //                iconCame = "icon_topic_57";
    //                break;
    //            case ETopiclType.eTopicType6:
    //                iconCame = "icon_topic_58";
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        switch (_type)
    //        {
    //            case ETopiclType.eTopicType1:
    //                iconCame = "icon_topic_44";
    //                break;
    //            case ETopiclType.eTopicType2:
    //                iconCame = "icon_topic_45";
    //                break;
    //            case ETopiclType.eTopicType3:
    //                iconCame = "icon_topic_46";
    //                break;
    //            case ETopiclType.eTopicType4:
    //                iconCame = "icon_topic_47";
    //                break;
    //            case ETopiclType.eTopicType5:
    //                iconCame = "icon_topic_48";
    //                break;
    //            case ETopiclType.eTopicType6:
    //                iconCame = "icon_topic_49";
    //                break;
    //        }
    //    }

    //    Texture2D texture = Resources.Load<Texture2D>("Icon/GameContentIcon/" + iconCame);
    //    return texture;
    //}


    //public Texture2D GetPlayableGameIconById(int _id)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/GameIcon/" + _id);
    //    return texture;
    //}
    //public Texture2D GetTakeoutFoodIconById(int _id)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/TakeoutFood/" + _id);
    //    return texture;
    //}
    //public Sprite GetPlayableGameContentById(int _id)
    //{
    //    Debug.LogError("-----GetPlayableGameContentById----_id:" + _id);
    //    Sprite texture = Resources.Load<Sprite>("Icon/GameIcon/" + _id + "_content");
    //    return texture;
    //}

    //public Texture2D GetComicBooksIconById(int _id)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/ComicBooks/" + _id);
    //    return texture;
    //}
    //public Texture2D GetComicBooksContentById(int _id)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/ComicBooks/" + _id + "_content");
    //    return texture;
    //}


    //public Texture2D GetLiveBroadcastIconById(int _id)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/LiveBroadcast/" + _id);
    //    return texture;
    //}
    //public Sprite GetLiveBroadcastContentById(int _id)
    //{
    //    Sprite texture = Resources.Load<Sprite>("Icon/LiveBroadcast/" + _id + "_content");
    //    return texture;
    //}


    //public Texture2D GetGameStyleIconByName(string _name)
    //{
    //    Texture2D texture = Resources.Load<Texture2D>("Icon/GameContentIcon/" + _name);
    //    return texture;
    //}

    //public Texture2D GetPlatformIconByName(string _name)
    //{
    //    Texture2D icon = Resources.Load<Texture2D>("Icon/PlatformIcon/" + _name);
    //    return icon;
    //}


    //public Texture2D GetFoodDrinkIconByName(string _name)
    //{
    //    Texture2D icon = Resources.Load<Texture2D>("Icon/FoodDrink/" + _name);
    //    return icon;
    //}

    //public Texture2D GetHomeFurnishingIconByName(string _name)
    //{
    //    Texture2D icon = Resources.Load<Texture2D>("Icon/FurnitureIcon/" + _name);
    //    if (null == icon)
    //        Debug.LogError("------GetHomeFurnishingIconByName----_name:" + _name);
    //    return icon;
    //}

    //public GameObject GetBikeObj()
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("Misc/Bike");
    //    return GameObject.Instantiate(mPrefabe);
    //}

    //public GameObject GetHomeFurnishingByName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("HomeFurnishing/" + _name);
    //    if (null != mPrefabe)
    //        return GameObject.Instantiate(mPrefabe);
    //    Debug.LogError("----GetHomeFurnishingByName---:" + _name);
    //    return null;
    //}

    //public Texture2D GetCardIconByType(int _typeId)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/Card/" + _typeId);
    //    return image;
    //}

    //public Texture2D GetContentIconByType(E_RoleType _typeId)
    //{

    //    Texture2D image = Resources.Load<Texture2D>("Icon/ContentType/" + (int)_typeId);
    //    return image;
    //}

    ////public Texture2D GetContentEffectIconById(ESettingId _settingId)
    ////{
    ////    string iconName = "";
    ////    switch (_settingId)
    ////    {
    ////        case ESettingId.eSetting1:
    ////            iconName = "icon_Attribute_caoZuo";
    ////            break;
    ////        //case ESettingId.eOriginal:
    ////        //    iconName = "icon_Attribute_heZuo";
    ////        //    break;
    ////        case ESettingId.eSetting2:
    ////            iconName = "icon_Attribute_ceLue";
    ////            break;
    ////        case ESettingId.eSetting3:
    ////            iconName = "icon_Attribute_shouJi";
    ////            break;
    ////        case ESettingId.eSetting4:
    ////            iconName = "icon_Attribute_Tv";
    ////            break;
    ////    }

    ////    Texture2D image = Resources.Load<Texture2D>("Icon/ContentEffect/" + iconName);
    ////    return image;
    ////}
    //public Texture2D GetSettingTechIconById(int _type)
    //{
    //    string iconName = "";
    //    if (_type == 0)
    //        iconName = "icon_tec_01";
    //    else
    //        iconName = "icon_tec_02";

    //    Texture2D image = Resources.Load<Texture2D>("Icon/SettingIcon/" + iconName);
    //    return image;
    //}
    //public Texture2D GetSettingIconById(ESettingId _settingId)
    //{
    //    string iconName = "";
    //    switch (_settingId)
    //    {
    //        case ESettingId.eSetting1:
    //            iconName = "icon_ceHua_caoZuo";
    //            break;
    //        case ESettingId.eSetting2:
    //            iconName = "icon_ceHua_ceLue";
    //            break;
    //        case ESettingId.eSetting3:
    //            iconName = "icon_ceHua_shouJi";
    //            break;
    //        case ESettingId.eSetting4:
    //            iconName = "icon_ceHua_Juese";
    //            break;
    //        case ESettingId.eSetting5:
    //            iconName = "icon_ceHua_DongXiao";
    //            break;
    //        case ESettingId.eSetting6:
    //            iconName = "icon_ceHua_ChangJIng";
    //            break;
    //    }

    //    Texture2D image = Resources.Load<Texture2D>("Icon/SettingIcon/" + iconName);
    //    return image;
    //}


    //public Texture2D GetArtTypeIconById(EArtId _artId)
    //{
    //    string iconName = "";
    //    switch (_artId)
    //    {
    //        case EArtId.eCharactersPainting:
    //            iconName = "icon_art_Char";
    //            break;

    //        case EArtId.eUIEffect:
    //            iconName = "icon_art_UI";
    //            break;
    //        case EArtId.eActionPainting:
    //            iconName = "icon_art_Ani";
    //            break;
    //        case EArtId.eScenePainting:
    //            iconName = "icon_art_Scene";
    //            break;
    //    }

    //    Texture2D image = Resources.Load<Texture2D>("Icon/ArtTypeIocn/" + iconName);
    //    return image;
    //}

    //public Texture2D GetEventEffectIconByType(EEventEffectType _effectType)
    //{
    //    int typeId = (int)_effectType;
    //    string iconName = "effect_" + typeId;
    //    Texture2D image = Resources.Load<Texture2D>("Icon/EventEffectType/" + iconName);
    //    return image;
    //}

    //public Texture2D GetArtPeripheryIconByName(string _iconName)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/Periphery/" + _iconName);
    //    return image;
    //}


    //public Texture2D GetMilestoneIconByName(string _iconName)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/Milestone/" + _iconName);
    //    return image;
    //}
    //public GameObject GetPassiveSkillEffectByname(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("PassiveSkills/" + _name);
    //    return GameObject.Instantiate(mPrefabe);
    //}

    //public Texture2D GetRoleSkillIconByName(string _iconName)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/RoleSkillIcon/" + _iconName);
    //    return image;
    //}

    //public Texture2D GetRoleActiveSkillIconByName(string _iconName)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/ActiveSkillIcon/" + _iconName);
    //    return image;
    //}

    //public GameObject GetStoryByName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("Story/" + _name);
    //    return GameObject.Instantiate(mPrefabe);
    //}
    //public GameObject GetGameShowItemsByName(string _name)
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("GameShowItems/" + _name);
    //    return GameObject.Instantiate(mPrefabe);
    //}


    //public Texture2D GetRoleBodyIconByName(string _iconName)
    //{
    //    Debug.LogError("--_iconName---:" + _iconName);
    //    Texture2D image = Resources.Load<Texture2D>("Icon/RoleBody/" + _iconName);
    //    return image;
    //}

    //public Texture2D GetProfessionIconByName(string _iconName)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/RoleAttIcon/" + _iconName);
    //    return image;
    //}
    //public Texture2D GetRegionIconByName(string _iconName)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/RegionIcon/" + _iconName);
    //    return image;
    //}

    //public Texture2D GetDutiesIconByName(string _iconName)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/DutiesIcon/" + _iconName);
    //    return image;
    //}

    //public Texture2D GetStateIconBytype(E_EmployeeMentalityType _type)
    //{
    //    string iconName = "";
    //    switch (_type)
    //    {
    //        case E_EmployeeMentalityType.eAnxious:
    //            iconName = "icon_Anxious";
    //            break;

    //        case E_EmployeeMentalityType.eLaziness:
    //            iconName = "icon_Lazy";
    //            break;

    //        case E_EmployeeMentalityType.eIrritability:
    //            iconName = "icon_Lrritability";
    //            break;

    //    }
    //    Texture2D image = Resources.Load<Texture2D>("Icon/RoleStateIcon/" + iconName);
    //    return image;
    //}


    //public GameObject GetBrokenEffectForRoom()
    //{
    //    GameObject mPrefabe = Resources.Load<GameObject>("Effect/Upgrade_01");
    //    return GameObject.Instantiate(mPrefabe);
    //}
    //public Texture2D GetBossSkillIconByName(string _iconName)
    //{
    //    Texture2D image = Resources.Load<Texture2D>("Icon/BossSkillIcon/" + _iconName);
    //    return image;
    //}
}