using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    private GameObject spawnpoint;
    private GameObject gorila;
    public int cosa = 0;

   

    // Use this for initialization
    void Start () {
        gorila=GameObject.FindGameObjectWithTag("Gorilla");
        


    }
	
	// Update is called once per frame
	void Update () {
        
        Debug.Log("Hello", gameObject);
        
        this.transform.position = gorila.transform.position;
    }
}
