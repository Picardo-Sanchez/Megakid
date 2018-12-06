using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletCharge;
    bool charge = false;
    int count = 0;

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
    
    private void FixedUpdate()
    {
        if (Input.GetButton("Tir"))
        {
            count++;
            
        }
        else
        {

        }
        if (Input.GetButtonUp("Tir"))
        {
            print (count);
            if( count > 69)
            {
                var tBullet = Instantiate(bulletCharge, gameObject.transform.position, bullet.transform.rotation) as GameObject;
                tBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;
                charge = false;
            }
            count = 0;

        }
    }
}
