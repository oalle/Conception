using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Target;
    public float speedX = 5f;
    public float Ymin = -1f;
    public float Xmax = 160f;

    void Update()
    {
        var pos = transform.position;
        if (Target.position.y < Ymin) {
            pos.y = Ymin;
        }else {
            pos.y = Target.position.y;
        }
        
        if (pos.x < Xmax) {
            pos.x += speedX * Time.deltaTime;
        }
        

        transform.position = pos;
    }
}
