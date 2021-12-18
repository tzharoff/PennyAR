using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    [Header("AudioClips")]
    [SerializeField] private AudioClip Shoot;
    [SerializeField] private AudioClip Explosion;

    [Header("AudioSources")]
    [SerializeField] private AudioSource asShoot;
    [SerializeField] private AudioSource asExplosion;


    private void OnEnable()
    {
        Laser.ExplosionCaller += PlayExplosion;
        Blaster.BlasterCaller += PlayBlaster;
    }

    private void OnDisable()
    {
        Laser.ExplosionCaller -= PlayExplosion;
        Blaster.BlasterCaller -= PlayBlaster;
    }

    private void Start()
    {
    }

    private void PlayBlaster()
    {
        asShoot.PlayOneShot(Shoot);
    }

    private void PlayExplosion()
    {
        asExplosion.PlayOneShot(Explosion);
    }
}
