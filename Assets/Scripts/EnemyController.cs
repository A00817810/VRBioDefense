using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent Enemy;
    Ray enemyRay;
    RaycastHit playerDetected;
    public Color rayColor;
    public bool follow;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRay = new Ray(transform.position, transform.forward * 10);
        Debug.DrawRay(transform.position, transform.forward * 10, rayColor);

        if(Physics.Raycast(transform.position, transform.forward, out playerDetected, 10.0f))
        {
            follow = true;
        }

        if(follow == true)
        {
            Enemy.SetDestination(Player.transform.position);
        }
    }
}
