using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class ExtensionMethod
{
    public static Object Instantiate(this Object thisObj, Object original, Vector3 position, Quaternion rotation, Transform parent, string message)
    {
        GameObject timeBox = Object.Instantiate(original, position, rotation, parent) as GameObject;
        TextMeshPro scr = timeBox.GetComponent<TextMeshPro>();
        scr.text =message;
        return timeBox;
    }
}


public class PopUpScore : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
