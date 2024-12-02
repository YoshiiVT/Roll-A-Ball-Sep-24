using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Will change our scene to the string passed in
    public void Changescene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void TutorialScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        GameController.instance.controlType = ControlType.Normal;
    }

    // Reloads the current scene we are in
    public void Reloadscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Loads out Title scene. Must be called Title exactly
    public void ToTitleScene()
    {
        GameController.instance.controlType = ControlType.Normal;
        SceneManager.LoadScene("Title");
    }
    // Gets out active scenes name
    public string GetsceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    //Quits out game
    public void QuitGame()
    {
        Application.Quit();
    }
}
