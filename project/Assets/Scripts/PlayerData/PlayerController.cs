using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //public GameObject Dest;
    public Camera cam;
    private NavMeshAgent agent;
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(Dest.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mAnimator.SetInteger("PlayerState", 1);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if(Physics.Raycast(ray,out Hit))
            {
                agent.SetDestination(Hit.point);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "BridgeTrigger")
        {
            Debug.Log("碰到了");
            //Dest.SetActive(true);
            NavmeshDirector.Instance.BuildNav(); 
        }
    }
}
