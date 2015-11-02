using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class Robot : MonoBehaviour {

    public SteerForPoint cSteering;
    public Animator animator;


	// Use this for initialization
	void Start () {
        cSteering = GetComponent<SteerForPoint>();
        animator = GetComponent<Animator>();

        cSteering.enabled = true;
        animator.SetInteger("speed", 5);
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 robotCurrPos;
        Vector3 robotTargetPos = new Vector3();

        robotCurrPos = transform.position;

        robotTargetPos = cSteering.TargetPoint;
        if (Vector3.Distance(robotCurrPos, robotTargetPos) < 3.0) {
            Debug.Log("STOP, disable steering, Transition to iddle");
            cSteering.enabled = false;
            animator.SetInteger("speed", 0);
        }   
	}
}
