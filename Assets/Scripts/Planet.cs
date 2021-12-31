using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Planet : MonoBehaviour
{
    public delegate void ExplosionPublisher();
    public static event ExplosionPublisher ExplosionCaller;

    [SerializeField] private GameObject goSplosion;

    [Header("Spin")]
    [SerializeField] float spinMinSpeed = 1.5f;
    [SerializeField] float spinMaxSpeed = 2.5f;

    [Header("Scale")]
    [SerializeField] float maxScale = 0.25f;
    [SerializeField] float minScale = 0.15f;

    private MMFeedbacks Explosion;

    private float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        Explosion = GetComponent<MMFeedbacks>();
        spinSpeed = Random.Range(spinMinSpeed, spinMaxSpeed);
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
        Explosion?.PlayFeedbacks();
        //gameObject.SetActive(false);
        DestroyMe();
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
