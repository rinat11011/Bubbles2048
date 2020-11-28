using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float currRotation = 0;
    float speed = 40f;
    bool rightDirection = true;
    int lowerBound = 70;
    int higherBound = 290;


    private void Update()
    {
        rotateArrow();
    }

    void rotateArrow()
    {
        float z = this.gameObject.transform.rotation.eulerAngles.z;
        if (rightDirection)
        {
            currRotation = speed * Time.deltaTime;
            this.gameObject.transform.Rotate(new Vector3(0,0,currRotation));
            if (z <= higherBound - 1 && z >= lowerBound)
            {
                rightDirection = false;
            }
        }
        else
        {
            currRotation = speed * Time.deltaTime;
            this.gameObject.transform.Rotate(new Vector3(0, 0, -currRotation));
            if (z >= lowerBound + 1 && z <= higherBound)
            {
                rightDirection = true;
            }
        }
    
    }
}