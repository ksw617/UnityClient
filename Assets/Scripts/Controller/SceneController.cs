using UnityEngine.SceneManagement;
public enum SceneName
{
    MainMenu,
    LoginScene,
    LobbyScene,
    GameScene
}
public class SceneController
{
 

    // �ε� �� �� ��� �� ��ȯ (�񵿱� �ε�)
    public void LoadScene(SceneName scene)
    {
        SceneManager.LoadScene(GetSceneName(scene));
    }

    string GetSceneName(SceneName scene)
    {
        string name = System.Enum.GetName(typeof(SceneName), scene);
        return name;
    }
}
