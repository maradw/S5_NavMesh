using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private float range;
    [SerializeField] private Transform centerPlane;

    Vector3 targetPos;

    [SerializeField] private Transform targetPoint;
    void Start()
    {
        
    }


    void Update()
    {
        MoveToTarge(targetPos);
    }
    //
    private bool RandomPoint(Vector3 center, float range, out Vector3 result )
    {
        Vector3 randomTarget = center + Random.insideUnitSphere *range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomTarget, out hit,0.5f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
    void MoveToTargePosition()
    {
        if (enemy.remainingDistance <= enemy.stoppingDistance)
        {
            Vector3 target;
            if (RandomPoint(centerPlane.position, range, out target))
            {
                Debug.DrawRay(target, Vector2.up, Color.magenta, 0.8f);
                enemy.SetDestination(target);
                
            }
        }
    }
    void MoveToTarge(Vector3 target)
    {
        if (enemy.remainingDistance <= enemy.stoppingDistance)
            if (RandomPoint(centerPlane.position, range, out target))
            {
                Debug.DrawRay(target, Vector2.up, Color.magenta, 0.8f);
                enemy.SetDestination(target);

            }
        
    }
    ///

}
