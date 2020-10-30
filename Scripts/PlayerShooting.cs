using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject projectile;

    public float bulletForce = 20f;
    public float fireDelay = 0.15f;

    private float nextFire = 0.15f;
    private float myTime = 0.0f;


    public GameManager gm;


    void Update()
    {

        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Jump") && myTime > nextFire)
        {
            nextFire = myTime + fireDelay;
            Instantiate(projectile, firepoint.transform).GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }

}
