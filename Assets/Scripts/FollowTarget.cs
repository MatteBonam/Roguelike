using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Vector2 direction;
    private GameObject target;
    public float offsetAngle;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.tag == "Enemy")
        {
            target = GameObject.Find("Player");
        }
    }
    private Vector2 Target()
    {
        if (target == null)
        {
            return GameObject.Find("CameraPos").GetComponent<CameraTarget>().mousePos;
        }
        return target.GetComponent<Rigidbody2D>().position;
    }
    void FixedUpdate()
    {
        direction = Target() - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - offsetAngle;
        rb.rotation = angle;
    }
}
