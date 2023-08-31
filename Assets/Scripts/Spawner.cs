using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<WaveConfigSO> Waves;
    [SerializeField] public int waveIndex=0;
    WaveConfigSO CurrentWave;

    [SerializeField] public int Score;

    [SerializeField]  TextMeshProUGUI ScoreText;
    [SerializeField]  TextMeshProUGUI WaveText;
    void Start()
    {  
        CurrentWave = Waves[0];
        StartCoroutine("Spawn",CurrentWave.interval);
        
    }

    void Update(){
        ScoreText.text = "Score: " + Score;
        WaveText.text = "Wave " + waveIndex;
    }

    void waveComplete(){

        if(waveIndex <= Waves.Count){
            waveIndex++;
            CurrentWave = Waves[waveIndex];
            StartCoroutine("Spawn",CurrentWave.interval);
            Time.timeScale = Time.timeScale * 1.005f;
        }
        else {
            waveIndex = 0;
            StartCoroutine("Spawn",3f);
        }
    }

    public WaveConfigSO getWave(){
        return Waves[waveIndex];
    }


    IEnumerator Spawn(){
        for(int i = 0; i< CurrentWave.EnemyCount();i++){        
            Instantiate(CurrentWave.GetEnemy(i),
                CurrentWave.GetEnemy(i).GetComponent<PathFinder>().pathCFG.getStart().position,
                Quaternion.identity,
                transform);
                yield return new WaitForSeconds(1f);
                }
        Invoke("waveComplete",3f);
    }


}
