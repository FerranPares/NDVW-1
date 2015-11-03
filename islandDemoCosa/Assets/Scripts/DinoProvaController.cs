using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class DinoProvaController : MonoBehaviour {

    //public SteerForPoint cSteering;
	public SteerToFollow cSteering;
    public Animator animator;
	public int speed = 5;
	public Transform target;
	public float stopradius;


	// Use this for initialization
	void Start () {
		cSteering = GetComponent<SteerToFollow>();
        animator = GetComponent<Animator>();
		cSteering.Target = target;
		animator.SetInteger("speed", speed);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currPos = transform.position;
		Vector3 targetPos = cSteering.Target.position;

		if (Vector3.Distance(currPos, targetPos) < stopradius) {
            cSteering.enabled = false;
            animator.SetInteger("speed", 0);
        }   
	}
}
