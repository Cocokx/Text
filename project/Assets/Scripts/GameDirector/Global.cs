using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global Instance = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void DoSomeThings()
    {
        Debug.Log("DoSomeThings");
    }

    void Start()
    {
        Debug.Log("Start");
    }
}
