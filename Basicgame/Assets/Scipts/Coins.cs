using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
   public GameObject coin;

   public float maxX;
   public float minX;
   public float y;
   

   private float  SpawnTime;
   public float  SpawnDelay;
   

    // Update is called once per frame
    void Update()
    {
        if(Time.time>SpawnTime){
            Spawn();
            SpawnTime =Time.time + SpawnDelay; 
        }
    }

    void Spawn(){

        float x = Random.Range(minX,maxX);
        

        Instantiate(coin,transform.position+new Vector3(x,y,0),transform.rotation);
    }
}
