using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameInitializer : MonoBehaviour {
    [SerializeField]
    private Map mapPrefab;
    [SerializeField]
    private Fisher fisherPrefab;
    [SerializeField]
    private Fish fishPrefab;

    void Start() {
        var inGameUI = UIManager.Instance.LoadUI(UIManager.UI.IN_GAME);
        var viewInGame = inGameUI.GetComponent<View_InGame>();
        var presenterInGame = new Presenter_InGame(new Model_InGame(), viewInGame);
        presenterInGame.Initialize();

        GameObject factoryObj = new GameObject("Factories");
        var map = Instantiate(mapPrefab);
        var fisherFactory = factoryObj.AddComponent<FisherFactory>();
        var fishGenerator = factoryObj.AddComponent<FishGenerator>();
        
        map.fisherFactory = fisherFactory;
        fishGenerator.OnFishDead = presenterInGame.AddScore;
        fishGenerator.map = map;
        fishGenerator.fishPrefab = fishPrefab;
        fisherFactory.fisherPrefab = fisherPrefab;
        
        fishGenerator.Play();
    }
}
