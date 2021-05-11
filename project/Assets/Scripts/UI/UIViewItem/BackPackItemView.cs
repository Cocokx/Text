using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackPackItemView : MonoBehaviour
{
    public Button mBtn;
    public RawImage mIcon;
    public Text mTxtName;

    public delegate void ItemSelectedDelegate(TableGameKey.ObjTabletGameKey _info);
    public ItemSelectedDelegate onItemSelectedDelegate = null;
    TableGameKey.ObjTabletGameKey mInfo;
    public void Init()
    {
        mBtn.onClick.RemoveAllListeners();
        mBtn.onClick.AddListener(BtnClickHandler);
    }
    public void SetItemData(TableGameKey.ObjTabletGameKey _info)
    {
        mInfo = _info;
        mIcon.texture = GameResourceManager.Instance.GetBackPackIconByName(_info.mTexture);
        mTxtName.text = _info.mName;
    }

    void BtnClickHandler()
    {
        onItemSelectedDelegate(mInfo);
    }
}
