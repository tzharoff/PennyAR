using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public delegate void ExplosionPublisher();
    public static event ExplosionPublisher ExplosionCaller;

    [SerializeField] private GameObject goSplosion;

    [SerializeField] float spinSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, spinSpeed * Time.deltaTime, 0f));
    }

    public void Explode(){
        Instantiate(goSplosion, transform.position,Quaternion.identity);
        PlanetSpawner.instance.RemovePlanet(gameObject);
        ExplosionCaller?.Invoke();
        Destroy(gameObject);
    }
}
