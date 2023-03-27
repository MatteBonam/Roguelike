using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private GameObject target;
    Vector2 direction;
    public Rigidbody2D rb;
    public float Speed = 10f;
    Vector2 movement;

    private void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            target = GameObject.Find("Player");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            movement = new Vector2(moveX, moveY).normalized;
        }
        else
        {
            direction = target.GetComponent<Rigidbody2D>().position - rb.position;
            float angle = Mathf.Atan2(direction.y, direction.x);
            movement = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * Speed, movement.y * Speed);
    }
}
