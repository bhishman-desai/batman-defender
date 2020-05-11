using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public void LoadStartMenu()
    {
        
        SceneManager.LoadScene(0);

    }

    public void LoadGame()
    {
       // FindObjectOfType<Score>().ResetScore();
        SceneManager.LoadScene(1);

    }

    public void GameOver()
    {
        StartCoroutine(WaitAndLoad());
        //SceneManager.LoadScene(2);

    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
