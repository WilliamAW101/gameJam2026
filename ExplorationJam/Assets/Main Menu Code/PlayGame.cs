using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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

    


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Nobody");
    }
}
