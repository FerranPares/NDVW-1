using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class isIn : RAINAction
{

    public Expression suspects = new Expression();
    public Expression attacked = new Expression();
    public Expression boyObject = new Expression();

    IList<RAIN.Entities.Aspects.RAINAspect> _allMatches;
    GameObject _attacked;
    private GameObject _attackedAttacker;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        _allMatches = suspects.Evaluate<IList<RAIN.Entities.Aspects.RAINAspect>>(ai.DeltaTime, ai.WorkingMemory);
        _attacked = attacked.Evaluate<GameObject>(ai.DeltaTime, ai.WorkingMemory);
        if (_allMatches == null || _attacked == null)
        {
            ai.WorkingMemory.SetItem<GameObject>(boyObject.VariableName, null);
            return ActionResult.SUCCESS;
        }
        AIRig attackedAI = _attacked.GetComponentInChildren<AIRig>();
        _attackedAttacker = attackedAI.AI.WorkingMemory.GetItem<GameObject>("attacker");


        GameObject result = null;
        foreach (RAIN.Entities.Aspects.RAINAspect aspect in _allMatches)
        {
            if (aspect.Entity.Form.GetInstanceID() == _attackedAttacker.GetInstanceID())
            {
                result = _attackedAttacker;
                break;
            }
        }
        ai.WorkingMemory.SetItem<GameObject>(boyObject.VariableName, result);
        return ActionResult.SUCCESS;

    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
