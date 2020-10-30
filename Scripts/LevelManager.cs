using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager gm;
    public GameObject player;
    public GameObject enemy1;
    public GameObject motherShip;

    //stats
    public int score = 0;
    public int playerLives = 3;

    // Controls Enemy spawning:
    public int enemyLimit = 20;
    private int numEnemies = 0;
    public float spawnTime = 0.5f;
    public int phaseLength = 50;

    public float[] spawnPoints = { 0f };
    private Vector2 spawnLocation;

    // Controls the way the backgrounds scrolls:
    public float scrollSpeed;
    public float yLim;
    private float playerEffect = 0.2f;
    public float scrollRate; // Used by other scripts.

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            StartCoroutine(SpawnEnemy());
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            StartCoroutine(SpawnEnemy2());
        }
    }

    void Update()
    {
        if (playerLives <= 0)
        {
            Destroy(player);
            // Then load GameOver scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        scrollRate = scrollSpeed * (yLim + player.transform.position.y) * playerEffect + 0.2f;  // current settings 0.2 - 0.654 per second
        spawnTime = 0.5f - (0.3f * scrollRate);

    }




    IEnumerator SpawnEnemy()
    {
        
        // Phase 1: Random selection:
        for (int i = 0; i < phaseLength; i++)
        {
            spawnLocation = new Vector2(spawnPoints[Random.Range(0, spawnPoints.Length)], 7f);
            
            GameObject enemy = Instantiate(enemy1, spawnLocation, Quaternion.identity);
            enemy.GetComponent<EnemyBehaviourScript>().lm = this;

            numEnemies++;
            yield return new WaitForSeconds(spawnTime * 2);
        }

        // Phase 2: Patterns:
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnLocation = new Vector2(
            spawnPoints[i],         // x position
            7f); // y position

            GameObject enemy = Instantiate(enemy1, spawnLocation, Quaternion.identity);
            enemy.GetComponent<EnemyBehaviourScript>().lm = this;

            numEnemies++;
            yield return new WaitForSeconds(spawnTime);
        }
        
        // Phase 3: Spawners:
        for (int i = 0; i < spawnPoints.Length / 2; i++)
        {
            spawnLocation = new Vector2(spawnPoints[2 * i], 5f);

            GameObject temp_motherShip = Instantiate(motherShip, spawnLocation, Quaternion.identity);
            temp_motherShip.GetComponent<MotherShip>().lm = this;
            numEnemies++;
            yield return new WaitForSeconds(spawnTime);
        }

        while (numEnemies > 0)
        {
            yield return new WaitForSeconds(3f);
        }

        // Phase 4: Random selection:
        for (int i = 0; i < 25; i++)
        {
            spawnLocation = new Vector2(spawnPoints[Random.Range(0, spawnPoints.Length)], 7f);

            GameObject enemy = Instantiate(enemy1, spawnLocation, Quaternion.identity);
            enemy.GetComponent<EnemyBehaviourScript>().lm = this;

            numEnemies++;
            yield return new WaitForSeconds(spawnTime * 2);
        }

        // Phase 5: Strangeness:
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < spawnPoints.Length; j++)
            {
                spawnLocation = new Vector2(
                spawnPoints[j],         // x position
                5f); // y position

                GameObject enemy = Instantiate(enemy1, spawnLocation, Quaternion.identity);
                enemy.GetComponent<EnemyBehaviourScript>().lm = this;

                numEnemies++;
                yield return new WaitForSeconds(spawnTime);
            }
            GameObject temp_motherShip = Instantiate(motherShip, new Vector2(i - 2, 5f), Quaternion.identity);
            temp_motherShip.GetComponent<MotherShip>().lm = this;
            numEnemies++;
        }

        while (numEnemies > 0)
        {
            yield return new WaitForSeconds(3f);
        }

        // End:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }


        IEnumerator SpawnEnemy2()
    {
        // Phase 1: Spawners:
        for (int i = 0; i < spawnPoints.Length / 2; i++)
        {
            spawnLocation = new Vector2(spawnPoints[2 * i], 5f);

            GameObject temp_motherShip = Instantiate(motherShip, spawnLocation, Quaternion.identity);
            temp_motherShip.GetComponent<MotherShip>().lm = this;
            numEnemies++;
            yield return new WaitForSeconds(spawnTime);
        }

        while (numEnemies > 0)
        {
            yield return new WaitForSeconds(3f);
        }
        // Phase 2: Patterns:
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnLocation = new Vector2(
            spawnPoints[i],         // x position
            7f); // y position

            GameObject enemy = Instantiate(enemy1, spawnLocation, Quaternion.identity);
            enemy.GetComponent<EnemyBehaviourScript>().lm = this;

            numEnemies++;
            yield return new WaitForSeconds(spawnTime / 2);
        }
        
        // Phase 3: Spawners:
        for (int i = 0; i < spawnPoints.Length / 2; i++)
        {
            spawnLocation = new Vector2(spawnPoints[2 * i], 5f);

            GameObject temp_motherShip = Instantiate(motherShip, spawnLocation, Quaternion.identity);
            temp_motherShip.GetComponent<MotherShip>().lm = this;
            numEnemies++;
            yield return new WaitForSeconds(spawnTime);
        }

        while (numEnemies > 0)
        {
            yield return new WaitForSeconds(3f);
        }

        // Phase 4: Random selection:
        for (int i = 0; i < 25; i++)
        {
            spawnLocation = new Vector2(spawnPoints[Random.Range(0, spawnPoints.Length)], 7f);

            GameObject enemy = Instantiate(enemy1, spawnLocation, Quaternion.identity);
            enemy.GetComponent<EnemyBehaviourScript>().lm = this;

            numEnemies++;
            yield return new WaitForSeconds(spawnTime / 4);
        }

        // Phase 5: Strangeness:
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < spawnPoints.Length; j++)
            {
                spawnLocation = new Vector2(
                spawnPoints[j],         // x position
                5f); // y position

                GameObject enemy = Instantiate(enemy1, spawnLocation, Quaternion.identity);
                enemy.GetComponent<EnemyBehaviourScript>().lm = this;

                numEnemies++;
                yield return new WaitForSeconds(spawnTime / 2);
            }
            GameObject temp_motherShip = Instantiate(motherShip, new Vector2(i - 2, 5f), Quaternion.identity);
            temp_motherShip.GetComponent<MotherShip>().lm = this;
            numEnemies++;
        }

        while (numEnemies > 0)
        {
            yield return new WaitForSeconds(3f);
        }

        // End:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    public void PlayerDied()
    {
        playerLives--;
        gm.SetLivesText(playerLives);
    }

    public void EnemyDied()
    {
        numEnemies--;
    }

    public void EnemyKilled(int points=10)
    {
        numEnemies--;
        score += points;
        gm.SetScoreText(score);
    }
}
