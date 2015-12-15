using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using RAIN.Entities; //custom

[RAINAction]
public class ShootHim : RAINAction
{
	EntityRig _tRig;
	RAIN.Entities.Aspects.RAINAspect _shootAspect;
	public Expression shootAudio = new Expression();

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_tRig = ai.Body.GetComponentInChildren<EntityRig>();
		_shootAspect = _tRig.Entity.GetAspect("shoot");
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
	{
		if(!shootAudio.IsValid)
		{
			return ActionResult.FAILURE;
		}
		_shootAspect.IsActive = (bool) shootAudio.Evaluate<bool>(ai.DeltaTime, ai.WorkingMemory);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}