using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheTree : MonoBehaviour
{
    int health = 10;
    public Text hpText;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void treeTakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            gameOverText.enabled = true;
            hpText.text = "HP = " + 0;
        }
        else
        {
            hpText.text = "HP = " + health;
        }
    }
}
