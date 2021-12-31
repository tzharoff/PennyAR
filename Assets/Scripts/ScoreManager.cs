using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
#region singleton
    public static ScoreManager instance;

    private void Awake(){
        instance = this;
    }
#endregion singleton

    [SerializeField] private TMP_Text tmpScore;
    [SerializeField] private TMP_Text tmpScoreOutline;

    private int score;

    private int Score {
        get { return score;}
        set {score = value;
            tmpScore.text = $"{score}";
            tmpScoreOutline.text = $"{score}";
        }
    }
    
    private void OnEnable(){
        Planet.ExplosionCaller += AddScore;
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }

    private void OnDisable(){
        Planet.ExplosionCaller -= AddScore;
    }

    public void AddScore(){
        Score++;
    }

    public int GetScore {
        get {return score;}
    }
}
