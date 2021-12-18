using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public delegate void BlasterEvent();
    public static event BlasterEvent BlasterCaller;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform[] blasterSpots;
    [SerializeField] Camera arCamera;
    private int currentBlaster;

    public void Blast()
    {
        currentBlaster++;
        if (currentBlaster >= blasterSpots.Length)
        {
            currentBlaster = 0;
        }
        if (BlasterCaller != null) BlasterCaller();
        Instantiate(bullet, blasterSpots[currentBlaster].position, blasterSpots[currentBlaster].rotation, transform);
        Debug.DrawRay(blasterSpots[currentBlaster].position, blasterSpots[currentBlaster].forward * 100f, Color.blue, 6f);
    }
}
