using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 7;
    [SerializeField] private float jumpHeight = 150;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform gunMuzzle;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireRate = 0.5f;

    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private bool isFacingRight;
    private bool isGrounded;
    private float nextFire;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        isGrounded = false;
    }

    private void Update()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
            rigidbody2d.AddForce(new(x: 0, y: jumpHeight));

            nextFire = 0f;
            if (Time.time >= nextFire && Input.GetAxis("Fire1") != 0)
            {
                nextFire = Time.time + fireRate;
                Instantiate(projectile, gunMuzzle.position, 
                    Quaternion.Euler(x : 0, y : 0, z : isFacingRight ? 0 : 180));
            }
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));

        rigidbody2d.velocity = new(
            x: move * maxSpeed,
            y: rigidbody2d.velocity.y);

        if ((move > 0 && !isFacingRight) || (move < 0 && isFacingRight)) Flip();

        isGrounded = Physics2D.OverlapCircle(groundChecker.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("verticalSpeed", rigidbody2d.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new(
            x: transform.localScale.x * -1,
            y: transform.localScale.y,
            z: transform.localScale.z);
    }
}
