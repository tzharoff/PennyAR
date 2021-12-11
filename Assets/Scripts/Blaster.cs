using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform[] blasterSpots;
    private int currentBlaster;

    public void Blast()
    {
        currentBlaster++;
        if (currentBlaster >= blasterSpots.Length)
        {
            currentBlaster = 0;
        }
        Debug.Log($"currentBlaster");
        Instantiate(bullet, blasterSpots[currentBlaster].position,blasterSpots[currentBlaster].rotation);
    }
}
