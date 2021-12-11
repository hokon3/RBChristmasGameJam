using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheTree : MonoBehaviour
{
    int health = 10;
    public Text hpText;
    public Text gameOverText;
    public Text victoryText;

    public GameObject prefabAxeMan;

    int livingEnemies = 0;

    int axeMen = 10;
    float axeMenSpawnTimer = 1;
    bool bossActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        hpText.text = "HP = " + health;
    }

    // Update is called once per frame
    void Update()
    {
        axeMenSpawnTimer -= Time.deltaTime;
        if (axeMenSpawnTimer <= 0 && axeMen > 0)
        {
            spawnAxeMan();
        }
        if (axeMen == 0 && !bossActivated)
        {
            bossTime();
        }
        if (livingEnemies + axeMen == 0)
        {
            victoryText.enabled = true;
        }
    }

    void spawnAxeMan()
    {
        Instantiate(prefabAxeMan, transform, false);
        axeMen--;
        livingEnemies++;
        axeMenSpawnTimer = 10;
    }

    void bossTime()
    {
        bossActivated = true;
        this.BroadcastMessage("Activate");
        livingEnemies++;
    }

    void enemyKilled()
    {
        livingEnemies--;
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
