using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float turnSpeed;
    //forward & back
    private float verticalInput;
    //rotation
    private float clockWiseInput;
    private float counterClockWiseInput;

    [Header("Components")]
    public Rigidbody rb;

    [Header("Speed")]
    public float thrustForce;

    [Header("GameObjects")]
    public GameObject playerProjectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //getting the better rotation controls with controller and keyboard
        if (Input.GetButton("Clockwise"))
        {
            transform.Rotate(Vector3.up * -1 * turnSpeed * Time.deltaTime);
        }

        if (Input.GetButton("CounterClockwise"))
        {
            transform.Rotate(Vector3.down * -1 * turnSpeed * Time.deltaTime);
        }

        //shooting 
        if(Input.GetButtonDown("Shoot"))
        {
            Instantiate(playerProjectilePrefab);
        }
    }
    private void FixedUpdate()
    {
        //forward and backwards movement
        verticalInput = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * verticalInput * thrustForce);

        
       
    }
}
