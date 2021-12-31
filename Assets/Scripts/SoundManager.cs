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
    [SerializeField] private AudioSource asLaugh;
    [SerializeField] private AudioSource asThreat;

    [Header("Alien Sounds")]
    [SerializeField] private AudioClip[] alienLaughs;
    [SerializeField] private AudioClip[] alienThreats;

    private void OnEnable()
    {
        Planet.ExplosionCaller += PlayExplosion;
        Blaster.BlasterCaller += PlayBlaster;
        RandomSounds.AlienLaugh += PlayAlienLaugh;
        RandomSounds.AlienThreat += PlayAlienThreat;
    }

    private void OnDisable()
    {
        Planet.ExplosionCaller -= PlayExplosion;
        Blaster.BlasterCaller -= PlayBlaster;
        RandomSounds.AlienLaugh -= PlayAlienLaugh;
        RandomSounds.AlienThreat -= PlayAlienThreat;
    }

    private void Start()
    {
    }

    private void PlayAlienLaugh()
    {
        if (!asLaugh.isPlaying && !asThreat.isPlaying)
        {
            AudioClip laugh = alienLaughs[Random.Range(0, alienLaughs.Length - 1)];
            asLaugh.PlayOneShot(laugh);
        }
    }

    private void PlayAlienThreat()
    {
        if (!asThreat.isPlaying && !asLaugh.isPlaying)
        {
            AudioClip threat = alienThreats[Random.Range(0, alienThreats.Length - 1)];
            asThreat.PlayOneShot(threat);
        }
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
