using UnityEngine;
using System.Collections.Generic;

public class BeginSceneDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitScene();
        //Debug.Log("道具"+GameDataManager.Instance.mListUsedPropId.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitScene()
    {
        Dictionary<TableGameKey.ObjTabletGameKey, E_PropState> mDicProp = new Dictionary<TableGameKey.ObjTabletGameKey, E_PropState>();
        if (GameDataManager.Instance.mDicProp != null)
        {
            mDicProp = GameDataManager.Instance.mDicProp;
            foreach (var item in mDicProp.Keys)
            {
                Debug.Log(mDicProp[item]);
                if (mDicProp[item]==E_PropState.E_PickedUsed)
                {
                    Environment.Instance.AppearProp(item);
                }
                else if (mDicProp[item] == E_PropState.E_UnPicked)
                {
                    Environment.Instance.AppearKey(item);
                }
            }
        }
        
        
    }
}
