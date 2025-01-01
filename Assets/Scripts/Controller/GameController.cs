using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    static GameController instance; // ���ϼ��� ����ȴ�
    public static GameController Instance { get { Init(); return instance; } } // ������ �Ŵ����� ����´�

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

    public IEnumerator SomeCoroutine(string sceneName)
    {
        Debug.Log($"Trying to load scene: {sceneName}");

        // �� ���� ���� �� �ε��� Ȯ��
        SceneManager.LoadScene(sceneName);
       
        // �ڷ�ƾ ����
        yield return null;
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
