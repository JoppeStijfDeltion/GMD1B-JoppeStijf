using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    public List<Transform> path = new List<Transform>();
    public float speed = 5.0f;
    public float reachDistance = 1.0f;
    public int currentPoint = 0;
    public Vector3 dir;

    public Transform currentPointPos;

    void Update()
    {
        currentPointPos = path[currentPoint];
        dir = currentPointPos.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);

        float distance = Vector3.Distance (path[currentPoint].position, transform.position);
        transform.position = Vector3.MoveTowards (transform.position, path[currentPoint].position, Time.deltaTime * speed);

        if (distance <= reachDistance)
        {
            currentPoint++;
        }

        if(currentPoint >= path.Capacity)
        {
            currentPoint = 0;
        }
    }

    void OnDrawGizmos()
    {
        if (path.Capacity > 0)
        {
            for (int i = 0; i < path.Capacity; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawWireSphere(path[i].position, reachDistance);
                }
            }
        }
    }
}
