using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;

public class HPController : MonoBehaviour
{

    public int _hitPoints;
    private AIRig _tRig;
    private GameObject _actualAttacker;
	private IList<GameObject> _listAttackers;
    private GameObject _actualTarget;

    private int _hellephantHP = 500;
    private int _bunnyHP = 100;
    private int _boyHP = 100;
    private int _playerHP = 50;

    private int _hellephantDamage = 20;
    private int _bunnyDamage = 10;
    private int _boyDamage = 10;
    private int _playerDamage = 10;


    // Use this for initialization
    void Start()
    {
        _hitPoints = 666;
        _actualAttacker = null;
		_listAttackers = new List<GameObject>();
        _actualTarget = null;

        if (tag == "Hellephant")
        {
            _hitPoints = _hellephantHP;
        }
        else if (tag == "Bunny")
        {
            _hitPoints = _bunnyHP;
        }
        else if (tag == "Boy")
        {
            _hitPoints = _boyHP;
        }
        else if (tag == "Player")
        {
            _hitPoints = _playerHP;
        }

		_tRig = gameObject.GetComponentInChildren<AIRig>();
		_tRig.AI.WorkingMemory.SetItem<int>("hitPoints", _hitPoints);
		_tRig.AI.WorkingMemory.SetItem<GameObject>("attacker", _actualAttacker);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitPoints <= 0)
        {
			foreach(GameObject attacker in _listAttackers){
				HPController attackerHP = attacker.GetComponent<HPController>();
				attackerHP.deleteAttacker(this.gameObject);
			}
            Destroy(this.gameObject);
        }
    }

    public void damage(GameObject attacker)
    {
//        Debug.Log("damage funcion, tag del que esta atacant " + attacker.tag);

        int damage = 0;
        if (attacker.tag == "Hellephant")
        {
            damage = _hellephantDamage;
        }
        else if (attacker.tag == "Bunny")
        {
            damage = _bunnyDamage;
        }
        else if (attacker.tag == "Boy")
        {
            damage = _boyDamage;
        }
        else if (attacker.tag == "Player")
        {
            damage = _playerDamage;
        }

        _hitPoints = _hitPoints - damage;
		_tRig.AI.WorkingMemory.SetItem<int>("hitPoints", _hitPoints);
		// Play hurt sound
		Transform attackedT = transform.FindChild("attacked");
		AudioSource attackedAS = attackedT.GetComponent<AudioSource> ();
		attackedAS.Play ();

		addAttacker (attacker);
    }

    public void setTarget(GameObject target)
    {
        _actualTarget = target;
//		_tRig.AI.WorkingMemory.SetItem<GameObject>("target", _actualTarget);
    }

//    public void setAttacker(GameObject attacker)
//    {
//        _actualAttacker = attacker;
//		_tRig.AI.WorkingMemory.SetItem<GameObject>("attacker", _actualAttacker);
//    }

    public GameObject getAttacker()
    {
        return _actualAttacker;
    }

	private void addAttacker(GameObject attacker)
	{
		if (!_listAttackers.Contains (attacker)) {
			_listAttackers.Add(attacker);
			if (_listAttackers.Count > 0){
				if (_actualAttacker != _listAttackers[0]){
					_actualAttacker = _listAttackers[0];
					_tRig.AI.WorkingMemory.SetItem<GameObject>("attacker", _actualAttacker);
				}
			}
		}
	}

	private void deleteAttacker(GameObject attacker)
	{
		if (_listAttackers.Contains (attacker)) {
			_listAttackers.Remove (attacker);
			if (_listAttackers.Count > 0) {
				if (_actualAttacker != _listAttackers[0]){
					_actualAttacker = _listAttackers[0];
					_tRig.AI.WorkingMemory.SetItem<GameObject>("attacker", _actualAttacker);
				}
			} else {
				_actualAttacker = null;
				_tRig.AI.WorkingMemory.SetItem<GameObject>("attacker", _actualAttacker);
			}
		} 
//		else {
//			Debug.LogWarning("HPController: " + tag + 
//			                 "\n\tTrying to delete attacker " + attacker.tag + 
//			                 " from _listAttackers but it does not contain it!");
//		}
	}

	public void announceDestroy(GameObject deleteGO){
		//Target
		if (_actualTarget == deleteGO) {
			_actualTarget = null;
		}
		//Attackers
		deleteAttacker (deleteGO);
	}
}

