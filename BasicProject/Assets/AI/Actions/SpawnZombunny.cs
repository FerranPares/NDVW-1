using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class SpawnZombunny : RAINAction
{

    //    public Expression character = new Expression();
    private Vector3 _spawnPosition;
    private GameObject _god;
    private GameObject _character;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        //        _character = character.Evaluate<GameObject> (ai.DeltaTime, ai.WorkingMemory);
        _character = ai.Body;
        _spawnPosition = _character.transform.position;
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        _spawnPosition += Random.Range(3f, 6f) * direction.normalized;
        _god = GameObject.FindGameObjectsWithTag("God")[0];
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        EnemyManager enemyManager = _god.GetComponent<EnemyManager>();
        float chocolate = ai.WorkingMemory.GetItem<float>("chocolate");
        ai.WorkingMemory.SetItem<float>("chocolate", chocolate - 100f);
        enemyManager.BunnySpawn(_spawnPosition);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
