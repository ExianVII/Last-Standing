using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyController : MonoBehaviour
{

    public Transform target;
    public float speed = 20;
    public float nextWaypointDistance = 3;
    public Transform enemyImage;
    private Path path;
    private int currentWaypoint = 0;
    private bool PathIsDone = false;

    private Seeker seeker;
    private Rigidbody2D enemyRBD;

    void Start()
    {

        seeker = GetComponent<Seeker>();
        enemyRBD = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(enemyRBD.position, target.position, OnPathComplete);

    }


    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            PathIsDone = true;
            return;
        }

        else
        {
            PathIsDone = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint]
            - enemyRBD.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;
        enemyRBD.AddForce(force);

        float distance = Vector2.Distance(enemyRBD.position,
            path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            enemyImage.localScale = new Vector3(1f, 1f, 1f);
        }

        else if (force.x <= -0.01f)
        {
            enemyImage.localScale = new Vector3(-1f, 1f, 1f);
        }

    }
}