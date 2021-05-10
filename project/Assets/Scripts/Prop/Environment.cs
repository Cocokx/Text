using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoSingleton<Environment>
{
    //GameObject mSceneProp;
    Prop[] prop;

    // Start is called before the first frame update
    private void Start()
    {
        InitProp();
    }
    public void InitProp()
    {
        prop = transform.GetComponentsInChildren<Prop>(true);
        if (null != prop && prop.Length > 0)
        {
            for (int i = 0; i < prop.Length; i++)
            {
                string objName = prop[i].gameObject.name;
                
                TableGameKey.ObjTabletGameKey allProp
                    = ClientTableDataManager.Instance.GetTabletGameKeyByObjName(objName);
                if (null != allProp)
                {
                    prop[i].ID = allProp.mId;
                    Debug.Log(prop[i].ID);
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
                    break;
                }
            }
        }
    }
}
