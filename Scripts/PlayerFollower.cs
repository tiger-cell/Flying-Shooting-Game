using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player;

    public float xBounds;

    private Vector3 pos;
    void Start()
    {
        
    }

    void Update()
    {
        pos = new Vector3(Mathf.Clamp(player.transform.position.x, -xBounds, xBounds), transform.position.y, transform.position.z);
        transform.position = pos;
    }
}
