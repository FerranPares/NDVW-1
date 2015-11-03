using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class DinoWander : MonoBehaviour 
{
	private float minX, maxX, minZ, maxZ;

	public SteerForPoint cSteering;
	
	public int movementSpeed = 5;
	public float rotSpeed = 2.0f;

	public Animator animator;
	public float deltaX = 10;
	public float deltaZ = 10;
	
	// Use this for initialization
	void Start () 
	{
		minX = transform.position.x - deltaX;
		maxX = transform.position.x + deltaX;
		
		minZ = transform.position.z - deltaZ;
		maxZ = transform.position.z + deltaZ;

		//Animation
		animator = GetComponent<Animator>();
		animator.SetInteger("speed", movementSpeed);

		//Steering
		cSteering = GetComponent<SteerForPoint>();
		cSteering.TargetPoint = GetNextPosition();;
		cSteering.enabled = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (cSteering.ReportedArrival) {
			Debug.Log ("A cagar a la via");
			cSteering.TargetPoint = GetNextPosition ();
		}
	}
	
	Vector3 GetNextPosition()
	{
		return new Vector3(Random.Range(minX, maxX), transform.position.y , Random.Range(minZ, maxZ));
	}
}

