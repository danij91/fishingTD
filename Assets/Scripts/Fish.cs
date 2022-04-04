using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {
    public Action<int> OnFishDead { get; set; }
    public Map map { get; set; }
    private int waypointIndex;
    private float speed = 5f;
    private Vector3 currentPosition;
    private bool isMoving;
    private MaterialFlash materialFlash;
    private float health = 40;
    private int score = 30;

    private void Start() {
        transform.position = map.StartPoint.position;
        isMoving = true;
        transform.LookAt(map.Waypoints[waypointIndex].position);
        materialFlash = GetComponent<MaterialFlash>();
    }

    private void Update() {
        if (!isMoving) return;

        currentPosition = transform.position;

        if (waypointIndex < map.Waypoints.Count) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(currentPosition, map.Waypoints[waypointIndex].position, step);

            if (Vector3.Distance(map.Waypoints[waypointIndex].position, currentPosition) == 0f) {
                waypointIndex++;
                if (waypointIndex < map.Waypoints.Count)
                    transform.LookAt(map.Waypoints[waypointIndex].position);
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
        if (health <= -0) {
            Death();
        }
    }

    private void Death() {
        Invoke("Stop", 0.5f);
        OnFishDead?.Invoke(score);
    }
}
