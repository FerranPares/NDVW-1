using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour {

	private float _originalSize = 100f;
	public float _size;
	public float _growingRate = 0.01f;
	public float _maxSize = 200f;
	private Vector3 _originalScale;
	private Vector3 _originalPosition;

	public GameObject _spawnBoy;
	public float _boyBite = 0.1f;
	public float _bunnyBite = 2f;
	public float _hellephantBite = 20f;
	
	void Start () {
		_size = _originalSize;
		_originalScale = transform.localScale;
		_originalPosition = transform.position;
	}

	void Update(){
		//Change visual size of egg and its position to stay on terrain
		float factor = (_size / _originalSize);
		Vector3 scale = _originalScale * factor;
		Vector3 position = _originalPosition;
		position.y = position.y * factor;
		transform.localScale = scale;
//		transform.position.Set(transform.position.x, _yOffset * factor, transform.position.z);
		transform.position = position;

		Debug.Log ("_size: " + _size.ToString());
		Debug.Log ("factor: " + factor.ToString());
		Debug.Log ("scale: " + scale.ToString());
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
	}

	public void lick(GameObject licker){
		float bite = 0f;
		switch(licker.tag){
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
	}
}
