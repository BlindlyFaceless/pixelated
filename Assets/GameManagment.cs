//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    bool gameHasEnded = false;
    bool restartable = false;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Awake()
    {
        GameOver.SetActive(false);  
    }

    private void Update()
    {
        if (restartable == true && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Game is exiting");
        }
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            
            gameHasEnded = true;
            restartable = true;
            Debug.Log("GAME OVER");
            GameOver.SetActive(true);

        }
    }

  /* public void Restart()
    {
        if (restartable == true && Input.GetKeyDown(KeyCode.G))         
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    */
}
