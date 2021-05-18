using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoSingleton<CamManager>
{
    
    Cam[] cams;
    // Update is called once per frame
    private void Start()
    {
        cams = transform.GetComponentsInChildren<Cam>(true);
    }
    public void ChangeCam(ECameraState state)
    {
        cams = transform.GetComponentsInChildren<Cam>(true);
        for (int i=0; i < cams.Length; i++)
        {
            if(null!= cams[i].transform.GetComponent<CinemachineVirtualCamera>())
            {
                if (cams[i].state == state)
                {
                    cams[i].transform.GetComponent<CinemachineVirtualCamera>().Priority = 100;
                }
                else
                {
                    cams[i].transform.GetComponent<CinemachineVirtualCamera>().Priority = 10;
                }
            }
            else if(null!= cams[i].transform.GetComponent<CinemachineFreeLook>())
            {
                if (cams[i].state == state)
                {
                    cams[i].transform.GetComponent<CinemachineFreeLook>().Priority = 100;
                }
                else
                {
                    cams[i].transform.GetComponent<CinemachineFreeLook>().Priority = 10;
                }
            }
            
        }
    }
}
