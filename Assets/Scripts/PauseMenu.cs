using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool pause = false;
    public GameObject PauseMENU;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("tessssssssssssssssssssssssssssssssssssssssss");
        PauseMENU.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("tessssssssssssssssssssssssssssssssssssssssss");
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Debug.Log("tessssssssssssssssssssssssssssssssssssssssss");
            Debug.Log("tessssssssssssssssssssssssssssssssssssssssss");
            pause = !pause;

        }
        if (pause)
        {
            PauseMENU.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseMENU.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void resume()
    {
        pause = false;
    }
    public void quit()
    {
        Debug.Log("A");
        Application.Quit();
    }
}
