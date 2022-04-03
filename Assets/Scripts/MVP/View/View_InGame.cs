using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_InGame : View {
    [SerializeField]
    private Button mButtonBack;
    [SerializeField]
    private Text m_labelScore;
    public Button buttonBack => mButtonBack;
    
    public void UpdateScore(int score) {
        m_labelScore.text = score.ToString();
    }
}
