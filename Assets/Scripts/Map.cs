using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public FisherFactory fisherFactory { get; set; }
    [SerializeField]
    private List<Transform> waypoints;
    [SerializeField]
    private Transform startPoint;

    public List<Transform> Waypoints => waypoints;
    public Transform StartPoint => startPoint;

    private void Start() {
        var tiles = GetComponentsInChildren<Tile>();

        foreach (var tile in tiles) {
            tile.fisherFactory = fisherFactory;
        }
    }
}
