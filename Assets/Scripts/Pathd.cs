using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathd : MonoBehaviour
{
    
    // là biến để enemy đuổi theo nhân vật
    public bool meetPlayer = false ;
    public Transform[] listPoints ;
    public int startAt = 0 ;
    // vị trí chuyển sang
    public bool faceright = false ;
    public int directionMove = 1 ;
    public FlatformFollowPath flat ;
    public Player player ;
    public Enemy enemy ;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>() ;
        flat = gameObject.GetComponent<FlatformFollowPath>();
    }

    //function mà unity cho phép vẽ trong chế độ Editor của Unity
    public void OnDrawGizmos()
    {
        if(listPoints.Length < 2 || listPoints == null){
            return ;
        }
        for(int i = 1 ;i < listPoints.Length ; ++i){
            Gizmos.DrawLine(listPoints[i-1].position ,listPoints[i].position ) ;
        }
    }


    public Transform getpointsAt(int p){
        return  listPoints[p] ;
    }
    public Transform getNextPoints(){
        int rand = Random.Range(0 , 2) ;
        return listPoints[rand] ;
    }

    public void Flip(){
        faceright = !faceright ;
        Vector3  Scale ;
        Scale = transform.localScale ;
        Scale.x *= -1 ;
        transform.localScale = Scale ;
    }
}
