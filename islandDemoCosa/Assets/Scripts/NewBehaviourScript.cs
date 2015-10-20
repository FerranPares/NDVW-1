using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    private GameObject gorila;
    private Vector3 direction;
    private float distance;
    public float velocity = 5f;


    // Use this for initialization
    void Start () {
        gorila = GameObject.FindGameObjectWithTag("Gorilla");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 diff_vector = gorila.transform.position - this.transform.position;
        direction = Vector3.Normalize(diff_vector);
        distance = Vector3.Magnitude(diff_vector);
        this.transform.position = this.transform.position + direction * distance * velocity;
    }
}
