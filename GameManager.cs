using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelManager lm;
    public PlayerManager pm;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text livesText;
    public UnityEngine.UI.Text weaponText;
    public UnityEngine.UI.Text timeText;

    /*
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy3;
    public GameObject motherShip;

    // Controls Enemy spawning:
    public int enemyLimit = 20;
    private int numEnemies = 0;
    public float enemySpawnChance = 0.02f; // The probability that an enemy will spawn, for every given scene.
    public float spawnTime = 0.5f;
    public int phaseLength = 50;

    public float[] spawnPoints = {0f};
    public Rect SpawnArea;
    public Vector2 spawnLocation;

    // Controls the way the backgrounds scrolls:
    public float scrollSpeed;
    public float yLim;
    private float playerEffect = 0.2f;
    public float scrollRate; // Used by other scripts.
    */
    /*
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    */
    private void Start()
    {
        lm.GetComponent<LevelManager>().gm = this;
        pm.GetComponent<PlayerManager>().gm = this;

        scoreText.text = "Score: " + lm.score;
        livesText.text = "Lives: " + lm.playerLives;
        weaponText.text = "Weapon: " + pm.weaponNum;
    }

    void Update()
    {
        timeText.text = "Time: " + Mathf.Floor(Time.timeSinceLevelLoad);
        /*
        if (playerLives <= 0)
        {
            Destroy(player);
            // Then reload the scene.
            SceneManager.LoadScene("GameOver");
        }

        scrollRate = scrollSpeed * (yLim + player.transform.position.y) * playerEffect + 0.2f;
        */
        //        if (currentEnemyCount < enemyLimit)
        //        { 
        /*
                    if (Random.value < enemySpawnChance)
                    {
                        spawnLocation = new Vector2(
                        Random.Range(SpawnArea.x, SpawnArea.y),         // x position
                        Random.Range(SpawnArea.width, SpawnArea.height)); // y position


                    }
                   */
        //        }
    }
 

    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void SetLivesText(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void weaponChange(int weapon)
    {
        weaponText.text = "Weapon: " + weapon;
    }
}
