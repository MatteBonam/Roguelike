using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float pierce = 2f;
    public int damage;
    Rigidbody2D rb;
    public float LifeTime = 3f;
    private float spawnTime;

    private void Start()
    {
        spawnTime = Time.time;
    }
    private void Update()
    {
        if (Time.time - spawnTime + 1f >= LifeTime)
            Destroy(gameObject);
    }
    public void ShootB(float bulletForce)
    {
        damage = Mathf.RoundToInt(bulletForce / 5);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject health = other.gameObject;
        if (health.tag != "Arrow")
        {
            if (health.tag == "Enemy")
            {
                health.GetComponent<Health>().takeDamage(damage);
            }
            pierce--;
            if (pierce <= 0)
                Destroy(gameObject);
        }
    }
}
