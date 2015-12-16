using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class SpawnZombunny : RAINAction
{

	public Expression position = new Expression();
	private Vector3 _spawnPosition;
	private GameObject _god;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		_spawnPosition = position.Evaluate<Vector3> (ai.DeltaTime, ai.WorkingMemory);
		_god = GameObject.FindGameObjectsWithTag("God")[0];
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		EnemyManager enemyManager = _god.GetComponent<EnemyManager> ();
		enemyManager.BunnySpawn (_spawnPosition);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}