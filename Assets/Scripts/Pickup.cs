using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public static bool isPickuped = false;
    private Inventory inventory;
    public GameObject item;
    public string[] textPickup;
    private Player player;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        /*if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {


                if (index > textPickup.Length - 1)
                {
                    //player.r2.isKinematic = true;
                    player.charText.text = "";
                    //Add item to inventory
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (inventory.isFull[i] == false)
                        {
                            inventory.isFull[i] = true;
                            if (Input.GetKey(KeyCode.Space))
                            {
                                this.GetComponent<BoxCollider2D>().enabled = false;
                                this.transform.localScale = new Vector3(8, 8, 0);
                                this.GetComponent<SpriteRenderer>().enabled = true;
                                Instantiate(item, inventory.slots[i].transform);
                                this.transform.position = new Vector2(0, 0);
                                Destroy(gameObject);
                            }

                            break;
                        }
                    }
                }
                else if (index <= textPickup.Length - 1)
                {
                    //player.r2.isKinematic = false;
                    player.charText.text = textPickup[index];
                    index++;
                }

            }
        }*/
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(index);
                if(index > textPickup.Length - 1)
                {
                    //player.r2.isKinematic = true;
                    player.charText.text = "";
                    //Add item to inventory
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (inventory.isFull[i] == false)
                        {
                            inventory.isFull[i] = true;
                            if (Input.GetKey(KeyCode.Space))
                            {
                                this.GetComponent<BoxCollider2D>().enabled = false;
                                //this.transform.localScale = new Vector3(8, 8, 0);
                                //this.GetComponent<SpriteRenderer>().enabled = true;
                                //Instantiate(item, inventory.slots[i].transform);
                                this.transform.position = new Vector2(0, 0);
                                inventory.slots[i].name = item.name;
                                inventory.slots[i].GetComponent<Image>().sprite = this.GetComponent<SpriteRenderer>().sprite;
                                Destroy(gameObject);
                            }

                            break;
                        }
                    }
                    index = 0;
                }
                else if(index <= textPickup.Length - 1)
                {
                    //player.r2.isKinematic = false;
                    player.charText.text = textPickup[index];
                    index++;
                }
                
            }
        }
    }
}
