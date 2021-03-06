﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    //public static bool isPickuped = false;
    private Inventory inventory;
    public GameObject item;
    public string[] textPickup;
    public AudioSource lootSound;
    private Player player;
    private int index = 0;
    public string keyName;
    //private GlobalManager globalClass;
    // Start is called before the first frame update
    void Awake()
    {
        if (GlobalManager.isPickuped[item.name] == false)
        {
            this.gameObject.SetActive(true);
            this.GetComponent<Pickup>().enabled = true;
        }
        else
        {

            this.gameObject.SetActive(false);
            this.GetComponent<Pickup>().enabled = true;
        }
        Debug.Log(GlobalManager.isPickuped[item.name] + "of item name " + item.name);
    }
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalManager.isPickuped[item.name] == false)
        {
            this.gameObject.SetActive(true);
            this.GetComponent<Pickup>().enabled = true;
        }
        else
        {

            this.gameObject.SetActive(false);
            this.GetComponent<Pickup>().enabled = true;
        }
        //Debug.Log(GlobalManager.isPickuped[item.name] + "of item name " + item.name);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
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
                                this.transform.position = new Vector2(0, 0);
                                inventory.slots[i].name = item.name;
                                inventory.slots[i].GetComponent<Image>().sprite = this.GetComponent<SpriteRenderer>().sprite;
                                inventory.slots[i].GetComponent<Image>().color = this.GetComponent<SpriteRenderer>().color;
                                inventory.slots[i].GetComponent<DragItems>().keyName = keyName;
                                if (lootSound != null)
                                {
                                    lootSound.Play();
                                }
                                GlobalManager.isPickuped[item.name] = true;
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
