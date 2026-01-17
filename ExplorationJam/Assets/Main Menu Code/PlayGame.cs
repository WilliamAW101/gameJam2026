using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    public GameObject play;
    public GameObject quit;
    
    void Start()
    {
        play.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }

  
    public void PlayLevel()
    {
        SceneManager.LoadScene("Camera Screen");
    }

    public void Esc()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Hello");
        }
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Nobody");
    }
}
