using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin = 0.0f, xMax = 1.0f;
	public float zMin = 0.0f, zMax = 1.0f;
}

public class PlayerController : MonoBehaviour {

	/**
	 * A multiplier for the axis input values 
	 */
	public float speed; 

	/**
	 * Correction factor for rotation about z based on velocity
	 */
	public float tilt;

	/**
	 * Where the player ship is allowed to go.
	 */
	public Boundary boundary;

	/**
	 * The Prefab object to Instantiate at the spawn point.
	 */
	public GameObject shot;

	/**
	 * The transform of the shotSpawn (not a copy) conveniently injected, so we can use it to Instantiate from, e.g. spawn new shots at.
	 */
	public Transform shotSpawn;

	/**
	 * minimum Seconds between shots
	 */
	public float fireRate;

	private Rigidbody rb; 

	/**
	 * Future time of next allowable time to spawn
	 */
	private float nextFireTime = 0.0F;

	void Start () {  
		rb = GetComponent<Rigidbody>(); 
	} 

	void Update() {
		if (Input.GetButton("Fire1") && Time.time > nextFireTime) {
			nextFireTime = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = movement * speed;

		rb.position = new Vector3 (Mathf.Clamp( rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);	// Apparently, useful for rotation ...
	}


}
