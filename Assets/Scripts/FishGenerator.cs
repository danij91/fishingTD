using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour {
    [SerializeField]
    private Fish fishPrefab;
    private bool isPlaying;
    private float genTerm = 1f;
    private float elapsedTime;
    private int fishCount = 400;

    private void Start() {
        isPlaying = true;
    }

    private void Update() {
        if (isPlaying) {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= genTerm) {
                CreateFish();
                elapsedTime = 0;
            }
        }
    }

    private void CreateFish() {
        var newFish = Instantiate(fishPrefab, transform);
        newFish.gameObject.SetActive(true);
        fishCount--;
        if (fishCount == 0) {
            isPlaying = false;
        }
    }
}
