using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject goSplosion;
    [SerializeField] float DistanceToCheck = 1f;
    [SerializeField] float shootDistance = 1f;
    //[SerializeField] float forwardSpeed = 0.01f;
    [SerializeField] float sphereSize = 0.005f;
    [SerializeField] float autoDestructTime = 1.5f;
    [SerializeField] LayerMask layers;
    //[SerializeField] Camera arCamera;

    private Vector3 startPosition;
    private Vector3 destinationPosition;
    private float timer;

    private void Start()
    {
        Destroy(gameObject, autoDestructTime);
        startPosition = transform.position;
        destinationPosition = transform.position + (transform.forward * shootDistance);
        //Debug.DrawLine(startPosition, destinationPosition, Color.green, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, destinationPosition, timer / autoDestructTime);
        Ray fRay = new Ray(transform.position, transform.forward);
        if(Physics.SphereCast(fRay, sphereSize, out RaycastHit hit, DistanceToCheck,layers))
        {
            /*
            Debug.Log($"Hit {hit.collider.gameObject}");
            Instantiate(goSplosion, hit.collider.gameObject.transform.position,Quaternion.identity);
            Destroy(hit.collider.gameObject);
            PlanetSpawner.instance.RemovePlanet(hit.collider.gameObject);
            if(ExplosionCaller !=null) ExplosionCaller();
            */
            hit.collider.gameObject.GetComponent<Planet>().Explode();
            Destroy(gameObject);
        }
    }
}
