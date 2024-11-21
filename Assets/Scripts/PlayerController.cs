using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public GameObject projectileSpawner;
    public GameObject levelControl;
  
    [Header("Bools")]
    public bool gameOver = false;

    [Header("UI Elements")]
    public TextMeshProUGUI deathTxt;
    public Button Restart;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //getting the better rotation controls with controller and keyboard
        if (Input.GetButton("Clockwise") || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -1 * turnSpeed * Time.deltaTime);
        }

        if (Input.GetButton("CounterClockwise") || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * -1 * turnSpeed * Time.deltaTime);
        }

        //shooting 
        if(Input.GetButtonDown("Shoot") || Input.GetMouseButtonDown(0))
        {
            Instantiate(playerProjectilePrefab, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
        }
    }
    private void FixedUpdate()
    {
        //forward and backwards movement
        verticalInput = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * verticalInput * thrustForce);

        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            levelControl.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
            deathTxt.gameObject.SetActive(true);
        }
    }
}
