using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class TimerScript : MonoBehaviour
{
    Image  TimerBar ; 
    GameObject heart ;
    public float  maxTime = 20f  ,timeLeft;
    public bool beaten = true ;
    private float tmp  = 0 , tmp1 = 0 , filltmp  ;
    Animator Anim ;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>() ;
        Anim.enabled = false ;
        heart = GameObject.Find("Heart") ;
        TimerBar = GameObject.FindGameObjectWithTag("Image").GetComponent<Image>();
        //TimerBar = GetComponent<Image>() ;
        timeLeft = maxTime ;
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log("test 1àdsadfdsfsdfsdfafasdfasdfadsfafdafafdsfasfs");
        if(beaten){
            Debug.Log("test 11111111111111111111111111111111111111111111111");
            Debug.Log(timeLeft + " 999999999999999999999999999999999999") ;
            Anim.enabled = true ;
            if(timeLeft >0){
                
                Debug.Log("test 333333333333333333333333333333333333333333333");
                timeLeft -= Time.deltaTime ;
                if(tmp > 4f){
                    beaten = false ;
                    tmp = 0 ;
                }else{
                    
                    Debug.Log("test 44444444444444444444444444444444444444444444");
                    tmp += Time.deltaTime ;
                    TimerBar.fillAmount = timeLeft/maxTime ;
                }
            }else{
                Debug.Log("test JJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJ");
                Time.timeScale = 0 ;
            }
        }else{
            Debug.Log(" LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");
            Anim.enabled = false ;
        }

        tmp1 += Time.deltaTime ; 


        
        if(TimerBar.fillAmount < .4f){
            Debug.Log("Test 6666666666666666666666666666666666666666666666666666");
            if(tmp1  > 0.3f){
                if(tmp1 > 0.6f){
                    tmp1 = 0 ;
                }
                heart.transform.localScale = new Vector3(transform.localScale.x + 2 , transform.localScale.y + 2 , 0) ;
            }else{
                heart.transform.localScale = new Vector3(transform.localScale.x - 2 , transform.localScale.y -2, 0) ;
            }
        }
        
    }
}
