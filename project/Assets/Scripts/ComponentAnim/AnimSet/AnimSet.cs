using UnityEngine;
[System.Serializable]
public class AnimSet : MonoSingleton<AnimSet>
{
    public string GetIdleAnim()
    {
        string animaName = "Relax";
        return animaName;
    }
    public string GetWalkAnim()
    {
        string animaName = "Walk";
        return animaName;
    }
}