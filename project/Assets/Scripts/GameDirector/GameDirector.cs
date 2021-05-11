using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance = null;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneInfoManager.Instance.IsInScene1 = true;
    }   
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
