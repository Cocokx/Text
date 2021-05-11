using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackItemViews : MonoBehaviour
{
    public List<BackPackItemView> mItemList;

    public void Init()
    {
        foreach (BackPackItemView item in mItemList)
        {
            item.Init();
        }
    }
}
