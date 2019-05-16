using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Awake()
    {
        if (enemy.active == true)
        {
            enemy.SetActive(false);
        }

        int indexScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("số index là " + indexScene);
        if (indexScene == 4 || indexScene == 5)
        {
            int value = Random.Range(1, 2);
            Debug.Log("số random là " + value);
            if (value == 1)
            {
                enemy.SetActive(true);
            }
        }
    }
    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("EnemyUI");

        if (enemy.active == true)
        {
            enemy.SetActive(false);
        }

        int indexScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("số index là " + indexScene);
        if (indexScene == 4 || indexScene == 5)
        {
            int value = Random.Range(1, 2);
            Debug.Log("số random là " + value);
            if (value == 1)
            {
                enemy.SetActive(true);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
