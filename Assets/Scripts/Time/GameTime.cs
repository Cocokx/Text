using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoSingleton<GameTime>
{
    bool mIsLogicBlock;
    bool mHasUiPopup;
    public bool LogicBlock
    {
        get{ return mIsLogicBlock; }
        set{ mIsLogicBlock = value; }
    }

    public bool HasUiPopup
    {
        get { return mHasUiPopup; }
        set{ mHasUiPopup = value; }
    }
}
