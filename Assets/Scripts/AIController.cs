using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform targetNavPoint;
    public float speedFactor;
    public AITrack aiTrack;
    public int currentNavPointIndex;


    // Start is called before the first frame update
    void Start()
    {

        aiTrack = GameObject.FindObjectOfType<AITrack>();
        if (aiTrack == null)
        {
            Debug.Log("Obiekt typu AITrack nie został znaleziony");
        }
        currentNavPointIndex = 0;
        targetNavPoint = aiTrack.navPoints[currentNavPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();

    }

    void Patrol()
    {
        Vector3 toTarget = targetNavPoint.position - transform.position;
        transform.position += toTarget * speedFactor * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.transform == targetNavPoint)
        {
            targetNavPoint = GetNextNavPoint();
        }
    }

    public Transform GetNextNavPoint()
    {
        if (currentNavPointIndex < aiTrack.navPoints.Length - 1)
        {
            currentNavPointIndex++;
        }
        else
        {
            currentNavPointIndex = 0;
        }
        return aiTrack.navPoints[currentNavPointIndex];
    }
}
