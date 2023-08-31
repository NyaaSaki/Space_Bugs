using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-15,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void kill(){
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("enemy")){
            GetComponent<AudioSource>().Play();
            other.GetComponent<EnemyHealth>().OnHit();
            Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Invoke("kill",0.3f);
            
        }

        else if(other.CompareTag("SkyBox")){
            Destroy(gameObject);
            
        }
    }
}
