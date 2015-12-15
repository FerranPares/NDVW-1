using UnityEngine;
using System.Collections;

public class EggCollisioner : MonoBehaviour {

	public GameObject boy;

	double hp;
	int peopleEating;
	int bunniesEting;
	int hellephantsEating;

	public float peopleVel = 0.01f;
	public float bunnyVel = 0.1f;
	public float hellephantVel = 1.0f;

	// Use this for initialization
	void Start () {
		peopleEating = 0;
		bunniesEting = 0;
		hellephantsEating = 0;
		hp = 100.0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Aumentar progressivament
		if ( (peopleEating == 0) && (bunniesEting == 0) && (hellephantsEating == 0) )
		{
			hp = hp + 0.1;
		}

		if(hp > 200.0)
		{
			Debug.Log("Egg Health: " + hp.ToString() + ", Maximum hp reached!");
			// Instantiate BoyBot and destroy egg

//			Vector3 spawnPoint = transform.position;	
//			Destroy(this.gameObject);
//			Instantiate(boy, spawnPoint, Quaternion.identity);


		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Player") {
			peopleEating = peopleEating + 1;
		}else if(col.gameObject.tag == "Bunny"){
			bunniesEting = bunniesEting + 1;
		}else if(col.gameObject.tag == "Hellephant"){
			hellephantsEating = hellephantsEating + 1;
		}
	}

	void OnCollisionStay (Collision col)
	{
		hp = hp - peopleVel * peopleEating - bunnyVel * bunniesEting - hellephantVel * hellephantsEating;
		Debug.Log("Egg Health: " + hp.ToString());

		if(hp <= 0.0)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionExit (Collision col)
	{
		peopleEating = peopleEating - 1;
	}
}
