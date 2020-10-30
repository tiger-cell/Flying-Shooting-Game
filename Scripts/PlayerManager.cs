using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager gm;
    public LevelManager lm;
    SpriteRenderer sprite;

    private Rigidbody2D Ship;

    private Vector2 Movement;

    private Vector2 vel;  // Velocity variable used to control projectiles & correct for the clamp at edges.

    public Transform firepoint;
    public GameObject projectile;

    public ParticleSystem explosion;
    private ParticleSystem explode;

    public float xBounds;
    public float yBounds;

    public float XSpeed;
    public float YSpeed;

    // Weapons:
    public float bulletForce1 = 20f;
    public float fireDelay1 = 0.15f;

    public float bulletForce2 = 9f;
    public float fireDelay2 = 0.25f;
    public float spreadAngle2 = 10f;

    public float bulletForce3 = 16f;
    public float fireDelay3 = 0.2f;

    private float nextFire = 0.15f;
    private float myTime = 0.0f;
    public int weaponNum = 1;
    private int numWeapons = 3;

    void Start()
    {
        Ship = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //vel = new Vector2(Ship.velocity.x, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xBounds, xBounds), Mathf.Clamp(transform.position.y, -yBounds, -1), transform.position.z);
        //if (Mathf.Abs(transform.position.x) == xBounds)
        //{
        //    vel = new Vector2(0, 0);
        //}

        Movement = new Vector2(Input.GetAxis("Horizontal") * XSpeed, Input.GetAxis("Vertical") * YSpeed);

        // Shooting:
        myTime = myTime + Time.deltaTime;

        if (Input.GetButtonDown("Fire3"))
        {
            weaponNum += 1;
            if (weaponNum == numWeapons + 1)
            {
                weaponNum = 1;
            }
            gm.weaponChange(weaponNum);
        }

        switch (weaponNum)
        {
            case (1):  // Weapon 1
                if (Input.GetButton("Fire2") && myTime > nextFire)
                {
                    vel = new Vector2(Ship.velocity.x, 0);
                    if (Mathf.Abs(transform.position.x) == xBounds)
                    {
                        vel = new Vector2(0, 0);
                    }

                    nextFire = myTime + fireDelay1;
                    GameObject temp_projectile = Instantiate(projectile, firepoint.position, firepoint.rotation) as GameObject;
                    temp_projectile.GetComponent<Rigidbody2D>().velocity = vel;  // This is so the projectile has the velocty of the ship horizontally (vertically is ignored.)
                    temp_projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce1, ForceMode2D.Impulse);

                    nextFire = nextFire - myTime;
                    myTime = 0.0F;
                }
                break;
            case (2):  // Weapon 2
                if (Input.GetButton("Fire2") && myTime > nextFire)
                {
                    nextFire = myTime + fireDelay2;
                    GameObject temp_projectile1 = Instantiate(projectile, firepoint.position, firepoint.rotation) as GameObject;
                    GameObject temp_projectile3 = Instantiate(projectile, firepoint.position, firepoint.rotation) as GameObject;
                    GameObject temp_projectile2 = Instantiate(projectile, firepoint.position, firepoint.rotation) as GameObject;

                    temp_projectile1.transform.Rotate(Vector3.forward * spreadAngle2);  // Vector3.forward will change the rotation around the Z-axis (I think the only important axis in 2D)
                    temp_projectile2.transform.Rotate(Vector3.forward * -spreadAngle2);

                    //temp_projectile1.GetComponent<Rigidbody2D>().velocity = vel;
                    //temp_projectile3.GetComponent<Rigidbody2D>().velocity = vel;
                    //temp_projectile2.GetComponent<Rigidbody2D>().velocity = vel;

                    temp_projectile1.GetComponent<Rigidbody2D>().AddForce(temp_projectile1.transform.up * bulletForce2, ForceMode2D.Impulse);
                    temp_projectile3.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce2, ForceMode2D.Impulse);
                    temp_projectile2.GetComponent<Rigidbody2D>().AddForce(temp_projectile2.transform.up * bulletForce2, ForceMode2D.Impulse);

                    nextFire = nextFire - myTime;
                    myTime = 0.0F;
                }
                break;
            case (3):  // Weapon 3
                if (Input.GetButton("Fire2") && myTime > nextFire)
                {
                    nextFire = myTime + fireDelay3;

                    GameObject temp_projectile1 = Instantiate(projectile, firepoint.position, firepoint.rotation) as GameObject;
                    GameObject temp_projectile2 = Instantiate(projectile, firepoint.position, firepoint.rotation) as GameObject;
                    GameObject temp_projectile3 = Instantiate(projectile, firepoint.position, firepoint.rotation) as GameObject;
                    GameObject temp_projectile4 = Instantiate(projectile, firepoint.position, firepoint.rotation) as GameObject;

                    //temp_projectile1.GetComponent<Rigidbody2D>().velocity = vel;
                    //temp_projectile2.GetComponent<Rigidbody2D>().velocity = vel;
                    //temp_projectile3.GetComponent<Rigidbody2D>().velocity = vel;
                    //temp_projectile4.GetComponent<Rigidbody2D>().velocity = vel;

                    temp_projectile1.GetComponent<Rigidbody2D>().AddForce(temp_projectile1.transform.up * bulletForce3, ForceMode2D.Impulse);
                    temp_projectile2.GetComponent<Rigidbody2D>().AddForce(temp_projectile1.transform.up * (bulletForce3 * 0.8f), ForceMode2D.Impulse);
                    temp_projectile3.GetComponent<Rigidbody2D>().AddForce(temp_projectile1.transform.up * (bulletForce3 * 0.6f), ForceMode2D.Impulse);
                    temp_projectile4.GetComponent<Rigidbody2D>().AddForce(temp_projectile1.transform.up * (bulletForce3 * 0.4f), ForceMode2D.Impulse);

                    nextFire = nextFire - myTime;
                    myTime = 0.0F;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        /*
         Ship.AddForce(Movement * Time.fixedDeltaTime);
         */
        /*        if (Movement == 0)
                {
                    Ship.velocity.x = 0f;
                }
                else
                {
                    Ship.velocity = Movement;  //Produces movement at constant velocity, with realistic decceleration.
                }*/
        Ship.velocity = Movement;  //Produces movement at constant velocity, with realistic decceleration.

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemies" || collision.tag == "Enemies-Type2")
        {
            explode = Instantiate(explosion, Ship.transform.position, Ship.transform.rotation);
            explode.Play();

            lm.PlayerDied();
            sprite.color = new Color(0.2f, 0.2f, 0.2f, 1);
        }
    }
    // The following block is for changing the colour.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemies" || collision.tag == "Enemies-Type2")
        {
            sprite.color = new Color(1f, 1f, 1f, 1);
        }
    }
}
