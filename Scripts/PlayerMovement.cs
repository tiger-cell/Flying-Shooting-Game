using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Ship;
    public float XSpeed;
    public float YSpeed;

    private Vector2 Movement;

    void Start()
    {
        Ship = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        /* This code snippet is for Realistic acceleration (and unrealistic decceleration.) It is too complex for v1.
        if (xMovement == 0)
        {
            xMovement = Ship.velocity.x * -1;
        }
        else if (Ship.velocity.x > xSpeedCap)
        {
        xMovement == 0;
        }
        */
        
        Movement = new Vector2(xMovement * XSpeed, 0/*Input.GetAxis("Vertical") * YSpeed * 10*/);
        
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
}
