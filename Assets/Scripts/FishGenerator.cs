using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour {
    public Fish fishPrefab { get; set; }
    public Map map { get; set; }
    public Action<int> OnFishDead { get; set; }

    private bool isPlaying;
    private float genTerm = 1f;
    private float elapsedTime;
    private int fishCount = 400;

    private void Update() {
        if (isPlaying) {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= genTerm) {
                CreateFish();
                elapsedTime = 0;
            }
        }
    }

    public void Play() {
        isPlaying = true;
    }
    
    private void CreateFish() {
        var newFish = Instantiate(fishPrefab, transform);
        newFish.gameObject.SetActive(true);
        newFish.map = map;
        newFish.OnFishDead = OnFishDead;
        
        fishCount--;
        
        if (fishCount == 0) {
            isPlaying = false;
        }
        
    }
}
