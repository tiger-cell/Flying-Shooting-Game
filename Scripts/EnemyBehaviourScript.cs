using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public LevelManager lm;

    private Rigidbody2D enemy;

    public Vector2[] steps;

    public int enemyLives = 3;
    public float speedFactor = 10;
    //public float[] pattern = { 10f, 20f, 30f };
    public float moveDelay = 2f;
    public float yBounds = -12f;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        //StartCoroutine(Move());
    }

    void Update()
    {
        if (enemyLives <= 0)
        {
            lm.EnemyKilled();
            Destroy(gameObject);  //Kills enemy.
        }

        if (enemy.position.y < yBounds)
        {
            lm.EnemyDied();
            Destroy(gameObject);  //Kills enemy.
        }
    }

    private void FixedUpdate()
    {
        enemy.AddForce(new Vector2(0, -lm.scrollRate * speedFactor));
    }


    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            enemyLives -= 1;

        }
    }

    private IEnumerator Move()  // Right now this is not run at all.
    {
        while (true)
        {
            for (int i = 0; i < steps.Length; i++)
            {
                enemy.AddForce(steps[i]);
                yield return new WaitForSeconds(moveDelay);
            }
        }
    }
}
