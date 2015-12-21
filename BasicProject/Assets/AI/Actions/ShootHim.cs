using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class ShootHim : RAINAction
{
	public Expression shootTarget = new Expression();
	private GameObject _shootTarget;
	//private AudioSource _shootSource;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_shootTarget = shootTarget.Evaluate<GameObject> (ai.DeltaTime, ai.WorkingMemory);
		//_shootSource = ai.Body.GetComponent<AudioSource> ();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
	{
        if(_shootTarget == null) {
            Debug.Log("ShootHim:\n\tshootTarget is null!");
            return ActionResult.FAILURE;
        }
		HPController myHP = ai.Body.GetComponent<HPController> ();
		if(myHP == null){
			return ActionResult.FAILURE;
		}
        myHP.setTarget(_shootTarget);

		PlayerShoot ps = ai.Body.GetComponentInChildren<PlayerShoot> ();
		ps.Shoot ();



		//hp.damage(ai.Body);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }

}