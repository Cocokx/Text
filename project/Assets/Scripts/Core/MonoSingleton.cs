using UnityEngine;
using System.Collections;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static T s_instance = null;

    public static T Instance
    {
        get
        {
            return s_instance;
        }
    }

    protected virtual void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this as T;
        }
    }
    protected virtual void OnDestroy()
    {
        s_instance = null;
    }
}

