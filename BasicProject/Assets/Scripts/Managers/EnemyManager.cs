using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject egg;
    public float spawnTime = 3f;
	private Vector3 EggPosition;

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Spawn ()
    {
		Vector3 position_offset = transform.position;
		EggPosition.Set (Random.Range (-50, 50), 0, Random.Range (-50, 50));
		Vector3 spawnPoint = position_offset + EggPosition;

		Instantiate(egg, spawnPoint, Quaternion.identity);
    }
}
