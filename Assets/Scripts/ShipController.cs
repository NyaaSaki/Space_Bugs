using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class ShipController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector2 rawInput;
    Vector3 delta;
    [SerializeField] float moveScale = 0.2f;
    [SerializeField] GameObject bulletPrefab;
    public float FireCooldown = 0.5f;

    bool dying = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireCooldown -= Time.deltaTime;
        if(FireCooldown < 0) {
            Instantiate(bulletPrefab,transform.position,Quaternion.identity);
            GetComponent<AudioSource>().Play();
            FireCooldown = 0.4f;
        }
        UpdateMove();
        if(dying){
            if(Time.timeScale > 0.05f) Time.timeScale = Time.timeScale * 0.975f;
        }
    }



    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
        //GetComponent<Rigidbody2D>().velocity = rawInput * 5;
    }

    void UpdateMove(){
        delta = rawInput; 
        GetComponent<Rigidbody2D>().velocity = delta * moveScale;
    }

    void OnFire(){
        Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        GetComponent<AudioSource>().Play();
    }



    IEnumerator reset(){
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneBuildIndex:0);
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("enemy")) {
            StartCoroutine("reset");
            dying = true;
            GetComponent<SpriteRenderer>().color = new Color(1,0.2f,0.2f,0.4f);
        }
    }
}
