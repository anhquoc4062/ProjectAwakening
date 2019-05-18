using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy enemy ;
    private Player player ;
    private FlatformFollowPath Flat ;
    public Pathd pathd ;
    TimerScript TimerScript ;
    void Start()
    {
        //TimerScript = GameObject.FindGameObjectWithTag("Image").GetComponent<TimerScript>() ;
        Flat  = gameObject.GetComponent<FlatformFollowPath>() ;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>() ;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() ;
        pathd = GameObject.FindGameObjectWithTag("ThePath").GetComponent<Pathd>();
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
                if(pathd.meetPlayer == true){
                    enemy.meet = true ;
                    enemy.Squir = true ;
                    //player.bleeding.SetActive(true);
                    GlobalManager.countSquired++;
                    //TimerScript.beaten = true ;
                    //StartCoroutine(waiting(5f));
                    //enemy.afterhit = false ;
                    //enemy.Flat.enabled = true ;
                    StartCoroutine(Hit(0.03f));
                }
            }
    }
    IEnumerator Hit(float x)
    {
        yield return new WaitForSeconds(x);
        Debug.Log("Chém");
        pathd.meetPlayer = false ;
        enemy.stab.Play();
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
