using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{
    MainMenu,
    Main
}

public class LevelManager : MonoBehaviour
{
    private AudioTransitions Effects = null;

    // Start is called before the first frame update
    void Start()
    {
        Effects = FindFirstObjectByType<AudioTransitions>();
        Effects.SecondsToFade = 2.0f;
        Effects.CrossFade("Tense Theme");
    }

    public void GameStart()
    {
        SceneManager.LoadScene(Scenes.Main.ToString());
    }
}
