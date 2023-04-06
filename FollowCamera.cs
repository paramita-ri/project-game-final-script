using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float dampTime = 0.15f;
    public Vector3 velocity;
    public Transform target; 
    public Camera camera;

    void Start(){
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if(target) {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.1f, 0.2f, point.z));
            Vector3 destination =  transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
