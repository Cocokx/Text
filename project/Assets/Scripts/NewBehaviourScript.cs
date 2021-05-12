using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("生成UI_Begin");
        UIManager.Instance.CreateUIViewInstance<UI_Lift>();
        //UIManager.Instance.CreateUIViewInstance<UI_BackPack>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
