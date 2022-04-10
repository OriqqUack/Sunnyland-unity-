using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void SceneNext()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SceneMain()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void SceneRetry()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
}
