using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject _egg;
	public GameObject _bunny;
    public float spawnTime = 3f;
	private Vector3 EggPosition;

    void Start ()
    {
        InvokeRepeating ("EggSpawn", spawnTime, spawnTime);
    }

    void EggSpawn ()
    {
		Vector3 position_offset = transform.position;
		EggPosition.Set (Random.Range (-50, 50), 0, Random.Range (-50, 50));
		Vector3 spawnPoint = position_offset + EggPosition;

		Instantiate(_egg, spawnPoint, Quaternion.identity);
    }

	public void BunnySpawn(Vector3 spawnPoint){
		// SpawnPoint passed by Armand -> probably exact same position than Hellephant: problem?
		Instantiate(_bunny, spawnPoint, Quaternion.identity);
	}
}
