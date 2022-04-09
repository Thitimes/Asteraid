using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
   public void PlayerDie()
    {
        SceneManager.LoadScene("Lose");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Test");
    }
    public void Playerwin()
    {
        SceneManager.LoadScene("Win");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
