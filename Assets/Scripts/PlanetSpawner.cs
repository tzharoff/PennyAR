using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{

    #region Singleton
    public static PlanetSpawner instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("Boundaries")]
    [SerializeField] GameObject goTOP;
    [SerializeField] GameObject goBOTTOM;
    [SerializeField] GameObject goRIGHT;
    [SerializeField] GameObject goLEFT;
    [SerializeField] GameObject goFRONT;
    [SerializeField] GameObject goBACK;

    [Header("Planets")]
    [SerializeField] private int maxPlanets = 5;
    [SerializeField] private List<GameObject> planetsToSpawn = new List<GameObject>();
    [SerializeField] private List<GameObject> planetsSpawned = new List<GameObject>();
    [SerializeField] private List<Transform> centerOfGalaxy = new List<Transform>();
    [SerializeField] private float SpawnTimer = 2.5f;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private float zMin;
    private float zMax;

    private float randomX
    {
        get { return Random.Range(xMin, xMax); }
    }
    private float randomY
    {
        get { return Random.Range(yMin, yMax); }
    }
    private float randomZ
    {
        get { return Random.Range(zMin, zMax); }
    }

    private bool spawnPlanets = true;


    // Start is called before the first frame update
    void Start()
    {
        xMin = goLEFT.transform.position.x;
        xMax = goRIGHT.transform.position.x;
        yMin = goBOTTOM.transform.position.y;
        yMax = goTOP.transform.position.y;
        zMin = goBACK.transform.position.z;
        zMax = goFRONT.transform.position.z;
        StartCoroutine(Spawn());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(SpawnTimer);
        SpawnPlanet();
    }

    public void StartSpawningPlanets()
    {

    }

    public void StopSpawningPlanets()
    {

    }

    public void RemovePlanet(GameObject planetInput)
    {
        planetsSpawned.Remove(planetInput);
    }

    private void SpawnPlanet()
    {
        if(planetsSpawned.Count <= maxPlanets)
        {
            GameObject goTemp = Instantiate(planetsToSpawn[Random.Range(0, planetsToSpawn.Count - 1)], centerOfGalaxy[Random.Range(0,(centerOfGalaxy.Count - 1))]);
            goTemp.transform.position = new Vector3(randomX, randomY, randomZ);
            planetsSpawned.Add(goTemp);
        }
        StartCoroutine(Spawn());
    }
}
