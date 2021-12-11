using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public bool doDamage;
    bool dealtDamage = false;
    float treePosition = -0.19f;
    float hp = 5;
    float speed = 1;
    int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            speed = -1;
            animator.SetBool("Attacking", false);
        }
        else if (transform.localPosition.x >= treePosition)
        {
            speed = 0;
            animator.SetBool("Attacking", true);
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
        if (speed != 0)
        {
            transform.localPosition = new Vector2(transform.localPosition.x + (speed * Time.deltaTime), transform.localPosition.y);
        }
        else if (doDamage && !dealtDamage)
        {
            this.SendMessageUpwards("treeTakeDamage", damage);
            dealtDamage = true;
        }
        else if (!doDamage)
        {
            dealtDamage = false;
        }
    }

    void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
