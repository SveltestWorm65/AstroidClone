using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    [Header("Limits")]
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
  
    // Update is called once per frame
    void Update()
    {
        //making the objects go to the other side of the x axis
        if(transform.position.x > xMax)
        {
            transform.position = new Vector3(
                xMin,
                transform.position.y,
                transform.position.z
                ); 
        }
        if (transform.position.x < xMin)
        {
            transform.position = new Vector3(
                xMax,
                transform.position.y,
                transform.position.z
                );
        }

        //making the z axis do the same as x
        if (transform.position.z > zMax)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                zMin
                );
        }
        if (transform.position.z < zMin)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                zMax
                );
        }
    }
}
