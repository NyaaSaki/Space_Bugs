using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Wave Config" , fileName = "NewWave")]
public class WaveConfigSO : ScriptableObject
{
    // Start is called before the first frame update

    [SerializeField] List<GameObject> enemyList;
    [SerializeField] public float interval = 1f;



    public int EnemyCount(){
        return enemyList.Count;
    }

    public GameObject GetEnemy(int index){
        return enemyList[index];
    }


}
