using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    [Header("Floats")]
    public float speed;

    [Header("Components")]
    public GameManager gm;
    public GameObject sm;
    public Rigidbody enemyRb;
    public BoxCollider enemyCollider;

    [Header("GameObjects")]
    public GameObject player;

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
        enemyCollider = GetComponent<BoxCollider>();
        enemyRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
          
        }
    }
}
