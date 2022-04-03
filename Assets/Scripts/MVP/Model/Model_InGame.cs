using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Model_InGame : Model {
    public ReactiveProperty<int> score;

    public Model_InGame() {
        score = new ReactiveProperty<int>(0);
    }

    public void SaveScore() {
        var totalScore = PlayerPrefs.GetInt("totalScore", 0);
        PlayerPrefs.SetInt("totalScore", totalScore + score.Value);
    }
}
