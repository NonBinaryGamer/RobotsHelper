using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderButton : MonoBehaviour
{
    public GameObject spanwed_object;
    public Camera cam;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBuild()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        Instantiate(spanwed_object, hit.point, Quaternion.identity);

    }
}
