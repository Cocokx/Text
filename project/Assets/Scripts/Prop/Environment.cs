using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Environment : MonoSingleton<Environment>
{
    //GameObject mSceneProp;
    Prop[] prop;
    Key[] keys;
    public Room[] rooms;
    public List<Transform> Lift;
    public Plane plane;
    public TimeMachine[] timeMachinePos;
    
    // Start is called before the first frame update
    private void Start()
    {
        InitProp();
        InitKey();
        InitRoom();
        Player.Instance.transform.GetComponent<BoxCollider>().enabled = false;
        Player.Instance.canTrigger = false;
    }

    public void InitTimeMachinePos()
    {
        timeMachinePos = FindObjectsOfType<TimeMachine>();
        GameDataManager.Instance.mTimeMechinePos = new Dictionary<E_TimeMachine, Vector3>();
        for(int i = 0; i < timeMachinePos.Length; i++)
        {
            GameDataManager.Instance.mTimeMechinePos.Add(timeMachinePos[i].machine, timeMachinePos[i].transform.position);
        }
    }
    public void TimeEffect(Vector3 pos)
    {
        GameObject go = Resources.Load<GameObject>("UI/Time/TimeEffect");
        go = GameObject.Instantiate(go, pos, Quaternion.identity);
    }
    void InitRoom()
    {
        rooms = FindObjectsOfType<Room>();
        plane = FindObjectOfType<Plane>();
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
        Debug.Log("出现Key");
        if (keys == null)
            InitKey();
        if (null != keys && keys.Length > 0)
        {
            Debug.Log("存在key");
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
