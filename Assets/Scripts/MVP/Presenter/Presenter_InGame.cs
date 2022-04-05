using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;
using UnityEngine;


public class Presenter_InGame : Presenter {
    private Model_InGame modelInGame;
    private View_InGame viewInGame;

    public Presenter_InGame(Model_InGame modelInGame, View_InGame viewInGame) {
        this.modelInGame = modelInGame;
        this.viewInGame = viewInGame;
    }

    public override void Initialize() {
        modelInGame.score.Subscribe(viewInGame.UpdateScore);
        viewInGame.buttonBack.onClick.AddListener(EndGame);
        viewInGame.fisherButtons[0].onBeginDrag.AddListener(() => BeginDrag(0));
        viewInGame.fisherButtons[1].onBeginDrag.AddListener(() => BeginDrag(1));
        viewInGame.fisherButtons[2].onBeginDrag.AddListener(() => BeginDrag(2));
        viewInGame.fisherButtons[3].onBeginDrag.AddListener(() => BeginDrag(3));

        viewInGame.fisherButtons[0].onEndDrag.AddListener(() => EndDrag(0));
        viewInGame.fisherButtons[1].onEndDrag.AddListener(() => EndDrag(1));
        viewInGame.fisherButtons[2].onEndDrag.AddListener(() => EndDrag(2));
        viewInGame.fisherButtons[3].onEndDrag.AddListener(() => EndDrag(3));
        modelInGame.Initialize();
    }

    public void AddScore(int score) {
        modelInGame.score.Value += score;
    }

    private void EndGame() {
        modelInGame.SaveScore();
        SceneManager.LoadScene("Lobby");
    }

    private void BeginDrag(int index) {
        Debug.Log(index + " begin drag");
    }

    private void EndDrag(int index) {
        Debug.Log(index + " end drag");
    }
}
