using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public int lives;

    public float speed;
    public float amplitude;
    public float frequency;
    public float yBound = 5f;
    private float xStart;

    private bool down = true;

    private void Start()
    {
        xStart = transform.position.x;

        amplitude += Random.Range(-1f, 1f);
        frequency += Random.Range(-1f, 1f);
    }
    private void Update()
    {
        if (lives <= 0) {
            Destroy(gameObject);
        }

        
        if (transform.position.y < -yBound)
        {
            down = false;
        }
        else if (transform.position.y > yBound)
        {
            down = true;
        }

        if (down)
        {
            transform.position = new Vector2(xStart + amplitude * Mathf.Sin(transform.position.y * frequency), transform.position.y - speed);
        }
        else
        {
            transform.position = new Vector2(xStart + amplitude * Mathf.Sin(transform.position.y * frequency), transform.position.y + speed);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            lives -= 1;
        }
    }
}
