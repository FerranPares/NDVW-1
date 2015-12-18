using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class howMany : RAINAction
{
//	RAIN.Entities.Aspects.RAINAspect;
	public Expression sensorMatches = new Expression();
	IList<RAIN.Entities.Aspects.RAINAspect> _allMatches;
	public Expression numMatches = new Expression();

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_allMatches = sensorMatches.Evaluate<IList<RAIN.Entities.Aspects.RAINAspect>> (ai.DeltaTime, ai.WorkingMemory);
		//Debug.Log ("howMany: _matches.Count()" + _allMatches.Count.ToString());
//		GameObject hellephant = GameObject.FindGameObjectsWithTag("Hellephant")[0];
//		AIRig aiHellephant = hellephant.GetComponentInChildren<AIRig> ();
//		_hellephantAttacker = aiHellephant.AI.WorkingMemory.GetItem<GameObject>("attacker");
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		ai.WorkingMemory.SetItem<int>(numMatches.VariableName, _allMatches.Count);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}