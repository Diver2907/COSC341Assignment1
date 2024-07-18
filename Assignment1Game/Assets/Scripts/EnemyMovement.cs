using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != points[current].position){
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed*0.001f);
        }
        else{
            current++;
            if(current == 2){
                current = 0;
            }
        }
    }
    
}

