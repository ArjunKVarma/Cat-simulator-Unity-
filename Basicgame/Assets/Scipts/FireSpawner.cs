using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField]
    private GameObject fireball;

    [SerializeField]
    private Transform leftPos , rightPos;


    private int randomSpawn;


    void Start(){ 
        StartCoroutine(SpawnFireball());
    }
   
    IEnumerator SpawnFireball(){
        while(true){
            yield return new WaitForSeconds(Random.Range(2, 5));

        randomSpawn = Random.Range(0,2);

        fireball = Instantiate(fireball);


        if(randomSpawn == 0){
            fireball.transform.position = rightPos.position;
            fireball.GetComponent<fireScript>().fireSpeed = -Random.Range(7,13);
            fireball.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else{
            fireball.transform.position = leftPos.position;
            fireball.GetComponent<fireScript>().fireSpeed = Random.Range(7,13);
            fireball.transform.localScale = new Vector3(1f, -1f, 1f);
        }
        }

    }
}
