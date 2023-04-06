using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public float speed = 6f;
    public float secondDestroy = 0.15f;
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Time.time - startTime >= secondDestroy) {
            Destroy(this.gameObject);
        }
    }
}

