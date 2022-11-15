using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

  public void PlayGame ()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  public void Meneu()
    {
        SceneManager.LoadScene("CreditScene", LoadSceneMode.Single);
    }
    public void Credit()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit()
            ;
    }
    

}
