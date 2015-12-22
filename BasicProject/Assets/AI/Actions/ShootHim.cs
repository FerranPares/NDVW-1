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

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_shootTarget = shootTarget.Evaluate<GameObject> (ai.DeltaTime, ai.WorkingMemory);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
	{
        if(_shootTarget == null) {
            Debug.Log("ShootHim:\n\tshootTarget is null!");
            return ActionResult.FAILURE;
        }
		// Dont know why the object doesnt rotate perfectly pointing to target...
		Vector3 targetDiff = _shootTarget.transform.position - ai.Body.transform.position;
		targetDiff.y = 0;
		Quaternion newRotation = Quaternion.LookRotation(targetDiff);
		Rigidbody rigidBody = ai.Body.GetComponent<Rigidbody> ();
		rigidBody.MoveRotation(newRotation);

		PlayerShoot ps = ai.Body.GetComponentInChildren<PlayerShoot> ();
		ps.Shoot ();

		// Attack doesnt take into account if it really hits to damage target!
		HPController targetHP = _shootTarget.GetComponent<HPController>();
//		targetHP.damage(ai.Body);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }

}