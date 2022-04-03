using UnityEngine;

public class Singleton<T> where T : class, new() {
    private static T instance = null;
    public static T Instance {
        get {
            if (instance == null) {
                instance = new T();
            }

            return instance;
        }
    }
}

//모노를 사용하는 싱글톤
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour {
    private static T instance = null;
    public static T Instance {
        get {
            if (instance == null) {
                instance = (T) FindObjectOfType(typeof(T));
            }

            if (instance != null) return instance;

            var obj = new GameObject();
            obj.name = typeof(T).ToString();
            instance = obj.AddComponent<T>();

            var manager = GameObject.Find("SingletonManager");
            if (manager == null) {
                manager = new GameObject("SingletonManager");
                manager.transform.SetAsFirstSibling();
            }

            DontDestroyOnLoad(manager);
            instance.transform.SetParent(manager.transform);

            return instance;
        }
    }

    protected bool isAlreadyInitialized = false;
}
