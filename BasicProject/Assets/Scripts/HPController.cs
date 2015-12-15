using UnityEngine;
using System.Collections;
using RAIN.Core;

public class HPController : MonoBehaviour {

	private int _hitPoints;
	private AIRig tRig;
	// Use this for initialization
	void Start () {
//		ai = this.gameObject.GetComponent<RAIN.Core.AIRig> ();
//		_hitPoints = (int)ai.AI.WorkingMemory.GetItem("hitPoints");
//		Debug.Log (this.gameObject.name + " hit points are " + _hitPoints.toString());
		_hitPoints = 135;

		tRig = gameObject.GetComponentInChildren<AIRig>();
		if (tRig != null)
			tRig.AI.WorkingMemory.SetItem<int>("hitPoints", _hitPoints);
//		if (tag == "Hellephant") {
//			hitPoints = 200;
//		} else if (tag == "Bunny") {
//			hitPoints = 100;
//		}
	}
	
	// Update is called once per frame
	void Update () {
		if(_hitPoints <= 0){
			Destroy(this.gameObject);
		}
	}

	public void damage(){
		_hitPoints = _hitPoints - 10;
		if (tRig != null)
			tRig.AI.WorkingMemory.SetItem<int>("hitPoints", _hitPoints);
		Debug.Log ("DAMAGED! HP=" + _hitPoints.ToString());
	}
}
