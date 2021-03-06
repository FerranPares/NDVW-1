using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class lickEgg : RAINAction
{

	public Expression targetEgg = new Expression();
	private GameObject _egg;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_egg = targetEgg.Evaluate<GameObject>(ai.DeltaTime, ai.WorkingMemory);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		if(_egg.tag != "Egg"){
			return ActionResult.FAILURE;
		}
		EggController eggC = _egg.GetComponent<EggController> ();

		float bite = eggC.lick(ai.Body.transform.tag);

		float quantity = ai.WorkingMemory.GetItem<float> ("chocolate");
		ai.WorkingMemory.SetItem<float> ("chocolate", quantity + bite);


        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}