using UniRx;
using UnityEngine.SceneManagement;

public class Presenter_Lobby : Presenter {
    private Model_Lobby modelLobby;
    private View_Lobby viewLobby;

    public Presenter_Lobby(Model_Lobby modelLobby, View_Lobby viewLobby) {
        this.modelLobby = modelLobby;
        this.viewLobby = viewLobby;
    }
    
    public override void Initialize() {
        modelLobby.score.Subscribe(viewLobby.UpdateScore);
        viewLobby.buttonStart.onClick.AddListener(StartGame);
        modelLobby.Initialize();
    }

    private void StartGame() {
        SceneManager.LoadScene("InGame");
    }
}
