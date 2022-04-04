using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMono<UIManager> {
    public enum UI {
        LOBBY,
        IN_GAME,
    }

    private Dictionary<UI, string> views = new Dictionary<UI, string>() {
        {UI.LOBBY, "UI/Lobby"},
        {UI.IN_GAME, "UI/InGame"}
    };

    public GameObject LoadUI(UI uiEnum) {
        var ui = Resources.Load<GameObject>(views[uiEnum]);
        return Instantiate(ui);
    }
}
