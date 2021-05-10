using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshDirector : MonoSingleton<NavmeshDirector>
{
    NavMeshSurface[] navMeshSurface;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
        //BuildNav();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuildNav()
    {
        navMeshSurface = FindObjectsOfType<NavMeshSurface>();
        foreach (NavMeshSurface nav in navMeshSurface)
        {
            nav.BuildNavMesh();
        }
    }
}
