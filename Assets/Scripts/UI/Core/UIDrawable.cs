using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDrawable : MonoBehaviour
{
    protected GameObject m_cachedGo;
    protected Transform m_cachedTransform;

    public GameObject CachedGameObject { get { return m_cachedGo; } }
    public Transform CachedTransform { get { return m_cachedTransform; } }


    private void Awake()
    {
        onAwake();
    }

    private void Update()
    {
        onUpdate();
    }

    private void OnDestroy()
    {
        onDestroy();
    }

    protected virtual void onAwake()
    {
        m_cachedGo = this.gameObject;
        m_cachedTransform = this.transform;
    }

    protected virtual void onUpdate()
    {
    }

    protected virtual void onDestroy()
    {
    }
}
