using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Playables;
public class BeginSceneDirector : MonoSingleton<BeginSceneDirector>
{
    public PlayableDirector playableDirector;
    Cinemachine.CinemachineDollyCart cart;
    // Start is called before the first frame update
    void Start()
    {
        InitScene();
        if(SceneInfoManager.Instance.IsInScene1)
            InitTimeLine();
        if (GameDirector.Instance.TimeTravel)
        {
            Debug.Log(GameDirector.Instance.machine);
            GameDirector.Instance.TimeTravel = false;
            GameObject go = Resources.Load<GameObject>("Time/TimeEffect");
            Debug.Log(go.name);
            go = Instantiate(go, GameDataManager.Instance.mTimeMechinePos[GameDirector.Instance.machine], Quaternion.identity);
            

            Destroy(go, 1);
        }
            
        //Debug.Log("道具"+GameDataManager.Instance.mListUsedPropId.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitTimeLine()
    {
        playableDirector = FindObjectOfType<PlayableDirector>();
        cart = FindObjectOfType<Cinemachine.CinemachineDollyCart>();
        if (null != cart)
            cart.m_Speed = 0;
    }
    public void PlayTimeline()
    {
        playableDirector.Play();
        cart.m_Speed = 1;
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
