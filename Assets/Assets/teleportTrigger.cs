using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class teleportTrigger : MonoBehaviour
{
    public Vector3 tujuanPoint;
    public Quaternion tujuanRotasi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            {
                NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
                agent.SetDestination(tujuanPoint);
                other.transform.position = tujuanPoint;
                other.transform.rotation = tujuanRotasi;
                Debug.Log(agent.desiredVelocity);
            }
    }
}
