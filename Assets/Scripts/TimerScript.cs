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
        TimerBar = GetComponent<Image>() ;
        timeLeft = maxTime ;
    }

    // Update is called once per frame
    void Update()
    {

        if(beaten){
            Anim.enabled = true ;
            if(timeLeft >0){
                timeLeft -= Time.deltaTime ;
                if(tmp > 4f){
                    beaten = false ;
                    tmp = 0 ;
                }else{
                    tmp += Time.deltaTime ;
                    TimerBar.fillAmount = timeLeft/maxTime ;
                }
            }else{
                Time.timeScale = 0 ;
            }
        }else{
            Anim.enabled = false ;
        }

        tmp1 += Time.deltaTime ; 

        if(TimerBar.fillAmount < .4f){
            Debug.Log("Test");
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
