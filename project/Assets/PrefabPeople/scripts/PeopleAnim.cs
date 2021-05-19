using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleAnim : MonoBehaviour
{

    private Animator animator;
    public string pose;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(pose, true);
    }
}
