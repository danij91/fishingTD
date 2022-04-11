using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Fisher : MonoBehaviour {
    [SerializeField]
    private Transform stick;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float range;
    [SerializeField]
    private float attackTerm;
    
    private float elapsedTime;
    private bool isPlaying;
    private Fish targetFish;
    private Vector3 orgStickRotation;
    private float swingAngle = 60f;
   

    private void Start() {
        orgStickRotation = stick.localEulerAngles;
    }

    private void Update() {
        if (isPlaying) {
            SelectFish();
            if (targetFish)
                LookTarget();

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= attackTerm) {
                Attack();
                elapsedTime = 0;
            }
        }
    }

    private void SelectFish() {
        Collider[] colls = Physics.OverlapSphere(transform.position, range);
        var fishes = new List<Fish>();
        Fish tempFish;
        foreach (var coll in colls) {
            tempFish = coll.GetComponent<Fish>();

            if (tempFish) {
                fishes.Add(tempFish);
            }
        }

        if (fishes.Contains(targetFish) || fishes.Count == 0) {
            return;
        }

        var isFirst = true;
        float minDist = 0;
        float currentDist = 0;
        tempFish = fishes[0];
        foreach (var fish in fishes) {
            currentDist = Vector3.Distance(transform.position, fish.transform.position);
            if (minDist > currentDist || isFirst) {
                minDist = currentDist;
                tempFish = fish;
                isFirst = false;
            }
        }

        targetFish = tempFish;
    }

    private void Attack() {
        if (!targetFish) {
            return;
        }
        SwingStick().Forget();
        targetFish.Attacked(damage);
    }

    private void LookTarget() {
        var direction = targetFish.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        var quaternion = Quaternion.LookRotation(direction);

        transform.rotation = quaternion;
    }

    private async UniTaskVoid SwingStick() {
        for (int i = 0; i < 10; i++) {
            stick.localEulerAngles += Vector3.right * swingAngle / 10f;
            await UniTask.Delay(10);
        }
        
        await UniTask.Delay(100);
        stick.localEulerAngles = orgStickRotation;
    }

    public void StartFishing() {
        isPlaying = true;
    }
}
