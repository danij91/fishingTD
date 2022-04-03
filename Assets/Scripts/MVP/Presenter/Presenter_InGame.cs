using UnityEngine.SceneManagement;
using UniRx;


public class Presenter_InGame : Presenter
{
    private Model_InGame modelInGame;
    private View_InGame viewInGame;

    public Presenter_InGame(Model_InGame modelInGame, View_InGame viewInGame) {
        this.modelInGame = modelInGame;
        this.viewInGame = viewInGame;
    }
    
    public override void Initialize() {
        modelInGame.score.Subscribe(viewInGame.UpdateScore);
        viewInGame.buttonBack.onClick.AddListener(EndGame);
        modelInGame.Initialize();
    }

    private void EndGame() {
        modelInGame.SaveScore();
        SceneManager.LoadScene("Lobby");
    }
}
