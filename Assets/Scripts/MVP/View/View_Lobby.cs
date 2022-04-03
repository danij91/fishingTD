using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Lobby : View {
    [SerializeField]
    private Button m_buttonStart;
    [SerializeField]
    private Text m_labelScore;
    public Button buttonStart => m_buttonStart;
    
    public void UpdateScore(int score) {
        m_labelScore.text = score.ToString();
    }
}
