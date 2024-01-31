using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 15.0f;

    private Rigidbody2D rigidbody2d;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.AddForce(new Vector2(1, 0) * projectileSpeed, ForceMode2D.Impulse);
    }

}
