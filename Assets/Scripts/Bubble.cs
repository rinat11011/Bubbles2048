using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble: MonoBehaviour
{
    public int value;
    bool isMoving = false;
    float fireSpeed = 10f;
    Vector3 direction;

    private void Update()
    {
        if (isMoving)
        {
            fireCannon();
        }
        
    }

    void fireCannon()
    {
        if(isMoving)
        {
            transform.position += direction * fireSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            isMoving = false;
        }
        if (collision.gameObject.tag == "Frame")
        {
            isMoving = false;
        }
    }

    public void startMoving(Quaternion rotation)
    {
        isMoving = true;
        direction = rotation * Vector3.up;
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
