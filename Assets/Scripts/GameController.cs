using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	/**
	 * Delay before beginning and spawns
	 */
	public float startDelay;

	/*
	 * the hazard to generate in a wave
	 */
	public GameObject hazard;

	/**
	 * how many hazards
	 */
	public int hazardCount;

	/**
	 * The vector which helps us generate the hazards at a good location.
	 * X is the -x min to +x max range to spawn in
	 * Y and Z are fixed.
	 **/
	public Vector3 spawnValue;

	/*
	 * seconds between each hazzards
	 */
	public float spawnWait;

	/*
	 * seconds between spawn waves
	 */
	public float waveWait;

	// Use this for initialization
	void Start () {
		StartCoroutine( SpawnHazardWaves() ); //<-- doing a coroutine weeee!
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnHazardWaves() {
		yield return new WaitForSeconds (startDelay);
		while(true) {
			for (int i = 0; i < hazardCount; ++i) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
