using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float spawnTime;

    public int enemyLives = 2;
    public float xBounds = 10;
    public float amplitude;
    public float frenquency;
    public float speed = 2f;
    void Start()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        if (enemyLives <= 0)
        {
            //            gm.EnemyDied();
            Destroy(gameObject);  //Kills enemy.
        }

        if (transform.position.x > xBounds)
        {
            //            gm.EnemyDied();
            Destroy(gameObject);  //Kills enemy.
        }

        float lifeTime = Time.time - spawnTime - 8f;
        float x = lifeTime;
        float y = Mathf.Cos(lifeTime * frenquency) * amplitude;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            enemyLives -= 1;

        }
    }
}
