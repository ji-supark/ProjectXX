using UnityEngine;
using System.Collections;

public class NavTest : MonoBehaviour {
    public Transform target;
    public NavMeshAgent agent;
    public bool stopAgent = false;
    public GameObject lookAtTarget;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
	}
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.S) && stopAgent == false)
        {
            // agent.SetDestination(transform.position);
            agent.updatePosition = false;
            agent.updateRotation = false;
            stopAgent = true;
            
        }
        MakeLookAtDirection();
    }

    void MakeLookAtDirection()
    {
        Vector3 direction = (lookAtTarget.transform.position -
            transform.position).normalized;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 120.0f);
    }
}
