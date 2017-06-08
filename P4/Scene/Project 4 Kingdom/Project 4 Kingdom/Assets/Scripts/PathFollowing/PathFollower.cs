using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    public Transform[] path;
    public float speed = 5.0f;
    public float reachDistance = 1.0f;
    public int currentPoint = 0;
    Vector3 dir;

    void Start()
    {

    }

    void Update()
    {
        //dir = path[currentPoint].position - transform.position;
        float distance = Vector3.Distance (path[currentPoint].position, transform.position);

        transform.position = Vector3.MoveTowards (transform.position, path[currentPoint].position, Time.deltaTime * speed);

        if (distance <= reachDistance)
        {
            currentPoint++;
        }

        if(currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }

    void OnDrawGizmos()
    {
        if (path.Length > 0)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawWireSphere(path[i].position, reachDistance);
                }
            }
        }
    }
}
