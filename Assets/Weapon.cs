using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bullet;

    private PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {
        playerMovement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Tir"))
        {
            var tBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            tBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;
        }
	}
}
