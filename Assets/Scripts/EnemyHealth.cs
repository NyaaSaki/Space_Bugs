using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int HitsToKill;
    int currentHits = 0;

    [SerializeField] int ScoreOnKill;
    [SerializeField] GameObject popUp;

    Color org;

    void Start()
    {
        org = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void killObject(){
        
        Destroy(gameObject);
    }

    void returnColor(){
        GetComponent<SpriteRenderer>().color = org;
    }

    void ThrowText(string score){
        GameObject txttmp = Instantiate(popUp,
                transform.position,
                Quaternion.identity,
                transform) as GameObject;
        txttmp.GetComponent<TextMeshPro>().text = score;
    }

    public void OnHit(){
        currentHits ++;
        if(currentHits >= HitsToKill){
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<Animator>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            GetComponent<AudioSource>().Play();

            float timeScore = (2 + (10 - GetComponent<PathFinder>().wpIndex))*0.7f;
            int diveScore = GetComponent<PathFinder>().IsDiving?2:1;
            int tmpScore = (Mathf.CeilToInt(ScoreOnKill * timeScore*diveScore * (1+FindObjectOfType<Spawner>().waveIndex*0.2f)));
            FindObjectOfType<Spawner>().Score +=tmpScore;
            ThrowText(tmpScore.ToString());
            Invoke("killObject",0.5f);

           
            
        }
        else{
            GetComponent<SpriteRenderer>().color = new Color(0,0,0,0.3f);
            Invoke("returnColor",0.05f);
        }
        
    }
}
