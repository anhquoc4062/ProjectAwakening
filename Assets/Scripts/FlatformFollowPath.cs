using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatformFollowPath : MonoBehaviour
{
    public Pathd thepath ;
    public float speed = 1f ;
    
    public bool faceright = false ;
    public Enemy enemy ;
    public Player player ;
    public float h  =1;
    private Transform _targetPoints ;

    
    public GameObject walleft ;
    public GameObject wallright ;
    // Start is called before the first frame update
    void Awake()
    {
       
    }
    void Start()
    {   
        
        speed = 1f;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() ;
        
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>() ;

        if (thepath == null){
            return ;
        }
        int rd = Random.Range(0 ,2) ;
        if(Mathf.Abs(thepath.listPoints[0].position.x - player.transform.position.x) > Mathf.Abs(thepath.listPoints[1].position.x - player.transform.position.x))
        {
            transform.position = thepath.getpointsAt(0).position;
        }
        else
        {
            transform.position = thepath.getpointsAt(1).position;
        }
        
        _targetPoints = thepath.getNextPoints() ;
        
    }

    void FixedUpdate()
    {
        thepath.listPoints[2].position = player.transform.position;
        thepath.listPoints[2].position = new Vector3(thepath.listPoints[2].position.x, thepath.listPoints[1].position.y, 0);
    }

    // Update is called once per frame
    void Update() {
        walleft = GameObject.FindGameObjectWithTag("wallLeft");

        wallright = GameObject.FindGameObjectWithTag("wallRight");
        thepath.listPoints[0].position = new Vector3(walleft.transform.position.x, -2f, 0);

        thepath.listPoints[1].position = new Vector3(wallright.transform.position.x, -2f, 0);
        if (!thepath.meetPlayer){

                if(thepath == null){
                    return  ;
                }
                transform.position = Vector3.MoveTowards(transform.position , _targetPoints.position , speed*Time.deltaTime) ;
                // tính khoản cách giữa 2 điểm trong trường hợp nếu khoản cách này nhỏ hơn tmp thì mình chuyển đi
                var distanceTarget = (transform.position - _targetPoints.position).sqrMagnitude ;
                if(distanceTarget < 0.5f){
                    // thì mình chuyển ;
                    _targetPoints = thepath.getNextPoints() ;
                    if(transform.position.x < _targetPoints.position.x){
                        h = 1 ;
                        Debug.Log("đi về phải");
                        if(!faceright && h > 0){
                            faceright = !faceright ;
                            Vector3  Scale ;
                            Scale = enemy.transform.localScale ;
                            Scale.x *= -1 ;
                            enemy.transform.localScale = Scale ;
                        }

                    }else{
                        Debug.Log("đi về trái");
                        h = -1 ;
                        if(faceright && h < 0){
                            faceright = !faceright ;
                            Vector3  Scale ;
                            Scale = enemy.transform.localScale ;
                            Scale.x *= -1 ;
                            enemy.transform.localScale = Scale ;
                        }
                    }
                }
        }
        else{
            _targetPoints = thepath.listPoints[2] ;
            if(thepath == null){
                    return  ;
                }
                transform.position = Vector3.MoveTowards(transform.position , _targetPoints.position , speed*Time.deltaTime) ;
                // tính khoản cách giữa 2 điểm trong trường hợp nếu khoản cách này nhỏ hơn tmp thì mình chuyển đi
                float distanceTarget = (transform.position - _targetPoints.position).sqrMagnitude ;
                
                    if(enemy.transform.position.x < player.transform.position.x){
                        h = -1 ;
                        if(!faceright && h < 0){
                            faceright = !faceright ;
                            Vector3  Scale ;
                            Scale = enemy.transform.localScale ;
                            Scale.x *= -1 ;
                            enemy.transform.localScale = Scale ;
                        }

                    }else{
                        h = 1 ;
                        if(faceright && h > 0){
                            faceright = !faceright ;
                            Vector3  Scale ;
                            Scale = enemy.transform.localScale ;
                            Scale.x *= -1 ;
                            enemy.transform.localScale = Scale ;
                        }
                    }
                    
        }
    }
    public void Flip(){
        faceright = !faceright ;
        Vector3  Scale ;
        Scale = transform.localScale ;
        Scale.x *= -1 ;
        transform.localScale = Scale ;
    }
}
