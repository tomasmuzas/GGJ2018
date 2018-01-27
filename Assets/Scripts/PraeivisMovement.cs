﻿using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class PraeivisMovement : MonoBehaviour
{
    public Transform target;
    public float updateRate = 2f;

    public Seeker seeker;

    public Rigidbody2D rb;

    public Path path;

    public float speed;
    public ForceMode2D fMode;

    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    // Use this for initialization
    void Start ()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            return;
        }

        // Start new path
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    private IEnumerator UpdatePath()
    {
        if (target != null)
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);

            yield return new WaitForSeconds( 1f/updateRate);
            StartCoroutine(UpdatePath());
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (target == null || path == null)
        {
            Debug.Log("No target or path.");
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }

            Debug.Log("End of path reached.");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        Vector3 dir = path.vectorPath[currentWaypoint] - transform.position;
        dir *= speed *Time.fixedDeltaTime;

        rb.velocity = dir;
        //rb.AddForce(dir, fMode);

        var dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
;