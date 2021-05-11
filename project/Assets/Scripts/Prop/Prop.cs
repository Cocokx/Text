using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    int mId;
    TableGameKey.ObjTabletGameKey mInfo;
    private void Awake()
    {
        if (gameObject.name.IndexOf("(Clone)") > -1)
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        mInfo = ClientTableDataManager.Instance.GetTabletGameKeyByObjName(gameObject.name);
        if (null != mInfo)
            mId = mInfo.mId;
        Debug.Log("id" + mId);
    }

    public int ID
    {
        get { return mId; }
        set { mId = value; }
    }
}
