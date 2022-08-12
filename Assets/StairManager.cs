using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class StairManager : MonoBehaviour
{
    public NavMeshSurface surface;

    public float start_x;
    public float end_x;

    bool going_positive = false;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (going_positive)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += Time.deltaTime * speed;
            transform.position = newPosition;

            if (transform.position.x >= end_x)
            {
                going_positive = false;
            }
        }
        else
        {
            Vector3 newPosition = transform.position;
            newPosition.x -= Time.deltaTime * speed;
            transform.position = newPosition;

            if (transform.position.x <= start_x)
            {
                going_positive = true;
            }
        }

        surface.BuildNavMesh();
    }
}
