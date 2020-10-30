using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Material material;
    Vector2 offset;

    public LevelManager lm;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset = new Vector2(0, lm.scrollRate);

        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
