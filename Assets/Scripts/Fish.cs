using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {
    public Transform startPosition;
    public List<Transform> waypoints;
    
    private int waypointIndex;
    private float speed = 5f;
    private Vector3 currentPosition;
    private bool isMoving;
    private MaterialFlash materialFlash;
    private float health = 40;

    private void Start() {
        transform.position = startPosition.position;
        isMoving = true;
        transform.LookAt(waypoints[waypointIndex].position);
        materialFlash = GetComponent<MaterialFlash>();
    }

    private void Update() {
        if (!isMoving) return;
        
        currentPosition = transform.position;

        if (waypointIndex < waypoints.Count) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPosition, waypoints[waypointIndex].position, step);

            if (Vector3.Distance(waypoints[waypointIndex].position, currentPosition) == 0f) {
                waypointIndex++;
                if(waypointIndex < waypoints.Count)
                    transform.LookAt(waypoints[waypointIndex].position);
            }
        }
        else {
            Stop();
        }
    }

    private void Stop() {
        isMoving = false;
        Destroy(gameObject);
    }

    public void Attacked(float damage = 0) {
        materialFlash.Flash();
        health -= damage;
        if (health <=- 0) {
            Death();
        }
    }

    private void Death() {
        Invoke("Stop",0.5f);
    }
}
