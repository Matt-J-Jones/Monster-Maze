using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterMove : MonoBehaviour
{
    public GameObject targetDest;
    public NavMeshAgent monster;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        monster.SetDestination(targetDest.transform.position);
    }
}
