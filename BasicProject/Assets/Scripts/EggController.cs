using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour {

	private float _originalSize = 100f;
	public float _size;
	public float _growingRate = 0.01f;
	public float _maxSize = 200f;
	private Vector3 _originalScale;

	public GameObject _spawnBoy;
	public float _boyBite = 2f;
	public float _bunnyBite = 2f;
	public float _hellephantBite = 20f;
	
	void Start () {
		_size = _originalSize;
		_originalScale = transform.localScale;
	}

	void Update(){
		//Change visual size of egg and its position to stay on terrain
		float factor = (_size / _originalSize);
		Vector3 scale = _originalScale * factor;

		transform.localScale = scale;
	
	}

	// Set to 0.02s
	void FixedUpdate () {
		// _size is incremented 0.5 each second with FixedUpdate.time == 0.02s
		// _size will reach 200f in 3:20 min if anyone lick it...
		_size = _size + _growingRate;

		if(_size > _maxSize)
		{
			// Instantiate BoyBot and destroy egg
			Vector3 spawnPoint = transform.position;	
			Destroy(this.gameObject);
			Instantiate(_spawnBoy, spawnPoint, Quaternion.identity);
		}

		if(_size <= 0f){
			Destroy(this.gameObject);
		}
	}

	public float lick(string lickerTag){
		float bite = 0f;
		switch(lickerTag){
		case "Boy":
			bite = _boyBite;
			break;
		case "Bunny":
			bite = _bunnyBite;
			break;
		case "Hellephant":
			bite = _hellephantBite;
			break;
		}

		_size = _size - bite;
		return bite;
	}
}
