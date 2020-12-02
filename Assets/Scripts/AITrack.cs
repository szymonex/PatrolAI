using System.Collections.Generic;
using UnityEngine;

public class AITrack : MonoBehaviour
{
    public List<Transform> NavPoints { get; set; } = new List<Transform>();
    Transform newNavPoint;
    int childIndex = 0;
    UpdatePatrol updatePatrol;

    private void Start()
    {
        updatePatrol = GameObject.Find("AI").GetComponent<UpdatePatrol>();
        if (updatePatrol == null)
        {
            Debug.Log("Obiekt AI nie został znaleziony");
        }
        AddNewNavPointToList();
    }

    public void AddNewNavPointToList()
    {
        if(transform.childCount > 0)
        {
            newNavPoint = gameObject.GetComponentInChildren<Transform>().GetChild(childIndex);
            if (childIndex < transform.childCount - 1)
            {
                childIndex++;
            }
            else
            {
                childIndex = 0;
            }
            NavPoints.Add(newNavPoint);
            updatePatrol.enabled = true;
        }
    }

    public void RemoveNavPointFromList(Transform unusedTargetNavPoint)
    {
        NavPoints.Remove(unusedTargetNavPoint);
    }
}
