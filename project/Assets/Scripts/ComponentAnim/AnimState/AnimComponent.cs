using UnityEngine;

public class AnimComponent : MonoBehaviour
{
    private AnimFSM FSM;
    private Animation mAnimation;
    public void HandleAction(E_PlayerState state)
    {
        FSM.DoAction(state);
    }
    public void Awake()
    {
        mAnimation = GetComponent<Animation>();
        FSM = new AnimFSMPlayer(mAnimation);
    }
    void Start()
    {
        FSM.Initialize();
    }
    public void Deactivate()
    {
        FSM.Reset();
    }
}
