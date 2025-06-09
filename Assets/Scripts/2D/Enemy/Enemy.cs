using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; 
    private float speed = 2.5f; 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = true; 
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
