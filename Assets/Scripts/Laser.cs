using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject goSplosion;
    [SerializeField] float DistanceToCheck = 0.001f;
    [SerializeField] float forwardSpeed = 0.01f;
    [SerializeField] float sphereSize = 0.005f;
    [SerializeField] float autoDestructTime = 1.5f;

    private void Start()
    {
        Destroy(gameObject, autoDestructTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward + new Vector3(0f, 0f, forwardSpeed * Time.deltaTime);
        Ray fRay = new Ray(transform.position, transform.forward);
        if(Physics.SphereCast(fRay, sphereSize, out RaycastHit hit,DistanceToCheck))
        {
            Instantiate(goSplosion, hit.point + hit.normal,Quaternion.LookRotation(hit.normal, Vector3.up));
            Destroy(gameObject);
        }
    }
}
