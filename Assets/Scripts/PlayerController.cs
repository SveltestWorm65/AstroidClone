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
    public ParticleSystem ps;
    public AudioSource playerAudio;

    [Header("Speed")]
    public float thrustForce;
    public float boostCharge;

    [Header("Audio")]
    public AudioClip laser;

    [Header("GameObjects")]
    public GameObject playerProjectilePrefab;
    public GameObject projectileSpawner;
    public GameObject levelControl;
    public GameManager gm;
    
  
    [Header("Bools")]
    public bool gameOver = false;
    public bool isBoosting = false;
    public bool boostOnCoolDown = false;

    [Header("UI Elements")]
    public TextMeshProUGUI deathTxt;
    public Button Restart;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ps = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        playerAudio = GetComponent<AudioSource>();


        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //getting the rotation controls with controller and keyboard
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
            playerAudio.PlayOneShot(laser);
        }
    }
    private void FixedUpdate()
    {
        //forward and backwards movement
        verticalInput = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * verticalInput * thrustForce);

        //boosting power!
        if(Input.GetButton("Boost"))
        {
            Debug.Log("IsBeingPushed");
            if (!boostOnCoolDown)
            {
                if(boostCharge >= 1)
                {
                    isBoosting = true;
                    thrustForce = 50;
                }
                if (boostCharge < 1)
                {
                    isBoosting = false;
                }
              
            }
          
        }
        if(Input.GetButtonUp("Boost"))
        {
            isBoosting = false;
        }
        if(boostCharge < 1)
        {
            isBoosting = false;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gm.LooseLife();
            Destroy(other.gameObject);
            if(gm.lives <= 0)
            {
                gameOver = true;
               
                turnSpeed = 0;
                thrustForce = 0;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                levelControl.gameObject.SetActive(true);
                Restart.gameObject.SetActive(true);
                deathTxt.gameObject.SetActive(true);
               
            }
         
        }
    }
}
