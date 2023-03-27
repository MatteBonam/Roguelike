using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Animator animator;
    public int maxHp = 5;
    private int currentHp;
    public float despawnTime = 3f;
    SpriteRenderer spRenderer;
    public float animationDuration = 0.125f;
    Color originalColor;
    Vector3 scaleDiff;
    public float stretchX, stretchY;
    void Start()
    {
        currentHp = maxHp;
        originalColor = GetComponent<SpriteRenderer>().color;
        scaleDiff = new Vector3(-stretchX, -stretchY, 0);
    }

    public void takeDamage(int damage)
    {
        StartCoroutine(DamageAnimation(Color.white));
        // play hit animation here
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //play die animation here
        Destroy(gameObject);
    }

    IEnumerator DamageAnimation(Color color)
    {
        transform.localScale -= scaleDiff;
        spRenderer = GetComponent<SpriteRenderer>();
        spRenderer.color = color;
        yield return new WaitForSeconds(animationDuration);
        spRenderer.color = originalColor;
        transform.localScale += scaleDiff;
    }
}
