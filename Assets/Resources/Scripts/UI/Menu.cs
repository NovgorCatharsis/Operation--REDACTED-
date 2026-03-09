using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;
    private Button startButton;
    private Button exitButton;

    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;
        startButton = root.Q<Button>("startButton");
        exitButton = root.Q<Button>("exitButton");

        startButton.clickable.clicked += StartGame;
        exitButton.clickable.clicked += ExitGame;

        //if (gameObject.name == "Ending") uiDocument.enabled = false;
    }

    private void OnEnable()
    {
        GameObject.Find("DroneAudio").GetComponent<AudioSource>().enabled = false;
    }
    private void StartGame()
    {
        //Debug.Log("Start button clicked");
        uiDocument.enabled = false;
        GameObject.Find("DroneAudio").GetComponent<AudioSource>().enabled = true;
        //if (gameObject.name == "Ending") SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitGame()
    {
        //Debug.Log("Exit button clicked");
        Application.Quit();
    }

    //public IEnumerator sceneLoad()
    //{
    //    gameObject.SetActive(false);
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Single);
    //    while (!asyncLoad.isDone)
    //    {
    //        yield return null;
    //    }
    //}
}
