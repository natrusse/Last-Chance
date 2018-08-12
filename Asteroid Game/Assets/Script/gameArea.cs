using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameArea : MonoBehaviour
{

    private Manager M;

    void Start()
    {
        M = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    void OnTriggerExit2D(Collider2D playerShip)
    {


        if (playerShip.gameObject.tag == "Player")
        {
            Debug.Log("Player committed Suicide");
            Destroy(playerShip.gameObject);
            M.Death();
        }
        else
        {
            Debug.Log("Exited Trigger");
            Destroy(playerShip.gameObject);
        }
    }
}
