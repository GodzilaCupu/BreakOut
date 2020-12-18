using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Uiimanager : MonoBehaviour
{
    #region MainMenu
    public void playIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region MainMenu
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="Intro")
        {
            float t = Time.deltaTime;
            if (2 < t)
            {
                SceneManager.LoadScene("Level 1");
            }
        }
    }
}
