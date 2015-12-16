using UnityEngine;
using System.Collections;
using RAIN.Core;

public class HPController : MonoBehaviour {

	private int _hitPoints;
	private AIRig _tRig;
	private GameObject _actualAttacker;
	// Use this for initialization
	void Start () {
//		ai = this.gameObject.GetComponent<RAIN.Core.AIRig> ();
//		_hitPoints = (int)ai.AI.WorkingMemory.GetItem("hitPoints");
//		Debug.Log (this.gameObject.name + " hit points are " + _hitPoints.toString());
		_hitPoints = 135;
		_actualAttacker = null;

		_tRig = gameObject.GetComponentInChildren<AIRig>();
		if (_tRig != null)
			_tRig.AI.WorkingMemory.SetItem<int>("hitPoints", _hitPoints);
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

	public void damage(GameObject attacker){
//		if (_tRig != null) {
//			if (_actualAttacker == null){
//				_actualAttacker = attacker;
//				_tRig.AI.WorkingMemory.SetItem<int> ("attacker", _actualAttacker);
//			}
//		}
		_hitPoints = _hitPoints - 10;
		_actualAttacker = attacker;
		if (_tRig != null) {
			_tRig.AI.WorkingMemory.SetItem<int> ("hitPoints", _hitPoints);
			_tRig.AI.WorkingMemory.SetItem<GameObject> ("attacker", _actualAttacker);
		}
	}
}
