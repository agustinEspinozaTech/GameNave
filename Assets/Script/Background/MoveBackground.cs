using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float speed = 0.2f; // Speed of the background movement

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
