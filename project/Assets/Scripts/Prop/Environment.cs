using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoSingleton<Environment>
{
    //GameObject mSceneProp;
    Prop[] prop;
    Key[] keys;
    // Start is called before the first frame update
    private void Start()
    {
        InitProp();
        InitKey();
    }
    public void InitProp()
    {
        prop = transform.GetComponentsInChildren<Prop>(true);
        if (null != prop && prop.Length > 0)
        {
            for (int i = 0; i < prop.Length; i++)
            {
                string objName = prop[i].gameObject.name;
                
                TableGameKey.ObjTabletGameKey effectProp
                    = ClientTableDataManager.Instance.GetTabletGameKeyByEffectObjName(objName);
                if (null != effectProp)
                {
                    prop[i].ID = effectProp.mId;
                    Debug.Log(prop[i].ID);
                }
            }
        }
    }
    public void InitKey()
    {
        keys = transform.GetComponentsInChildren<Key>(true);
        if (null != keys && keys.Length > 0)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                string objName = keys[i].gameObject.name;

                TableGameKey.ObjTabletGameKey key
                    = ClientTableDataManager.Instance.GetTabletGameKeyByObjName(objName);
                if (null != key)
                {
                    keys[i].ID = key.mId;
                    Debug.Log(keys[i].ID);
                }
            }
        }
    }
    public void AppearKey(TableGameKey.ObjTabletGameKey _info)
    {
        if (keys == null)
            InitKey();
        if (null != keys && keys.Length > 0)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                Key keyItem = keys[i];
                TableGameKey.ObjTabletGameKey keyItemInfo = ClientTableDataManager.Instance.GetTabletGameKeyById(keyItem.ID);

                if (null != keyItemInfo && keyItemInfo.mId == _info.mId)
                {
                    keyItem.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
    public void DisAppearKeys(TableGameKey.ObjTabletGameKey _info)
    {
        if (keys == null)
            InitKey();
        if (null != keys && keys.Length > 0)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                Key keyItem = keys[i];
                TableGameKey.ObjTabletGameKey keyItemInfo = ClientTableDataManager.Instance.GetTabletGameKeyById(keyItem.ID);

                if (null != keyItemInfo && keyItemInfo.mId == _info.mId)
                {
                    keyItem.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
    public void AppearProp(TableGameKey.ObjTabletGameKey _info)
    {
        if(prop==null)
            InitProp();
        if (null != prop && prop.Length > 0)
        {
            for (int i = 0; i < prop.Length; i++)
            {
                Prop propItem = prop[i];
                TableGameKey.ObjTabletGameKey propItemInfo = ClientTableDataManager.Instance.GetTabletGameKeyById(propItem.ID);

                if (null != propItemInfo && propItemInfo.mId == _info.mId)
                {
                    propItem.gameObject.SetActive(true);
                    propItem.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}
