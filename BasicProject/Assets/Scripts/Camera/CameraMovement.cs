using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	Vector3 movement;
	public float speed = 6f;
	//public float smoothing = 5f;
	Vector3 targetCamPos;

	void FixedUpdate(){
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		Move (h, v);
	}

	void Move(float h, float v){
		movement.Set(h, 0f, v);
		//movement = movement.normalized * speed * Time.deltaTime;
		targetCamPos = transform.position + movement.normalized;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, speed * Time.deltaTime);
	}
}
