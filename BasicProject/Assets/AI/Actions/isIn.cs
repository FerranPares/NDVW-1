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
    public Expression boyObject = new Expression();

    IList<RAIN.Entities.Aspects.RAINAspect> _allMatches;
    GameObject _hellephant;
    private GameObject _attacker;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        _hellephant = GameObject.FindGameObjectsWithTag("Hellephant")[0];

    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        _allMatches = suspects.Evaluate<IList<RAIN.Entities.Aspects.RAINAspect>>(ai.DeltaTime, ai.WorkingMemory);
        if (_allMatches == null || _hellephant == null)
        {
            ai.WorkingMemory.SetItem<GameObject>(boyObject.VariableName, null);
            return ActionResult.FAILURE;
        }
        AIRig attackedAI = _hellephant.GetComponentInChildren<AIRig>();
        _attacker = attackedAI.AI.WorkingMemory.GetItem<GameObject>("attacker");


        GameObject result = null;
        Debug.Log("isIn:\n\tCount: " + _allMatches.Count);
        foreach (RAIN.Entities.Aspects.RAINAspect aspect in _allMatches)
        {
            Debug.Log("isIn:\n\tTAG: " + aspect.Entity.Form.tag);
            if (aspect.Entity.Form.GetInstanceID() == _attacker.GetInstanceID())
            {
                result = _attacker;
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

