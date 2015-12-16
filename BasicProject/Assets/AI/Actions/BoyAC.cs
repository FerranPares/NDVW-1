using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class BoytAC : RAINAction
{
	
	Animator _animator;
	public Expression actionName = new Expression();
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		_animator = ai.Body.GetComponent<Animator> ();
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		if (actionName.IsNull) {
			return ActionResult.FAILURE;
		}
		string action = actionName.Evaluate<string>(ai.DeltaTime, ai.WorkingMemory);
		
		switch(action){
		case "move":
			_animator.SetBool ("IsWalking", true);
			_animator.SetBool ("IsQuiet", false);
			break;
		case "idle":
			_animator.SetBool ("IsWalking", false);
			_animator.SetBool ("IsQuiet", false);
			break;
		case "sleep":
			_animator.SetBool ("IsQuiet", true);
			break;
		}
		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}