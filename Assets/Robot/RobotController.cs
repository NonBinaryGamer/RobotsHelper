using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    private List<Collectible> collectibles;
    private int score = 0;
    private bool go_pressed = false;
    private Collectible closest;

    private void Start()
    {
        collectibles = new List<Collectible>(FindObjectsOfType<Collectible>());
    }

    // Update is called once per frame
    void Update()
    {
        if (go_pressed && closest == null)
        {
            Go();
        }
    }

    public void Go()
    {
        go_pressed = true;
        
        Debug.Log(collectibles.Count);

        float distance = float.MaxValue;
        closest = null;
        foreach(Collectible collectible in collectibles)
        {
            float new_distance = Vector3.Distance(transform.position, collectible.transform.position);

            if (new_distance < distance)
            {
                distance = new_distance;
                closest = collectible;
            }
        }

        agent.SetDestination(closest.transform.position);
    }

    public void AddScore(Collectible collectible)
    {
        score += 1;
        Debug.Log(score);
        collectibles.Remove(collectible);
        
    }
}
