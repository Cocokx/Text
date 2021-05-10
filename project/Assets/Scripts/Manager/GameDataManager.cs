using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    public List<int> mListUsedPropId;
    static GameDataManager instance;
    public static GameDataManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new GameDataManager();
            }

            return instance;
        }
    }
    public void UpdateUsedProp(int _id)
    {
        if (null == mListUsedPropId)
            mListUsedPropId = new List<int>();
        mListUsedPropId.Add(_id);
    }
    public bool CheckIsUsedProp(int _id)
    {
        if (null != mListUsedPropId)
            return mListUsedPropId.IndexOf(_id) > -1;

        return false;
    }
}
