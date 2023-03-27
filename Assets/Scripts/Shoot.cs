using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float time;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Attack", true);
            time = Time.time;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("Attack", false);
            float speed = Time.time - time;
            speed = speed * 30 + 5;
            if (speed > 30)
                speed = 30;
            ShootBullet(speed);
        }
    }

    void ShootBullet(float bulletForce)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().ShootB(bulletForce);
    }
}
