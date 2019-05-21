using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool pause = false;
    public GameObject PauseMENU;
    public GameObject WinMenu;
    public GameObject LoseMenu;
    // Start is called before the first frame update
    void Start() { 
        PauseMENU.SetActive(false);
        WinMenu.SetActive(false);
        LoseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
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

        if (GlobalManager.countSquired > 2)
        {
            LoseMenu.SetActive(true);
            Time.timeScale = 0;

        }
        
        if(GlobalManager.countDollBurned == 5)
        {
            WinMenu.SetActive(true);
            Time.timeScale = 0;
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

    public void restart()
    {
        WinMenu.SetActive(false);
        LoseMenu.SetActive(false);

        Debug.Log("Nhấp restart");
        SceneManager.LoadScene(12);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(5.82f, player.transform.position.y, player.transform.position.z);
        Inventory inventory = player.GetComponent<Inventory>();
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            string name = "Slot (" + i + ")";
            inventory.slots[i].GetComponent<Image>().sprite = GameObject.Find("Slot Empty").GetComponent<SpriteRenderer>().sprite;
            inventory.isFull[i] = false;
        }

        GlobalManager.playerPosition = 0;
        GlobalManager.countDollBurned = 0;
        GlobalManager.countSquired = 0;

        GlobalManager.firstGoTo = new Dictionary<int, bool>();
        GlobalManager.firstGoTo[2] = true;// front 3
        //firstGoTo[3] = true;// side 3
        //firstGoTo[4] = true;// toilet 3

        GlobalManager.lastSpawned = false;
        GlobalManager.firstMeetEnemy = false;
        GlobalManager.meetPlayer = false;

        GlobalManager.isPickuped = new Dictionary<string, bool>();

        GlobalManager.isPickuped["keywhite"] = false;
        GlobalManager.isPickuped["keyred"] = false;
        GlobalManager.isPickuped["keyyellow"] = false;

        GlobalManager.isPickuped["bandage01"] = false;
        GlobalManager.isPickuped["bandage02"] = false;
        GlobalManager.isPickuped["bandage03"] = false;
        GlobalManager.isPickuped["bandage04"] = false;
        GlobalManager.isPickuped["bandage05"] = false;
        GlobalManager.isPickuped["bandage06"] = false;
        GlobalManager.isPickuped["bandage07"] = false;
        GlobalManager.isPickuped["bandage08"] = false;

        GlobalManager.isPickuped["flashlight"] = false;

        GlobalManager.isPickuped["doll01"] = false;
        GlobalManager.isPickuped["doll02"] = true;
        GlobalManager.isPickuped["doll03"] = true;
        GlobalManager.isPickuped["doll04"] = true;
        GlobalManager.isPickuped["doll05"] = true;

        GlobalManager.isPickuped["match"] = false;
        GlobalManager.isPickuped["umbrella"] = false;
        GlobalManager.isPickuped["cutter"] = false;
        GlobalManager.isPickuped["crowbar"] = false;
        GlobalManager.isPickuped["hammer"] = false;

        GlobalManager.isSolved = new Dictionary<string, bool>();

        GlobalManager.isSolved["keywhite_puzzle"] = false;
        GlobalManager.isSolved["keyred_puzzle"] = false;
        GlobalManager.isSolved["keyyellow_puzzle"] = false;

        GlobalManager.isSolved["crowbar_puzzle"] = false;
        GlobalManager.isSolved["fire_puzzle"] = false;
        GlobalManager.isSolved["fan_puzzle"] = false;
        GlobalManager.isSolved["stair_puzzle"] = false;
        GlobalManager.isSolved["hammer_puzzle"] = false;

        GlobalManager.isSolved["doll01_puzzle"] = false;
        GlobalManager.isSolved["doll02_puzzle"] = false;
        GlobalManager.isSolved["doll03_puzzle"] = false;
        GlobalManager.isSolved["doll04_puzzle"] = false;
        GlobalManager.isSolved["doll05_puzzle"] = false;
    }
}
