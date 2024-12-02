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
    public AudioClip splat;

    [Header("GameObjects")]
    public GameObject playerProjectilePrefab;
    public GameObject projectileSpawner;
    public GameObject Bumper;
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

        //particle system
        if(verticalInput >= 0.1)
        {
            ps.Play();
        }
        else if(verticalInput <= 0)
        {
            ps.Stop();
        }

        //boosting power!
        if (Input.GetButtonDown("Boost"))
        {
            if (thrustForce >= 0.5)
            {
                StartCoroutine(Boosting());
            }  
        }
    }
    IEnumerator Boosting()
    {
        if (rb.velocity.magnitude >= 0.75f)
        {
            rb.AddRelativeForce(Vector3.forward * verticalInput * boostCharge * 1.25f, ForceMode.Impulse);
            isBoosting = true;
            gm.Invince = true;
            Bumper.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        Bumper.gameObject.SetActive(false);
        gm.Invince = false;
        isBoosting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //running enemies over with the bumper and preventing loosing lives
        if(Bumper.CompareTag("Enemy") && gm.Invince == true)
        {
            Destroy(collision.gameObject);
            playerAudio.PlayOneShot(splat);
            gm.Invince = false;
            Bumper.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if lives reaches 0 game over happens
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
