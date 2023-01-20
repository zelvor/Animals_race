using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    void Awake(){
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }    

    public IEnumerable<Score> GetScores(){
        return sd.scores.OrderByDescending(s => s.score);
    }

    public void AddScore(Score score){
        sd.scores.Add(score);
    }
    
    private void OnDestory(){
        SaveScore();
    }

    public void SaveScore(){
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);
    }
}
