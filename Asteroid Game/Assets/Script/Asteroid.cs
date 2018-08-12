using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour 
{
	public float asteroidDespawn = 20;
	private float Atimer = 0;
    private Manager M;

    // Use this for initialization
    void Start ()
    {
        // calls specific game manager script
        M = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }
	
	// Update is called once per frame
	void Update () {
		Atimer += Time.deltaTime;

		if (Atimer >= asteroidDespawn)
        {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.collider.gameObject.tag == "Player") {

			Debug.Log ("Player is dead.");
            Destroy(col.collider.gameObject);
            Destroy(gameObject);
            M.Death();

		} else if (col.collider.gameObject.tag == "Bullet") {

			Debug.Log ("Asteroid destroyed");
			Destroy (col.collider.gameObject);
			Destroy (gameObject);
            M.score += 10;
            M.SetScoreText();
        }
	}
}
