using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigiEnemie : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float walkLeft = 0.2f;
    public float walhRight = 0.2f;
    public float walkDirection = 0.5f;
    public GameObject explode;
    Vector3 walkAmount;

    void Update()
    {
        walkAmount.x = (walkDirection* walkSpeed) * Time.deltaTime;
        if(walkDirection > 0.0f && transform.position.x >= walhRight){
            walkDirection = -1.0f;
        }
        else if(walkDirection < 0.0f && transform.position.x <= walkLeft){
            walkDirection = 1.0f;
        }
        transform.Translate(walkAmount);
    }
    
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
