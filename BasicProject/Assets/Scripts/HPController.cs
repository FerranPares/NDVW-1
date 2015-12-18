using UnityEngine;
using System.Collections;
using RAIN.Core;

public class HPController : MonoBehaviour {

	private int _hitPoints;
	private AIRig _tRig;
	private GameObject _actualAttacker;

    public int _hellephantHP = 500;
    public int _bunnyHP = 100;
    public int _boyHP = 100;

    public int _hellephantDamage = 20;
    public int _bunnyDamage = 10;
    public int _boyDamage = 10;


    // Use this for initialization
    void Start () {
//		ai = this.gameObject.GetComponent<RAIN.Core.AIRig> ();
//		_hitPoints = (int)ai.AI.WorkingMemory.GetItem("hitPoints");
		_hitPoints = 135;
		_actualAttacker = null;

		_tRig = gameObject.GetComponentInChildren<AIRig>();
		if (_tRig != null)
			_tRig.AI.WorkingMemory.SetItem<int>("hitPoints", _hitPoints);

		if (tag == "Hellephant") {
            _hitPoints = _hellephantHP;
		} else if (tag == "Bunny") {
            _hitPoints = _bunnyHP;
		} else if (tag == "Boy") {
            _hitPoints = _boyHP;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(_hitPoints <= 0){
			//Animation Die then destroy
			Destroy(this.gameObject);
		}
	}

	public void damage(GameObject attacker){

        int damage = 0;
        if (attacker.tag == "Hellephant") {
            damage = _hellephantDamage;
        } else if (attacker.tag == "Bunny") {
            damage = _bunnyDamage;
        } else if (attacker.tag == "Boy") {
            damage = _boyDamage;
        }

        _hitPoints = _hitPoints - damage;
		_actualAttacker = attacker;
		if (_tRig != null) {
			_tRig.AI.WorkingMemory.SetItem<int> ("hitPoints", _hitPoints);
			_tRig.AI.WorkingMemory.SetItem<GameObject> ("attacker", _actualAttacker);
		}
	}
}
