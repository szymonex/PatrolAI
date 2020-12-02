using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    Transform targetNavPoint;
    [SerializeField] public float speedFactor;
    AITrack aiTrack;
    int currentNavPointIndex;
    UpdatePatrol updatePatrol;

    void Start()
    {
        aiTrack = GameObject.Find("AINavPoints").GetComponent<AITrack>();
        if (aiTrack == null)
        {
            Debug.Log("Obiekt AITrack nie został znaleziony");
        }
        updatePatrol = GetComponent<UpdatePatrol>();
        currentNavPointIndex = 0;
        targetNavPoint = aiTrack.NavPoints[currentNavPointIndex];
    }

    public void Patrol()
    {
        Vector3 targetPosition = targetNavPoint.position - transform.position;
        transform.position += targetPosition * speedFactor * Time.deltaTime;
        if(targetPosition == targetNavPoint.position)
        {
            updatePatrol.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform == targetNavPoint)
        {
            updatePatrol.enabled = false;
            aiTrack.RemoveNavPointFromList(collision.transform);
            aiTrack.AddNewNavPointToList();
            targetNavPoint = GetNextNavPoint();
        }
    }

    public Transform GetNextNavPoint()
    {
        if(currentNavPointIndex < aiTrack.NavPoints.Count - 1)
        {
            currentNavPointIndex++;
        }
        else
        {
            currentNavPointIndex = 0;
        }
        return aiTrack.NavPoints[currentNavPointIndex];
    }
}
