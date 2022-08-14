using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);

                NavMeshPath nmp = new NavMeshPath();

                bool pathFound = agent.CalculatePath(hit.point, nmp) && nmp.status == NavMeshPathStatus.PathComplete;
                Debug.Log(pathFound);



            }
        }
    }
}
