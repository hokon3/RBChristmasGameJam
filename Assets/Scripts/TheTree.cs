using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheTree : MonoBehaviour
{
    int health = 10;
    public Text hpText;
    public Text joyText;
    public Text gameOverText;
    public Text victoryText;

    public GameObject prefabAxeMan;
    public GameObject[] AllOrnaments;

    bool gameStarted = false;
    int livingEnemies = 0;
    int joy = 0;
    int ornaments = -1;

    int axeMen = 50;
    float axeMenSpawnTimeMax = 5;
    float axeMenSpawnTimer = 1;
    bool bossActivated = false;
    // Start is called before the first frame update
    void Start()
    {
        updateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            return;
        }
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

    void gameStart()
    {
        joy = 100;
        buyOrnament();
        gameStarted = true;
    }

    void updateTexts()
    {
        hpText.text = "HP = " + health;
        joyText.text = "Christmas joy = " + joy;
    }

    void spawnAxeMan()
    {
        Instantiate(prefabAxeMan, transform, false);
        axeMen--;
        livingEnemies++;
        axeMenSpawnTimeMax = axeMen / 10;
        axeMenSpawnTimer = axeMenSpawnTimeMax;
    }

    void bossTime()
    {
        bossActivated = true;
        this.BroadcastMessage("Activate");
        livingEnemies++;
    }

    void buyOrnament()
    {
        if (joy >= 100 && ornaments < 8)
        {
            ornaments++;
            joy -= 100;
            BroadcastMessage("activateOrnament", ornaments);
            updateTexts();
        }
    }

    void enemyKilled()
    {
        livingEnemies--;
        joy += 40;
        updateTexts();
    }

    void treeTakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            gameOverText.enabled = true;
            hpText.text = "HP = " + 0;
            enabled = false;
        }
        else
        {
            updateTexts();
        }
    }
}
