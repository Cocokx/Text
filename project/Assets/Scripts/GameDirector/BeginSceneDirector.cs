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
        List<int> listShowPropId = new List<int>();
        if (GameDataManager.Instance.mListUsedPropId != null)
        {
            listShowPropId = GameDataManager.Instance.mListUsedPropId;
        }
        for(int i = 0; i < listShowPropId.Count; i++)
        {
            TableGameKey.ObjTabletGameKey objTabletGameKey
            = ClientTableDataManager.Instance.GetTabletGameKeyById(listShowPropId[i]);
            if (objTabletGameKey != null)
            {
                Environment.Instance.AppearProp(objTabletGameKey);
            }
        }
        
    }
}
