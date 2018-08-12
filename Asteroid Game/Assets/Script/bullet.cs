using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float despawnTime = 5;
	private float timer = 0;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= despawnTime) {

			Destroy (gameObject);

		}
	}
}
