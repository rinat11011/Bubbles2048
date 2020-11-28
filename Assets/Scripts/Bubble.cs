using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble: MonoBehaviour
{
    public int value;
    bool isMoving = false;
    float fireSpeed = 15f;
    Vector3 direction;
    Vector3 lastVelocity;
    private Rigidbody2D rigidBody;
    Quaternion shootingRotation;
    public Vector2 position;
    public int i,j;

    private void Awake()
    {
        this.position = this.transform.position;
        rigidBody = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isMoving)
        {
            fireCannon();
        }
        if(this.tag == "Bubble")
        {
            this.transform.position = position;
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
        GameObject coll = collision.gameObject;

        if (coll.tag == "Bubble")
        {
            isMoving = false;
            //coll.transform.position = coll.GetComponent<Bubble>().position;
            this.position = this.transform.position;
            int i = (int) Mathf.Round((this.position.y - 3.5f) / (-0.5f));
            float y = (3.5f - i * 0.5f);
            float x;

            if(i%2 == 0)
            {
                int j = (int)Mathf.Round((this.position.x + 2.5f) / 0.6f);
                x = (-2.5f + j * 0.6f);
            }
            else
            {
                int j = (int)Mathf.Round((this.position.x + 2.5f) / 0.6f);
                x = (-2.2f + j * 0.6f);
            }


            this.position = new Vector2(x, y);
            this.tag = "Bubble";

            //pos = new Vector2((i % 2 == 0 ? (-2.5f + j * 0.6f) : (-2.2f + j * 0.6f)), (3.5f - i * 0.5f));

        }

        if (collision.gameObject.tag == "Wall" && this.tag == "CurrBubble")
        {
            shootingRotation.eulerAngles = new Vector3(shootingRotation.eulerAngles.x, 
                                                       shootingRotation.eulerAngles.y+180, 
                                                       shootingRotation.eulerAngles.z);
            startMoving(shootingRotation);
        }
    }

    public void startMoving(Quaternion rotation)
    {
        this.shootingRotation = rotation;
        isMoving = true;
        direction = rotation * Vector3.up;

    }

    public bool IsMoving()
    {
        return isMoving;
    }

    
}
