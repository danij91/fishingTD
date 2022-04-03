using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    [SerializeField]
    private List<Transform> waypoints;
    [SerializeField]
    private Transform startPoint;

    public List<Transform> Waypoints => waypoints;
    public Transform StartPoint => startPoint;
}


