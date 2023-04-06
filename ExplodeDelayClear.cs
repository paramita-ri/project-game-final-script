using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeDelayClear : MonoBehaviour
{
    public float delayClear = 0.15f;
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(Time.time - startTime >= delayClear){
            Destroy(this.gameObject);
        }
    }
}
