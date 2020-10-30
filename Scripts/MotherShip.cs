using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public LevelManager lm;
    private Rigidbody2D motherShip;
    public GameObject babyShips;

    public float lives = 10;
    public float speed;
    public float babySpeed = 1;
    public float spawnTime = 0.9f;
    public Vector2 distance = new Vector2(3,-10);

    void Start()
    {
        motherShip = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(distance, ForceMode2D.Impulse);
        StartCoroutine(SpawnBabyShips());
    }

    void Update()
    {
        if (lives <= 0)
        {
            lm.EnemyKilled(20);
            Destroy(gameObject);  //Kills enemy.
        }
    }


    IEnumerator SpawnBabyShips()
    {
        while (true)
        {
            for (int i=0; i < 360; i += 36)
            {
                GameObject temp_baby = Instantiate(babyShips, motherShip.transform.position, motherShip.transform.rotation) as GameObject;  // Instantiates at the gameObject, but doesn't set as child; doesn't destroy.
                temp_baby.transform.Rotate(Vector3.forward * i);
                temp_baby.GetComponent<Rigidbody2D>().AddForce(temp_baby.transform.up * babySpeed, ForceMode2D.Impulse);
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            lives -= 1;

        }
    }
}
