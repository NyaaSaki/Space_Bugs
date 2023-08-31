using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PathFinder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public PathConfigSO pathCFG;
    List<Transform> path;
    [SerializeField] public int wpIndex = 0;

    [SerializeField] float diveChance;
    public bool IsDiving = false;
    bool HasTarget = false;
    Vector3 tgt;
    void Start()
    {
        path = pathCFG.getPath();
        transform.position = path[wpIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsDiving)   FollowPath();
        else FollowDive();
    }

    void FollowDive(){
        if(!HasTarget){
            tgt = FindObjectOfType<ShipController>().gameObject.transform.position + new Vector3(2,0);
            HasTarget = true;
        }
        else{
            float delta = 5 * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,tgt,delta);
            if((transform.position - tgt).magnitude < 1){
                IsDiving = false;
                HasTarget = false;
                wpIndex--;  
                GetComponent<Animator>().SetBool("Diving",false);
            }
        }
    }

    private void FollowPath()
    {

        if(wpIndex < path.Count){
            Vector3 tgt = path[wpIndex].position;
            float delta = pathCFG.GetSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,tgt,delta);
            if((transform.position - tgt).magnitude < 1){
                wpIndex++;  
            }
        }
        else Destroy(gameObject);

        if(UnityEngine.Random.value < diveChance && wpIndex > 2) {
            IsDiving = true;
            GetComponent<Animator>().SetBool("Diving",true);
        }
    }
}
