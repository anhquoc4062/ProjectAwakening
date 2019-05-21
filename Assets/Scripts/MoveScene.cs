using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public GetLeftRightPosition pos;
    // Start GlobalManager.is called before the first frame update
    void Start()
    {
        //pos = GameObject.Find("GetLeftRightPosition").GetComponent<GetLeftRightPosition>();
    }

    // Update GlobalManager.is called once per frame
    public void GoToMainGame()
    {
        SceneManager.LoadScene(12);
    }
    public void Restart()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SceneManager.LoadScene(9);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(10);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(11);
        }
    }
    public void QUIT_GAME()
    {
        Debug.Log("Exit Success");
        Application.Quit();
    }
}
