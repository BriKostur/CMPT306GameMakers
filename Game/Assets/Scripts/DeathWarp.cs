using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWarp : MonoBehaviour {

	public Transform warpDestination;

	void OnTriggerEnter2D(Collider2D warp) {
		warp.gameObject.transform.position = warpDestination.position;
	}
}
