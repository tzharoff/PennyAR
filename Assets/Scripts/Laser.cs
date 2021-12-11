using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject goSplosion;
    [SerializeField] float DistanceToCheck = 1f;
    [SerializeField] float shootDistance = 1f;
    [SerializeField] float forwardSpeed = 0.01f;
    [SerializeField] float sphereSize = 0.005f;
    [SerializeField] float autoDestructTime = 1.5f;
    [SerializeField] LayerMask layers;

    private Vector3 startPosition;
    private Vector3 destinationPosition;
    private float timer;

    private void Start()
    {
        Destroy(gameObject, autoDestructTime);
        startPosition = transform.position;
        destinationPosition = transform.forward + new Vector3(0f, 0f, shootDistance);
        //GetComponent<Rigidbody>().AddForce(transform.forward * forwardSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, destinationPosition, timer / autoDestructTime);
        //transform.position += transform.forward + new Vector3(0f, 0f, forwardSpeed * Time.deltaTime);
        Ray fRay = new Ray(transform.position, transform.forward);
        if(Physics.SphereCast(fRay, sphereSize, out RaycastHit hit,DistanceToCheck,layers))
        {
            Instantiate(goSplosion, hit.point + hit.normal,Quaternion.LookRotation(hit.normal, Vector3.up));
            Destroy(gameObject);
        }
    }
}
