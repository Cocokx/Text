using System;
using System.Collections.Generic;
using UnityEngine;
    
public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    private Dictionary<Type, string> m_dicViewType = new Dictionary<Type, string>();
    private Dictionary<Type, UIView> m_dicViewInstance = new Dictionary<Type, UIView>();
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        m_dicViewType.Add(typeof(UI_Begin), "UI_Begin");
        m_dicViewType.Add(typeof(UI_Lift), "UI_Lift");
        m_dicViewType.Add(typeof(UI_BackPack), "UI_BackPack");
    }
    public T CreateUIViewInstance<T>() where T : UIView
    {
        UIView result = null;
        System.Type actType = typeof(T);

        if (!m_dicViewInstance.TryGetValue(actType, out result))
        {
            string strName = string.Empty;
            if (!m_dicViewType.TryGetValue(actType, out strName))
            {
                Debug.LogError("Could not find view " + actType);
                return null;
            }
            System.Text.StringBuilder sbFullPath = new System.Text.StringBuilder();
            sbFullPath.Append("UI/View/");
            sbFullPath.Append(strName);
            GameObject go = Resources.Load<GameObject>(sbFullPath.ToString());
            go = GameObject.Instantiate(go, this.gameObject.transform);
            go.gameObject.name = actType.ToString();
            result = go.GetComponent<T>();

            if (null == result)
            {
                Debug.LogError("Could not find " + actType + " in " + strName);
                return null;
            }
            m_dicViewInstance.Add(actType, result);
        }

        return result as T;
    }
    public T GetUIViewInstance<T>() where T : UIView
    {
        UIView result = null;
        System.Type actType = typeof(T);
        m_dicViewInstance.TryGetValue(actType, out result);
        return result as T;
    }

    public void CloseUIViewInstance<T>() where T : UIView
    {
        System.Type actType = typeof(T);
        UIView target = null;
        if (m_dicViewInstance.TryGetValue(actType, out target))
        {
            GameObject.Destroy(target.gameObject);
            m_dicViewInstance.Remove(actType);
        }
    }

    public void CloseAll()
    {
        foreach (var iter in m_dicViewInstance.Values)
        {
            GameObject.Destroy(iter.gameObject);
        }
        m_dicViewInstance.Clear();
    }
    public void CloseAllExcept(Type except)
    {
        UIView viewExcept = null;
        foreach (var iter in m_dicViewInstance.Values)
        {
            if (iter.GetType() == except)
            {
                viewExcept = iter;
                continue;
            }
            GameObject.Destroy(iter.gameObject);
        }
        m_dicViewInstance.Clear();
        if (viewExcept)
            m_dicViewInstance.Add(except, viewExcept);
    }

    public void CloseAllExcept(List<Type> excepts)
    {
        List<UIView> viewExcepts = new List<UIView>();
        foreach (var iter in m_dicViewInstance.Values)
        {
            if (excepts.Contains(iter.GetType()))
            {
                viewExcepts.Add(iter);
                continue;
            }
            GameObject.Destroy(iter.gameObject);
        }
        m_dicViewInstance.Clear();
        foreach (UIView v in viewExcepts)
            m_dicViewInstance.Add(v.GetType(), v);
    }
}
