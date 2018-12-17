using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletCharge;
    public float DureeAnimation;
    bool charge = false;
    int count = 0;
    private bool _firing;
    public bool tir;
    public Animator animator;
    private float timeLeftAnim;

    private PlayerMovement playerMovement;

    public bool Firing
    {
        get
        {
            return _firing;
        }
      
    }

    // Use this for initialization
    void Start () {
        playerMovement = GetComponent<PlayerMovement>();
	}

    // Update is called once per frame


    void Update()
    {
        if (Input.GetButtonDown("Tir"))
        {
            //_firing = true;
            //animator.SetBool("tir", true);
            //animator.SetBool("tir", false);
            animator.Play("megakid tir fixe right");
            //StartCoroutine(waitAnim());
            var tBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            tBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;



        }

        //Shoot();
        //if (_firing == true)
        //{
        //    AnimShootTimer();
        //    _firing = false;
        //}

    }



    void Shoot()

    {

        if (Input.GetButtonDown("Tir"))
        {
            //_firing = true;
            animator.SetBool("tir", true);
            StartCoroutine(waitAnim());
            var tBullet = Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            tBullet.GetComponent<Bullet>().bulletDirection = playerMovement.PlayerDirection;



        }
    
	}

    private void AnimShootTimer()
    {
        timeLeftAnim = 0.1f;
        timeLeftAnim -= Time.deltaTime;
        if (timeLeftAnim < 0)
        {
            animator.SetBool("tir", false);
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

    IEnumerator waitAnim()
    {
        yield return new WaitForSeconds(DureeAnimation);
        animator.SetBool("tir", false);

    }



    //    private void shootTimer() { 
    //        if (_firing == true)
    //        {
    //            animShootTimer();
    //        }
    //    }


    //    private void animShootTimer()
    //    {
    //        if (timeLeftAnim > 0)
    //        {
    //            timeLeftAnim -= Time.deltaTime;
    //          
    //        }
    //      else
    //    {
    //      timeLeftAnim = 0;
    //    _firing = false;
    //  animator.SetBool("tir", false);
    //timeLeftAnim = 10;
    //}
    //}
}
