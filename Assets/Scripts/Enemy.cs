using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public bool doDamage;
    bool dealtDamage = false;
    public virtual float TreePosition { get; set; }
    public virtual float Hp { get; set; }
    public virtual float Speed { get; set; }
    public virtual int Damage { get; set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Speed = -1;
            animator.SetBool("Attacking", false);
        }
        else if (transform.localPosition.x >= TreePosition)
        {
            Speed = 0;
            animator.SetBool("Attacking", true);
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
        if (Speed != 0)
        {
            transform.localPosition = new Vector2(transform.localPosition.x + (Speed * Time.deltaTime), transform.localPosition.y);
        }
        else if (doDamage && !dealtDamage)
        {
            this.SendMessageUpwards("treeTakeDamage", Damage);
            dealtDamage = true;
        }
        else if (!doDamage)
        {
            dealtDamage = false;
        }
    }

    void TakeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            spriteRenderer.flipX = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
            SendMessageUpwards("enemyKilled");
        }
    }
}
