using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class howMany : RAINAction
{

	public Expression sensorMatches = new Expression();
	IList<GameObject> _matches;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_matches = sensorMatches.Evaluate<IList<GameObject>> (ai.DeltaTime, ai.WorkingMemory);
		Debug.Log ("howMany: _matches.Count()" + _matches.Count.ToString());
//		GameObject hellephant = GameObject.FindGameObjectsWithTag("Hellephant")[0];
//		AIRig aiHellephant = hellephant.GetComponentInChildren<AIRig> ();
//		_hellephantAttacker = aiHellephant.AI.WorkingMemory.GetItem<GameObject>("attacker");
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}