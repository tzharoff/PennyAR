using System;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    #region Broadcasters
    public static event Action AlienLaugh;
    public static event Action AlienThreat;
    #endregion


    [SerializeField] private float RandomThreatTime = 30f;

    private float timer = 0f;


    private void OnEnable()
    {
        Blaster.ThreatCaller += AlienDestructionThreat;
        Planet.ExplosionCaller += PlayLaugh;
    }

    private void OnDisable()
    {
        Blaster.ThreatCaller -= AlienDestructionThreat;
        Planet.ExplosionCaller -= PlayLaugh;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < RandomThreatTime)
        {
            timer += Time.deltaTime;
        } else
        {
            AlienDestructionThreat();
        }
    }

    public void AlienDestructionThreat()
    {
        PlayThreat();
        ResetThreatTimer();
    }

    public void ResetThreatTimer()
    {
        timer = 0f;
    }


    private void PlayLaugh()
    {
        AlienLaugh?.Invoke();
    }

    private void PlayThreat()
    {
        AlienThreat?.Invoke();
    }

}
