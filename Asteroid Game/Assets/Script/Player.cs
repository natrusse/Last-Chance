using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
	public float maxspeed = 6;
	public float rotspeed = 6;
	public float shftboost = 4;
	public Transform Blaster;
	public GameObject bulletPrefab;
	public float bulletForce = 30;
	public float fireRate = 0.5f;
	private float fireTimer = 0;
	public GameObject Idle;
	public GameObject Moving;
	public GameObject Boosting;
	public Rigidbody2D other;
	public bool isEnabled = true;
    

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.P)) { // pause button location
			isEnabled = !isEnabled; 
		}
//		if (Input.GetKeyUp (KeyCode.Q)) {
//			gameObject.SetActive (false);
//		}
//		if (Input.GetKeyUp (KeyCode.Space)) {
//			transform.position = new Vector3 (0, 0, 0);
//		}
		if (isEnabled) {
			Idle.SetActive (true);
			Moving.SetActive (false);
			Boosting.SetActive (false);

			if (Input.GetKey (KeyCode.Space)) {
				fireTimer += Time.deltaTime;
				if (fireTimer >= fireRate) {
					fireTimer = 0;


					//fires the guns
					GameObject bullet = Instantiate (bulletPrefab, Blaster.transform.position, Blaster.transform.rotation);
					bullet.GetComponent <Rigidbody2D> ().AddForce (bullet.transform.up * bulletForce, ForceMode2D.Impulse);

					// for future reference, this is effected by background colliders. if moving towards edge of background, remove 2d collider
				}
			}






			if (Input.GetKeyUp (KeyCode.Space)) {
				fireTimer = fireRate;
			}





            // shift boost
			if ((Input.GetKey (KeyCode.LeftShift)) || (Input.GetKey (KeyCode.RightShift))) {
				// WASD shift boost controls

				// forward movement with w
				if (Input.GetKey (KeyCode.W)) {
					transform.Translate (Vector2.up * maxspeed * Time.deltaTime * shftboost);
					Boosting.SetActive (true);
					Idle.SetActive (false);
					Moving.SetActive (false);
				}
				// backward movement with s
				if (Input.GetKey (KeyCode.S)) {
					transform.Translate (Vector2.down * Time.deltaTime * maxspeed);
					Boosting.SetActive (true);
					Idle.SetActive (false);
					Moving.SetActive (false);
				}
				// left rotation with a
				if (Input.GetKey (KeyCode.A)) {
					transform.Rotate (Vector3.forward * Time.deltaTime * rotspeed);
					Boosting.SetActive (true);
					Idle.SetActive (false);
					Moving.SetActive (false);
				}
				// right rotation with d
				if (Input.GetKey (KeyCode.D)) {
					transform.Rotate (Vector3.back * Time.deltaTime * rotspeed);
					Boosting.SetActive (true);
					Idle.SetActive (false);
					Moving.SetActive (false);
				}

				//forward with up arrow shift boost
				if (Input.GetKey (KeyCode.UpArrow)) {
					transform.Translate (Vector2.up * maxspeed * Time.deltaTime * shftboost);
					Boosting.SetActive (true);
					Idle.SetActive (false);
					Moving.SetActive (false);
				}
				//backward with down arrow
				if (Input.GetKey (KeyCode.DownArrow)) {
					transform.Translate (Vector2.down * Time.deltaTime * maxspeed);
					Boosting.SetActive (true);
					Idle.SetActive (false);
					Moving.SetActive (false);
				}
				//left rotation with left arrow
				if (Input.GetKey (KeyCode.LeftArrow)) {
					transform.Rotate (Vector3.forward * Time.deltaTime * rotspeed);
					Boosting.SetActive (true);
					Idle.SetActive (false);
					Moving.SetActive (false);
				}
				//right rotation with right arrow
				if (Input.GetKey (KeyCode.RightArrow)) {
					transform.Rotate (Vector3.back * Time.deltaTime * rotspeed);
					Boosting.SetActive (true);
					Idle.SetActive (false);
					Moving.SetActive (false);
				}
			} else {
				// WASD Controls
				Idle.SetActive (true);
				//forward movement with w
				if (Input.GetKey (KeyCode.W)) {
					transform.Translate (Vector2.up * maxspeed * Time.deltaTime);
					Boosting.SetActive (false);
					Idle.SetActive (false);
					Moving.SetActive (true);
				}
				//backward movement with s
				if (Input.GetKey (KeyCode.S)) {
					transform.Translate (Vector2.down * maxspeed * Time.deltaTime);
					Boosting.SetActive (false);
					Idle.SetActive (false);
					Moving.SetActive (true);
				}
				//left rotation with a
				if (Input.GetKey (KeyCode.A)) {
					transform.Rotate (Vector3.forward * Time.deltaTime * rotspeed * 2);
					Boosting.SetActive (false);
					Idle.SetActive (false);
					Moving.SetActive (true);
				}
				//right rotation with d
				if (Input.GetKey (KeyCode.D)) {
					transform.Rotate (Vector3.back * Time.deltaTime * rotspeed * 2);
					Boosting.SetActive (false);
					Idle.SetActive (false);
					Moving.SetActive (true);
				}

				// Arrow Key Controls

				//forward with up arrow
				if (Input.GetKey (KeyCode.UpArrow)) {
					transform.Translate (Vector2.up * maxspeed * Time.deltaTime);
					Boosting.SetActive (false);
					Idle.SetActive (false);
					Moving.SetActive (true);
				}
				//backward with down arrow
				if (Input.GetKey (KeyCode.DownArrow)) {
					transform.Translate (Vector2.down * maxspeed * Time.deltaTime);
					Boosting.SetActive (false);
					Idle.SetActive (false);
					Moving.SetActive (true);
				}
				//left rotation with left arrow
				if (Input.GetKey (KeyCode.LeftArrow)) {
					transform.Rotate (Vector3.forward * Time.deltaTime * rotspeed * 2);
					Boosting.SetActive (false);
					Idle.SetActive (false);
					Moving.SetActive (true);
				}
				//right rotation with right arrow
				if (Input.GetKey (KeyCode.RightArrow)) {
					transform.Rotate (Vector3.back * Time.deltaTime * rotspeed * 2);
					Boosting.SetActive (false);
					Idle.SetActive (false);
					Moving.SetActive (true);
				}
			}
		}
	}
}