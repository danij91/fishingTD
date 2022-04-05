using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class View_InGame : View {
    [SerializeField]
    private Button mButtonBack;
    [SerializeField]
    private Draggable[] mFisherButtons;

    [SerializeField]
    private Text m_labelScore;
    public Button buttonBack => mButtonBack;
    public Draggable[] fisherButtons => mFisherButtons;

    public void UpdateScore(int score) {
        m_labelScore.text = score.ToString();
    }
}
