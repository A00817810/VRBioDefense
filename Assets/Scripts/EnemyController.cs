using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform Player;
    public NavMeshAgent Enemy;
    Ray enemyRay;
    RaycastHit playerDetected;
    public bool follow;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        transform.LookAt(Player);
    }


    // Update is called once per frame
    void Update()
    {
        enemyRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward) * 10);

        if (Physics.Raycast(enemyRay, out playerDetected))
        {
            if(playerDetected.collider.tag == "Player")
            {
                follow = true;
            }
            else
            {
                follow = false;
            }
        }
        else
        {
            follow = false;
        }

        if(follow == true)
        {
            Enemy.SetDestination(Player.transform.position);
        }
        else
        {
            Enemy.SetDestination(Enemy.transform.position);
        }
    }
}
