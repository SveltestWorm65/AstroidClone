using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    [Header("Limitations")]
    public float destroyDelay;

    [Header("Bools")]
    public bool isActive = true;

    [Header("Entities")]
    public GameObject player;
    public GameObject enemy;
    // Update is called once per frame

    private void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        /* if (isActive == true)
         {     
             Destroy(gameObject, destroyDelay);
             isActive = false;
             Debug.Log("Destroyed");
         }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) 
        {
            if (isActive == true)
            {
                Destroy(gameObject);
            }
        }
      
    }
}
