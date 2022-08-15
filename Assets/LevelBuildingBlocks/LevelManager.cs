using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class LevelManager : MonoBehaviour
{

    private NavMeshSurface surface;

    private void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        BuildNavMesh();
    }

    public void BuildNavMesh()
    {
        surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
