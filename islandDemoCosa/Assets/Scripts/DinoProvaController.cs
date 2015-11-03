using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class DinoProvaController : MonoBehaviour {

    //public SteerForPoint cSteering;
    public SteerToFollow cSteering;
    public Animator animator;


	// Use this for initialization
	void Start () {
        //cSteering = GetComponent<SteerForPoint>();
        cSteering = GetComponent<SteerToFollow>();
        animator = GetComponent<Animator>();

// cSteering.enabled = true;
        animator.SetInteger("speed", 5);
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 robotCurrPos;
        Vector3 robotTargetPos = new Vector3();
        Debug.Log("AKiiiiiiiiiiiiiii11111111111");
        robotCurrPos = transform.position;

        //robotTargetPos = cSteering.TargetPoint;
        robotTargetPos = cSteering.Target.position;
        Debug.Log("AKiiiiiiiiiiiiiii2222222222222");
        if (Vector3.Distance(robotCurrPos, robotTargetPos) < 10.0) {
            Debug.Log("STOP, disable steering, Transition to iddle");
            cSteering.enabled = false;
            animator.SetInteger("speed", 0);
            Debug.Log("AKiiiiiiiiiiiiiii33333333");
        }   
	}
}
