using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForwardAlert : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI alert;

    private void Awake() {
        alert.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) alert.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) alert.enabled = false;
    }

}
