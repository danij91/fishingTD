using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Model_Lobby : Model {
    public ReactiveProperty<int> score;

    public Model_Lobby() {
        score = new ReactiveProperty<int>(0);
    }

    public override void Initialize() {
        score.Value = PlayerPrefs.GetInt("totalScore", 0);
    }
}
