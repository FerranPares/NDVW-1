using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class BiteHim : RAINAction
{
	public Expression shootTarget = new Expression();
	private GameObject _shootTarget;
	//private AudioSource _shootSource;
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		_shootTarget = (GameObject) shootTarget.Evaluate<GameObject> (ai.DeltaTime, ai.WorkingMemory);
		//_shootSource = ai.Body.GetComponent<AudioSource> ();
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
//		HPController myHP = _shootTarget.GetComponent<HPController> ();
//		if(myHP == null){
//			return ActionResult.FAILURE;
//		}
//        myHP.setTarget(_shootTarget);

        HPController hp = _shootTarget.GetComponent<HPController>();
        if (hp == null)
        {
            return ActionResult.FAILURE;
        }
        hp.damage(ai.Body);
		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
	
}