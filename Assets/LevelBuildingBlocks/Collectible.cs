using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float rotationSpeed = 50f;
    public RobotController robot;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0f, Random.rotation.eulerAngles.y, 0f));
        robot = FindObjectOfType<RobotController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * rotationSpeed, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            robot.AddScore(this);
            Destroy(gameObject);
        }
    }
}
