using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { LEFT, RIGHT };
public class PlayerMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public bool isOnGround = false;
    public float jumpPower = 7.0f;
    public Weapon Weapon;

    public Animator anim;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Direction playerDirection = Direction.RIGHT;

    public Direction PlayerDirection
    {
        get
        {
            return playerDirection;
        }
    }

    // Use this for initialization
    void Start()
    {
        _transform = GetComponent(typeof(Transform)) as Transform;
        _rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();

    }

    void MovePlayer()
    {
        float translate = Input.GetAxis("Horizontal") * speed;
        //transform.Translate(translate, 0, 0);
        ManageAnimations(translate);
    }

    private void ManageAnimations(float translate)
    {
        if (isOnGround)
        {

            if (translate != 0)
            {
                if (translate > 0)
                {
                    playerDirection = Direction.RIGHT;
                    anim.Play("megakid right");

                }
                else if (translate < 0)
                {
                    playerDirection = Direction.LEFT;
                    anim.Play("megakid left");

                }
            }
            else
            {
                if (Weapon.Firing)
                {
                    switch (playerDirection)
                    {
                        case Direction.RIGHT:
                            anim.Play("megakid tir fixe right");
                            break;
                        case Direction.LEFT:
                            anim.Play("megakid tir fixe left");
                            break;
                    }
                }
                else
                {
                    switch (playerDirection)
                    {
                        case Direction.RIGHT:
                            anim.Play("idle right");
                            break;
                        case Direction.LEFT:
                            anim.Play("idle left");
                            break;
                    }
                }
            }
        }
        else
        {
            switch (playerDirection)
            {
                case Direction.LEFT:
                    anim.Play("megakid jump left");
                    break;
                case Direction.RIGHT:
                    anim.Play("megakid jump");
                    break;

            }
        }
        _rigidbody.velocity = new Vector2(translate, _rigidbody.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            
        }
    }

    public void SetOnGround(bool value)
    {
        isOnGround = value;
    }

}
