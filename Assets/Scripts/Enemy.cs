using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Bools")]
   

    [Header("Floats")]
    public float speed;

    [Header("Components")]
    public GameManager gm;
    public GameObject sm;
    public Rigidbody enemyRb;
    public BoxCollider enemyCollider;

    [Header("GameObjects")]
    public GameObject player;
    public GameObject enemyBabies;

    [Header("Scripts")]
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //finding components and game objects
        sm = GameObject.Find("SpawnManager").GetComponent<GameObject>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");

        //getting the enemie's components
        enemyCollider = GetComponent<BoxCollider>();
        enemyRb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //finding the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);
        enemyRb.AddTorque(lookDirection * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        //kill the enemy and spawn babies
        if(other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            SpawnBabies();
        }
    }

    IEnumerator SpawnBabies()
    {
        yield return new WaitForSeconds(0);
        Instantiate(enemyBabies, transform.position, transform.rotation);
        Instantiate(enemyBabies, transform.position, transform.rotation);
        yield return new WaitForSeconds(0);
    }










}
