using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	/**
	 * Tumbling 'speed'
	 */
	public float tumble;

	private Rigidbody rigidBody;

	/*
	 * Pick an random angular rotation (vector on a Unit Sphere) and fix that as angular vector.
	 */
	void Start () {
		rigidBody = GetComponent<Rigidbody>(); 
		rigidBody.angularVelocity = Random.insideUnitSphere * tumble; 
	}
}
