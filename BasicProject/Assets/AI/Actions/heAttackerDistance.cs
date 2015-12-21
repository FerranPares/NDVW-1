using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class heAttackerDistance : RAINAction
{

    public Expression distance = new Expression();
    public Expression heAttacker = new Expression();
    private float _distance;
    private GameObject _attacker;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        GameObject go = GameObject.Find("Hellephant");
        HPController hp = go.GetComponent<HPController>();
        GameObject attackerOfHel = hp.getAttacker();


        //_attacker = ai.WorkingMemory.GetItem<GameObject>("attacker");
        if (attackerOfHel == null)
        {
            ai.WorkingMemory.SetItem<float>(distance.VariableName, 100000f);
            ai.WorkingMemory.SetItem<GameObject>(heAttacker.VariableName, null);
            return ActionResult.SUCCESS;
        }
        Vector3 difference = ai.Body.transform.position - attackerOfHel.transform.position;
        _distance = difference.magnitude;
        ai.WorkingMemory.SetItem<float>(distance.VariableName, _distance);
        ai.WorkingMemory.SetItem<GameObject>(heAttacker.VariableName, attackerOfHel);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
