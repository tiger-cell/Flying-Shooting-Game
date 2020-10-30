using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public ParticleSystem explosion;
    private ParticleSystem explode;

    public float xBounds = 15;
    public float yBounds = 10;

    void Update()
    {
        if (transform.position.x < -xBounds)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > xBounds)
        {
            Destroy(gameObject);

        }
        if (transform.position.y < -yBounds)
        {
            Destroy(gameObject);

        }
        if (transform.position.y > yBounds)
        {
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemies")
        {
            explode = Instantiate(explosion, transform.position, transform.rotation);  // Instantiates at the gameObject, but doesn't set as child; doesn't destroy.

            explode.Play();
        }
    }


}
