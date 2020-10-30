using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyShips : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y < -6 || transform.position.y > 6)
        {
            Destroy(gameObject);  //Kills enemy.
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
    if (collision.tag == "player" /* || collision.tag == "PlayerBullet"*/)
        {
            Destroy(gameObject);
        }
    }
}
