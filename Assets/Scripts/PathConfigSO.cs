using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Path Config" , fileName = "NewPath")]
public class PathConfigSO : ScriptableObject

{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float MoveSpeed;
    
    public float GetSpeed(){
        return MoveSpeed;
    }

    public Transform getStart(){
        return pathPrefab.GetChild(0);
    }

    public List<Transform> getPath(){
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab) waypoints.Add(child);
        return waypoints; 
    }
}
