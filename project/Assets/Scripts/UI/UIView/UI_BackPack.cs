using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperScrollView;
public class UI_BackPack : UI_PopUpView
{
    public Button mBtnClose;
    public Transform mBackPackRoot;
    public LoopListView2 mLoopListView;
    public Button mBtnConfirm;
    List<TableGameKey.ObjTabletGameKey> mListAllGameKey;
    List<TableGameKey.ObjTabletGameKey> mListGameKey;
    TableGameKey.ObjTabletGameKey mWillChooseGameKey;
    Dictionary<int, BackPackItemView> mDicBackPackViews;

    const int mItemCountPerRow = 2;
    int mItemTotalCount = 100;
    protected override void onAwake()
    {
        base.onAwake();
        InitView();
    }
    void InitView()
    {
        mListAllGameKey = ClientTableDataManager.Instance.GetAllTabletGameKey();
        mListGameKey = new List<TableGameKey.ObjTabletGameKey>();
        Debug.Log(mListAllGameKey.Count);
        for (int i = 0; i < mListAllGameKey.Count; i++)
        {
            //在此检测是否解锁
            if (GameDataManager.Instance.CheckIsGetUnuseProp(mListAllGameKey[i]))
            {
                
                mListGameKey.Add(mListAllGameKey[i]);
            }
        }
        mItemTotalCount = mListGameKey.Count;
        int count = mItemTotalCount / mItemCountPerRow;
        if (mItemTotalCount % mItemCountPerRow > 0)
        {
            count++;
        }
        mDicBackPackViews = new Dictionary<int, BackPackItemView>();
        mLoopListView.InitListView(count, OnGetItemByIndex);
    }
    LoopListViewItem2 OnGetItemByIndex(LoopListView2 listView, int rowIndex)
    {
        if (rowIndex < 0)
        {
            return null;
        }
        //create one row
        LoopListViewItem2 item = listView.NewListViewItem("RowPrefab");
        BackPackItemViews itemScript = item.GetComponent<BackPackItemViews>();

        if (item.IsInitHandlerCalled == false)
        {
            item.IsInitHandlerCalled = true;
            itemScript.Init();
        }
        //update all items in the row
        for (int i = 0; i < mItemCountPerRow; ++i)
        {
            int itemIndex = rowIndex * mItemCountPerRow + i;
            if (itemIndex >= mItemTotalCount)
            {
                itemScript.mItemList[i].gameObject.SetActive(false);
                continue;
            }
            itemScript.mItemList[i].gameObject.SetActive(true);
            itemScript.mItemList[i].SetItemData(mListGameKey[itemIndex]);
            itemScript.mItemList[i].onItemSelectedDelegate = OnBackPackUpdate;

            mDicBackPackViews[mListGameKey[itemIndex].mId] = itemScript.mItemList[i];
        }
        return item;
    }
    void OnBackPackUpdate(TableGameKey.ObjTabletGameKey _info)
    {
        mWillChooseGameKey = _info;
        
        
    }
    protected override void InitEvent()
    {
        base.InitEvent();
        mBtnClose.onClick.AddListener(BtnCloseClickHandler);
        mBtnConfirm.onClick.AddListener(BtnConfirmClickHandler);
    }
    protected override void ShowView()
    {
        base.ShowView();

    }
    protected override void CloseView()
    {
        base.CloseView();
        UIManager.Instance.CloseUIViewInstance<UI_BackPack>();
    }
    void BtnCloseClickHandler()
    {
        HideView();
    }
    void BtnConfirmClickHandler()
    {
        HideView();
        Debug.Log("碰撞体"+Player.Instance.triggerType);
        if(null!= mWillChooseGameKey && (E_Trigger)mWillChooseGameKey.mEffectId == Player.Instance.triggerType)
        {
            //使用影响,需写
            Debug.Log("使用："+mWillChooseGameKey.mEffet);
            GameDataManager.Instance.UseProp(mWillChooseGameKey);
            if (mWillChooseGameKey.mEffet == E_KeyEffect.E_Creat)
            {
                
                Environment.Instance.AppearProp(mWillChooseGameKey);
            }
            else if(mWillChooseGameKey.mEffet == E_KeyEffect.E_Unlock)
            {
                Environment.Instance.AppearProp(mWillChooseGameKey);
            }
            //Environment.Instance.DisAppearKeys(mWillChooseGameKey);

        }
        mWillChooseGameKey = null;
        RefershFurnishingList();

    }
    void RefershFurnishingList()
    {
        mLoopListView.RefreshAllShownItem();
    }
}
