using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject path1;
    public GameObject path2;
    public GameObject path3;


    public GameObject walleft;
    public GameObject wallright;

    void SetLeftRightPosition(int indexScene)
    {

        walleft = GameObject.FindGameObjectWithTag("wallLeft");

        wallright = GameObject.FindGameObjectWithTag("wallRight");
        if (indexScene == 5 || indexScene == 4)
        {
            enemy.GetComponent<FlatformFollowPath>().thepath.listPoints[0].position = new Vector3(walleft.transform.position.x, -1.5f, 0);

            enemy.GetComponent<FlatformFollowPath>().thepath.listPoints[1].position = new Vector3(wallright.transform.position.x, -1.5f, 0);
        }
        else
        {
            enemy.GetComponent<FlatformFollowPath>().thepath.listPoints[0].position = new Vector3(walleft.transform.position.x, -2f, 0);

            enemy.GetComponent<FlatformFollowPath>().thepath.listPoints[1].position = new Vector3(wallright.transform.position.x, -2f, 0);
        }
    }
    void Awake()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SetLeftRightPosition(indexScene);

        if (enemy.active == true)
        {
            enemy.SetActive(false);
        }
    }
    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {

        //spaw vi tri player
        player.transform.position = new Vector3(GlobalManager.playerPosition, player.transform.position.y, 0);


        int indexScene = SceneManager.GetActiveScene().buildIndex;

        SetLeftRightPosition(indexScene);
        // do whatever you like
        
        float path1Loc = path1.transform.position.x;
        float path2Loc = path2.transform.position.x;
        float path3Loc = path3.transform.position.x;
        float enemyStartLocation = (Mathf.Abs(path3Loc - path1Loc) > Mathf.Abs(path3Loc - path2Loc)) ? path1Loc : path2Loc;
        Debug.Log("Vị trí enemy: " + enemyStartLocation);
        //reset vi tri enemy
        enemy.transform.position = new Vector3(enemyStartLocation, player.transform.position.y, enemy.transform.position.z);
        enemy.GetComponent<Enemy>().meet = false;
        enemy.GetComponent<FlatformFollowPath>().speed = 1f;

        if (enemy.active == true)
        {
            enemy.SetActive(false);
        }
        Debug.Log("số index là " + indexScene);
        if (indexScene == 2 || indexScene == 5 || indexScene == 4)
        {
            int value = Random.Range(1, 3);
            Debug.Log("số random là " + value);
            if (value == 1)
            {

                enemy.SetActive(true);
            }
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
