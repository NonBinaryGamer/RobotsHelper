using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NavigationManager : MonoBehaviour
{
    public List<NavMeshSurface> surfaces;
    public Transform[] objectsToRotate;

    // Start is called before the first frame update
    void Start()
    {
        var xsurfaces = FindObjectsOfType(typeof(NavMeshSurface));
        foreach (var x in xsurfaces)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
