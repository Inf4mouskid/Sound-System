using UnityEngine;
using UnityEngine.SceneManagement;

enum Scenes
{
    MainMenu,
    Main
}

public class LevelManager : MonoBehaviour
{
    private AudioTransitions Effects;

    // Start is called before the first frame update
    void Start()
    {
        Effects = FindObjectOfType<AudioTransitions>();
        Effects.SecondsToFade = 2.0f;
        Effects.CrossFade("Tense Theme");
    }

    public void GameStart()
    {
        SceneManager.LoadScene(Scenes.Main.ToString());
    }
}
