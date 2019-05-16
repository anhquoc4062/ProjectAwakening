using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy enemy ;
    private Player player ;
    private FlatformFollowPath Flat ;
    private Pathd pathd ;
    TimerScript TimerScript ;
    public AudioSource stab;
    void Start()
    {
        TimerScript = GameObject.FindGameObjectWithTag("Image").GetComponent<TimerScript>() ;
        Flat  = gameObject.GetComponent<FlatformFollowPath>() ;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>() ;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() ;
        pathd = GameObject.FindGameObjectWithTag("ThePath").GetComponent<Pathd>() ;
    }

    // Update is called once per frame  
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
            //tức là khi player bị phát hiện mới chém
          
    }
    private void OnTriggerStay2D(Collider2D other) {
            if(other.CompareTag("Player")){
                if(pathd.meetPlayer){
                    enemy.meet = true ;
                    enemy.Squir = true ;
<<<<<<< HEAD
                    //TimerScript.beaten = true ;
=======
                    stab.Play();
                    player.bleeding.SetActive(true);
                    //TimerScript.beaten = true ;
                    //StartCoroutine(waiting(5f));
                    //enemy.afterhit = false ;
                    //enemy.Flat.enabled = true ;
>>>>>>> d3153da53be9352f275050688f3077b089ff79e1
                    StartCoroutine(Hit(0.03f));
                }
            }
    }
    IEnumerator Hit(float x)
    {
        yield return new WaitForSeconds(x);
        Debug.Log("Chém");
        pathd.meetPlayer = false ;
        enemy.Squir = false ;
        Flat.speed = 4f;
        enemy.range = -1 ;
    }
    IEnumerator waiting(float x)
    {
        yield return new WaitForSeconds(x); 
        
                    enemy.Flat.enabled  = false ;
                    enemy.afterhit = true ;
    }
}
