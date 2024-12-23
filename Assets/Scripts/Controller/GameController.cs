using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    static GameController instance; // 유일성이 보장된다
    public static GameController Instance { get { Init(); return instance; } } // 유일한 매니저를 갖고온다

    readonly NetworkController network = new ();
    readonly SceneController scene = new ();
    public static NetworkController Network { get { return Instance.network; } }
    public static SceneController Scene { get { return Instance.scene; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        network.Update();
    }

    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.FindWithTag("GameController");
            if (go == null)
            {
                go = new GameObject { name = "GameController" };
                go.tag = "GameController"; 
                go.AddComponent<GameController>();
            }

            DontDestroyOnLoad(go);
            instance = go.GetComponent<GameController>();

            instance.network.Init();
        }
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log($"Trying to load scene: {sceneName}");

        // 씬 존재 여부 및 인덱스 확인
        Scene scene = SceneManager.GetSceneByName(sceneName);
        Debug.Log($"LobbyScene index: {scene.buildIndex}");

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadSceneAsync(sceneName);
            Debug.Log($"{sceneName} loaded successfully.");
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' cannot be loaded. Check Build Settings or Scene Name.");
        }
    }

    public void LogMessage(string message)
    {
        Debug.Log(message);
    }

    public void LogError(string message)
    {
        Debug.LogError(message);
    }
}
