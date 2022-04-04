using UnityEngine;
using UnityEditor;

public class EditorMenus : MonoBehaviour  {
    public class CustomEditorMenus : MonoBehaviour {
        [MenuItem("Custom/Reset PlayerPrefab")]
        public static void ResetPlayerPrefab() {
            PlayerPrefs.DeleteAll();
        }
    }
}
