using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blaster : MonoBehaviour
{
    public delegate void BlasterEvent();
    public static event BlasterEvent BlasterCaller;

    public delegate void ThreatResetEvent();
    public static event ThreatResetEvent ThreatCaller;

    [SerializeField] private InputActionReference actionReference;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform[] blasterSpots;
    [SerializeField] Camera arCamera;

    //[SerializeField] GameObject goSplosion;
    private int currentBlaster;
    private void OnEnable(){
        actionReference.action.Enable();
    }
    private void OnDisable(){
        actionReference.action.Disable();
    }

    private void Start(){
        actionReference.action.performed += context => Blast();
    }

    public void Blast()
    {
        // single line if (statement) ? true : false;
        Ray shootFromCamera = arCamera.ScreenPointToRay(Touchscreen.current.position.ReadValue());
        
        if(Physics.Raycast(shootFromCamera, out RaycastHit hit)){
            if(hit.collider.gameObject.CompareTag("Planet")){
                hit.collider.gameObject.GetComponent<Planet>().Explode();
                if(Random.Range(0,100) == 2)
                {
                    ThreatCaller?.Invoke();
                }
                BlasterCaller?.Invoke();
            } else
            {
                Debug.Log($"hit {hit.collider.gameObject.name}");
            }
        } else {
            currentBlaster++;
            if (currentBlaster >= blasterSpots.Length)
            {
                currentBlaster = 0;
            }
            BlasterCaller?.Invoke();        
            Instantiate(bullet, blasterSpots[currentBlaster].position, blasterSpots[currentBlaster].rotation, transform);
            //Debug.DrawRay(blasterSpots[currentBlaster].position, blasterSpots[currentBlaster].forward * 100f, Color.blue, 6f);
        }
    }
}
