using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBox : MonoBehaviour   
{   
    public GameObject explode;
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "WaeponA"){
            Destroy(other.gameObject);
            StartCoroutine(delayDeath(0.2f));
        }
    }

    IEnumerator delayDeath(float sec){
        yield return new WaitForSeconds(sec);
        Instantiate(explode, transform.position,transform.rotation);
        Destroy(this.gameObject);
    }
}
