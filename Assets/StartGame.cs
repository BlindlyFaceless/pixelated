using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject scrollTxt;
    public bool SeenTxt = false;
   void Awake()
    {
        scrollTxt.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && SeenTxt == true)
        {
            SceneManager.LoadScene("Gamelvl");
        }

        if (Input.GetKeyDown(KeyCode.Space) && SeenTxt == false)
        {
            SeenTxt = true;
            scrollTxt.SetActive(true);
        }
    }
}
