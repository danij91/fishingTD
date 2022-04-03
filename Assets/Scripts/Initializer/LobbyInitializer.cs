using UnityEngine;

namespace Initializer {
    public class LobbyInitializer : MonoBehaviour {
        void Start() {
            var lobbyUI = UIManager.Instance.LoadUI(UIManager.UI.LOBBY);
            var viewLobby = lobbyUI.GetComponent<View_Lobby>();
            var presenterLobby = new Presenter_Lobby(new Model_Lobby(), viewLobby);
            presenterLobby.Initialize();
        }
    }
}
