using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] sceneToLoad;

    public void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad[0]);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(sceneToLoad[1]);
    }

    public void LoadWin()
    {
        StartCoroutine(WinWait());        
    }

    public void LoadLose()
    {
        SceneManager.LoadScene(sceneToLoad[1]);
    }

    IEnumerator WinWait()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(sceneToLoad[0]);
    }
}
