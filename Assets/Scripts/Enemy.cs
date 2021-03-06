﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool faceright = true ;
    public bool meet = false ;
    public float changeDirection = -1 ;
    public Animator anim  ;
    public Rigidbody2D r2 ; 
    public Player player ;
    public Pathd pathd ;
    public bool findPlayer = false ;
    public bool Squir = false ;
    public bool afterhit = false ;  
    public FlatformFollowPath Flat ;
    public int range  = 20 ;
    public float dis ;
    public float time = 0;
    public int random = 0 ;



    //sound
    public AudioSource stab;
    public AudioSource laugh;
    public AudioSource footstep;
    public AudioSource chasing;
    void Start()
    {
        pathd = GameObject.FindGameObjectWithTag("ThePath").GetComponent<Pathd>() ;
        Flat  = gameObject.GetComponent<FlatformFollowPath>() ;
        anim = gameObject.GetComponent<Animator>() ;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() ;
        r2 = gameObject.GetComponent<Rigidbody2D>() ;
    }

    void Update()
    {   
        random = Random.Range( 5,7) ;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        dis = Mathf.Abs(this.transform.position.x - player.transform.position.x) ;
        //tức là khi trong tầm hoạt động bot sẽ đuổi theo chém 1 hit
        /*if(dis < range * 2)
        {
            footstep.Play();
        }*/
        if(meet == true)
        {
            if(GlobalManager.firstMeetEnemy == false)
            {
                GlobalManager.firstMeetEnemy = true;
            }

            if (!chasing.isPlaying)
            {
                chasing.Play();
            }
        }
        else
        {
            if (chasing.isPlaying)
            {
                chasing.Stop();
            }
        }
        if(dis < range){
            //khi khoản cách dưới 15 sẽ bắt đầu chạy nhanh và tăng tầm chạy lên 20 , tăng tốc độ enemy 
            range = 20 ;
            meet = true;
            pathd.meetPlayer = true ;
            Flat.speed = 4.3f ;
            GlobalManager.meetPlayer = true;
            //tăng tốc enemy cho ngầu thôi
            /*if(dis < 6){
                Flat.speed = 4f ;
            }*/
        }
        // gán lại range = -1 để tránh sự kiện bot đuổi theo khi vừa chém
        if(range == -1){

            time += Time.deltaTime;
            if(time < 3f && time > 0.5f){
                Flat.enabled = false ;
                afterhit = true;

            }
            else{
                Flat.enabled = true ;
                afterhit = false;
                laugh.Play();
            }

            if(time  > random){
                range = 15 ;
                time = 0 ;
            }
        }

        if(Squir == true)
        {
            GlobalManager.countSquired++;
            Debug.Log("Số lần chém là " + GlobalManager.countSquired);
        }
        anim.SetBool("after" , afterhit) ;
        anim.SetBool("meet" , meet) ;
        anim.SetBool("squir" , Squir) ;

        /*int checkFaceRight = (faceright == true) ? -1 : 1;

        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= checkFaceRight;*/

        faceright = gameObject.GetComponent<FlatformFollowPath>().faceright;
    }
    public void Flip(){
        faceright = !faceright ;
        Vector3  Scale ;
        Scale = transform.localScale ;
        Scale.x *= -1 ;
        transform.localScale = Scale ;
    }
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        range = 20 ;
        
    }
}

