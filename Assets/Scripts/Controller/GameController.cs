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

    public void Debug(string msg)
    {
        UnityEngine.Debug.Log(msg);
        SceneManager.LoadScene("LobbyScene");
    }
}
