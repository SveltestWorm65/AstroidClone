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
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;

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

        //getting SpawnPoints for spawning the smaller enemies
        spawnPoint1 = GameObject.Find("EnemySpawnPoint1");
        spawnPoint2 = GameObject.Find("EnemySpawnPoint2");

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
            StartCoroutine(SpawnBabies());
            gm.AddScore(1);
            Destroy(gameObject);
           
        }
    }

    IEnumerator SpawnBabies()
    {
        Instantiate(enemyBabies, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
        Instantiate(enemyBabies, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
        yield return new WaitForSeconds(0);
    }










}
