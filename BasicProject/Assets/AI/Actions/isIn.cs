using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class isIn : RAINAction
{

	public Expression sensorMatches = new Expression();
	public Expression boyObject = new Expression();

	IList<GameObject> _matches;
	private GameObject _hellephantAttacker;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_matches = sensorMatches.Evaluate<IList<GameObject>> (ai.DeltaTime, ai.WorkingMemory);
		Debug.Log ("isIN: _matches.Count()" + _matches.Count.ToString());
		GameObject hellephant = GameObject.FindGameObjectsWithTag("Hellephant")[0];
		AIRig aiHellephant = hellephant.GetComponentInChildren<AIRig> ();
		_hellephantAttacker = aiHellephant.AI.WorkingMemory.GetItem<GameObject>("attacker");
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        /*
		GameObject result = null;
		foreach(GameObject match in _matches){
			if(match.GetInstanceID() == _hellephantAttacker.GetInstanceID){
				ai.WorkingMemory.SetItem<Vector3>(boyObject.VariableName, _hellephantAttacker);
				return ActionResult.SUCCESS;
			}
		}
		ai.WorkingMemory.SetItem<Vector3>(boyObject.VariableName, null);
        */
        return ActionResult.SUCCESS;
        
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}