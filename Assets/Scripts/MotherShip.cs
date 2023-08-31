using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject child;
    void Start()
    {
        spawn();
    }

    void spawned(){
        Invoke("spawn",5f);
    }

    void spawn(){
        Instantiate(child,
                transform.position,
                Quaternion.identity,
                transform);
        spawned();
        
                }
    // Update is called once per frame
    void Update()
    {
        
    }
}
