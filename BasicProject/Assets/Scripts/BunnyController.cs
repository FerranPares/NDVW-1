using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

[RequireComponent(typeof(SteerForPoint))]
public class BunnyController : MonoBehaviour {

	public SteerForPoint cSteering;
	public Animator animator;

	// Use this for initialization
	void Start () {
		cSteering = GetComponent<SteerForPoint> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(cSteering.ReportedMove && !cSteering.ReportedArrival){
			animator.SetBool ("IsWalking", true);
		}else{
			animator.SetBool ("IsWalking", false);
		}
	}
}
