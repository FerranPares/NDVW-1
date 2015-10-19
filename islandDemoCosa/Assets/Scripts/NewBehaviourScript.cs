using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    GameObject spawnpoint;
    
  

    // Use this for initialization
    void Start () {
        spawnpoint=GameObject.FindGameObjectWithTag("Gorilla");
        

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Hello", gameObject);
        
        this.transform.position = spawnpoint.transform.position;
    }
}
