using UnityEngine;

public class UpdatePatrol : MonoBehaviour
{
    AIController controller;
    void Start()
    {
        controller = GetComponent<AIController>();
    }

    void Update()
    {
        controller.Patrol();
    }
}
