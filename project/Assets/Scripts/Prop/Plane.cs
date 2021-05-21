using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Plane : MonoBehaviour
{
    public bool startPlane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startPlane)
        {
            if(transform.GetComponentInParent<CinemachineDollyCart>().m_Position>79)
            {
                Player.Instance.agent.enabled = true;
                GameDirector.Instance.source[1].Stop();
                startPlane = false;
            }
        }
    }
}
