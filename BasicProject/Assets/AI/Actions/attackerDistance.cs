using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class attackerDistance : RAINAction
{

    public Expression distance = new Expression();
    private float _distance;
    private GameObject _attacker;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        _attacker = ai.WorkingMemory.GetItem<GameObject>("attacker");
        if (_attacker == null)
        {
            ai.WorkingMemory.SetItem<float>(distance.VariableName, 100000f);
            return ActionResult.SUCCESS;
        }
        Vector3 difference = ai.Body.transform.position - _attacker.transform.position;
        _distance = difference.magnitude;
        ai.WorkingMemory.SetItem<float>(distance.VariableName, _distance);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
