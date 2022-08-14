using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class BuildableBehaviour : MonoBehaviour
{
    public enum BuildableState
    {
        UserHeld,
        Static
    }

    public Material defaultMaterial;
    public Material collisionMaterial;


    public BuildableState state = BuildableState.UserHeld;
    
    private LevelManager level;

    private BoxCollider boxCollider;
    private MeshCollider[] meshCollider;
    private MeshRenderer[] meshRenderer;
    private int colider_count = 0;

    void Start()
    {
        meshRenderer = GetComponentsInChildren<MeshRenderer>();
        meshCollider = GetComponentsInChildren<MeshCollider>();
        boxCollider = GetComponent<BoxCollider>();
        level = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BuildableState.UserHeld)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask layerMask = (1 << 11);
            layerMask |= (1 << 12);
            Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask);

            transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

            if (Input.GetMouseButtonDown(1))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90f, transform.rotation.eulerAngles.z);
            }

            if (Input.GetMouseButtonDown(0) && colider_count == 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                boxCollider.enabled = false;
                foreach (MeshCollider colider in meshCollider) {
                    colider.enabled = true;
                }
                state = BuildableState.Static;
                level.BuildNavMesh();
                gameObject.layer = 12;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colider_count += 1;
        foreach (MeshRenderer renderer in meshRenderer)
        {
            renderer.material = collisionMaterial;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        colider_count -= 1;
        if (colider_count == 0)
        {

            foreach (MeshRenderer renderer in meshRenderer)
            {
                renderer.material = defaultMaterial;
            }
        }
    }
}

