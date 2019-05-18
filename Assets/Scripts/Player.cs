using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 30f, speedRun = 50f, maxspeedWalk = 3, maxspeedRun = 5, jumpPow = 280f;
    public bool grounded = true, faceright = true, doubleJump = false, run =false;
    public Rigidbody2D r2;
    public Animator anim;
    public AudioSource footstep;
    public SpriteRenderer sprite;
    public GameObject bleeding;

    public AudioSource flashlight_sound;
    public GameObject flashlight;
    public GameObject nolight;
    public bool flashlight_on = true;

    public AudioSource baloSound;
    public Inventory inventory;
    public GameObject balo;
    public bool baloIsOn = false;

    public TextMeshProUGUI charText;
    public Image textBg;
    // Start is called before the first frame update

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        //footstep = gameObject.GetComponent<AudioSource>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        inventory = gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        anim.SetBool("Run", run);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = !run;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            bool checkFlashLight = false;
            for(int  i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.slots[i].name == "flashlight")
                {
                    checkFlashLight = true;
                    break;
                }
            }
            if(checkFlashLight == true)
            {
                flashlight.SetActive(!flashlight_on);
                nolight.SetActive(flashlight_on);
                flashlight_on = !flashlight_on;
                flashlight_sound.Play();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            baloSound.Play();
            balo.SetActive(!baloIsOn);
            baloIsOn = !baloIsOn;
        }
        //test log
        if (Input.GetKeyDown(KeyCode.L))
        {
            string json = PlayerPrefs.GetString("InventorySlot");
            Debug.Log(json);
        }
    }

    void FixedUpdate()
    {
        if (GlobalManager.countSquired > 0)
        {
            bleeding.SetActive(true);
        }
        else
        {
            bleeding.SetActive(false);
        }

        if(charText.text != "")
        {
            textBg.enabled = true;
        }
        else
        {
            textBg.enabled = false;
        }

        float h = Input.GetAxis("Horizontal");
        if (run == false)
        {
            r2.AddForce((Vector2.right) * speed * h);
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {

                footstep.Play();
            }
            else
            {
                footstep.Pause();
            }

            if (r2.velocity.x >= maxspeedWalk)
            {
                r2.velocity = new Vector2(maxspeedWalk, r2.velocity.y);
            }
            else if (r2.velocity.x <= -maxspeedWalk)
            {
                r2.velocity = new Vector2(-maxspeedWalk, r2.velocity.y);
            }
        }
        else
        {
            r2.AddForce((Vector2.right) * speedRun * h);
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {
                footstep.Play();
            }
            else
            {
                footstep.Pause();
            }

            if (r2.velocity.x >= maxspeedRun)
            {
                r2.velocity = new Vector2(maxspeedRun, r2.velocity.y);
            }
            else if (r2.velocity.x <= -maxspeedRun)
            {
                r2.velocity = new Vector2(-maxspeedRun, r2.velocity.y);
            }
        }

        //change orientation
        if (h > 0 && !faceright)
        {
            Flip();
        }

        else if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        } 
        

        float checkSpeed = anim.GetFloat("Speed");
        if (checkSpeed > 0.1)
        {
            if(run == true)
            {
                footstep.pitch = 1.7f;
            }
            else
            {
                footstep.pitch = 1.0f;
            }
            footstep.Play();
        }
        else
        {
            footstep.Stop();
        }
    }

    void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = sprite.transform.localScale;
        Scale.x *= -1;
        sprite.transform.localScale = Scale;

        //avoid background text flip
        Vector3 bgScale;
        bgScale = textBg.transform.localScale;
        bgScale.x *= -1;
        textBg.transform.localScale = bgScale;
    }
}
