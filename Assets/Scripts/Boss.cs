using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    float treePosition = -0.77f;
    float hp = 10;
    float speed = 1;
    int damage = 999;
    bool dealtDamage = false;
    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated)
        {
            return;
        }
        if (hp <= 0)
        {
            speed = 0;
        }
        else if (transform.localPosition.x >= treePosition)
        {
            speed = 0;
        }
        if (speed != 0)
        {
            transform.localPosition = new Vector2(transform.localPosition.x + (speed * Time.deltaTime), transform.localPosition.y);
        }
        else if (!dealtDamage && hp > 0)
        {
            this.SendMessageUpwards("treeTakeDamage", damage);
            dealtDamage = true;
        }
    }

    void Activate()
    {
        activated = true;
    }

    void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            animator.SetBool("Defeat", true);
            this.GetComponent<EdgeCollider2D>().enabled = false;
            SendMessageUpwards("enemyKilled");
            SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            for (int i = 1; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].enabled = !spriteRenderers[i].enabled;
            }
        }
    }
}
