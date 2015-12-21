using UnityEngine;
using System.Collections;
using RAIN.Core;

public class HPController : MonoBehaviour
{

    public int _hitPoints;
    private AIRig _tRig;
    private GameObject _actualAttacker;
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
        //        ai = this.gameObject.GetComponent<RAIN.Core.AIRig> ();
        //        _hitPoints = (int)ai.AI.WorkingMemory.GetItem("hitPoints");
        _hitPoints = 666;
        _actualAttacker = null;
        _actualTarget = null;

        _tRig = gameObject.GetComponentInChildren<AIRig>();

        if (_tRig != null)
        {
            _tRig.AI.WorkingMemory.SetItem<int>("hitPoints", _hitPoints);
        }

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
    }

    // Update is called once per frame
    void Update()
    {
        

        try
        {
            
            Debug.Log("estic al update del " + this.tag.ToString());

            GameObject go = GameObject.Find(_actualTarget.tag);
            HPController hp = go.GetComponent<HPController>();
            int vida = hp._hitPoints;
            

            Debug.Log(vida + "vidaaaaaa del target" + _actualTarget.tag);
        }
        catch
        {
            Debug.Log("Horrible things happened!");
            //_actualTarget = null;
            AIRig attackerAI = this.GetComponentInChildren<AIRig>();
            attackerAI.AI.WorkingMemory.SetItem<GameObject>("attacker", null);


        }
        //Debug.Log(go.tag + "actual target");

        /*
        if (GameObject.Find(_actualTarget.tag))
        {
            Debug.Log("dintre el if dient que el player esta mort");
            //attackerAI.AI.WorkingMemory.SetItem<GameObject>("attacker", null);
        }
        */
        if (_hitPoints <= 0)
        {
            //Animation Die then destroy


            //Target tRig
            
            Debug.Log("I'm " + this.tag + " and I gonna die so my atacker " + _actualAttacker.tag + "is gonna be assigned as null");


            //----------- SON AKESTES DOS LINIES DE CODI ----------//
            //HPController targetHP = _actualTarget.GetComponent<HPController>();
            //targetHP.setAttacker(this.gameObject);

            /*
            Debug.Log("I'm " + this.tag + " and I gonna die so my target " + _actualAttacker.tag + "is gonna be assigned as null");
            HPController attackerHP = _actualAttacker.GetComponent<HPController>();
            attackerHP.setAttacker(this.gameObject);
            */

            //AIRig targetAI = _actualTarget.GetComponentInChildren<AIRig>();
            //targetAI.AI.WorkingMemory.SetItem<GameObject>("attacker", null);
            
            AIRig attackerAI = _actualAttacker.GetComponentInChildren<AIRig>();


            //Debug.Log(GameObject.Find("Boy").tag + "tag del boy");
            //attackerAI.AI.WorkingMemory.SetItem<GameObject>("attacker", GameObject.Find("Boy"));
            attackerAI.AI.WorkingMemory.SetItem<GameObject>("attacker", null);

            Debug.Log("eeeeeeeeeeeeeeeeeeeeeeeestic al update del:" + this.gameObject.tag);

            //Destroying object
            Destroy(this.gameObject);
            
        }
    }

    public void damage(GameObject attacker)
    {
        Debug.Log("damage funcion, tag del que esta atacant " + attacker.tag);

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
        Debug.Log("hi point del bixo" + this.gameObject.tag + ": " + _hitPoints);
        _actualAttacker = attacker;
        if (_tRig != null)
        {
            _tRig.AI.WorkingMemory.SetItem<int>("hitPoints", _hitPoints);
            _tRig.AI.WorkingMemory.SetItem<GameObject>("attacker", _actualAttacker);
        }
    }

    public void setTarget(GameObject target)
    {
        _actualTarget = target;
    }

    public void setAttacker(GameObject attacker)
    {
        _actualAttacker = attacker;
    }

    public GameObject getAttacker()
    {
        return _actualAttacker;
    }
}

