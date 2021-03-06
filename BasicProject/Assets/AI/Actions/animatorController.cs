using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class animatorController : RAINAction
{

	private Animator _animator;
	public Expression isMoving = new Expression();

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_animator = ai.Body.GetComponent<Animator> ();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		if (isMoving.IsNull) {
			return ActionResult.FAILURE;
		}
		bool movingBool = isMoving.Evaluate<bool>(ai.DeltaTime, ai.WorkingMemory);
		_animator.SetBool ("IsWalking", movingBool);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}