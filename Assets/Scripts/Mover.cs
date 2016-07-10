using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	Rigidbody rb;

	public float speed;

	// Use this for initialization
	public void Start () {
		rb = GetComponent<Rigidbody>(); 
		rb.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
