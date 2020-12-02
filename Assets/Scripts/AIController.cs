using UnityEngine;

public class AIController : MonoBehaviour
{
    Transform targetNavPoint;
    [SerializeField] public float speedFactor = 1.2f;
    AITrack aiTrack;
    int currentNavPointIndex = 0;
    UpdatePatrol updatePatrol;

    void Start()
    {
        aiTrack = GameObject.Find("AINavPoints").GetComponent<AITrack>();
        if (aiTrack == null)
        {
            Debug.Log("Obiekt AITrack nie został znaleziony");
        }
        updatePatrol = GetComponent<UpdatePatrol>();
        targetNavPoint = aiTrack.NavPoints[currentNavPointIndex];
    }

    public void Patrol()
    {
        Vector3 targetPosition = targetNavPoint.position - transform.position;
        transform.position += targetPosition * speedFactor * Time.deltaTime;
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
