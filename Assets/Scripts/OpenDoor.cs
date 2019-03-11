using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public int scene;
    public bool isLocked;
    public Animator openAnim;
    public AudioSource openSound;
    public AudioSource lockedSound;

    public Player player;
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        openAnim = gameObject.GetComponent<Animator>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isLocked)
            {
                StartCoroutine(openDoor());
            }
            else
            {
                lockedSound.Play();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isLocked)
            {
                StartCoroutine(openDoor());
            }
            else
            {
                lockedSound.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
    }

    IEnumerator openDoor()
    {
        openSound.Play();
        openAnim.Play("Door Open");
        yield return new WaitForSeconds(0.5f);

        string jsonInventoryFull = JsonUtility.ToJson(inventory.isFull);
        PlayerPrefs.SetString("InventoryFull", jsonInventoryFull);
        SceneManager.LoadScene(scene);
    }
}
