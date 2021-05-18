using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

     public Transform target;
     public float damping = 1;
     public float lookAheadFactor = 3;
     public float lookAheadTurnSpeed = 0.5f;
     public float lookAheadMoveThreshold = 0.1f;
     public float yPosRestriction = -1;

    float offsetZ;
    Vector3 lastTargetPosition;
    Vector3 currentVelocity;
    Vector3 lookAheadPos;

    //respawn timer
    float nextTimetoSearch = 0;

    // Start is called before the first frame update
    void Start()
    {

            lastTargetPosition = target.position;
            offsetZ = (transform.position - target.position).z;
            transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            FindPlayer();
            return;
        }
        float xMoveData = (target.position - lastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveData) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveData);

        }

        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadTurnSpeed);
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

        newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, yPosRestriction, Mathf.Infinity), newPos.z);
        transform.position = newPos;
        lastTargetPosition = target.position;
    }

   public void FindPlayer()
    {
        if(nextTimetoSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");

            // player object found
            if(searchResult != null)
            {
                target = searchResult.transform;
            }
            nextTimetoSearch = Time.time + 0.5f;
        }
    }


    
}
