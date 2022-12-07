using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverandom : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;//点滅する速度
   
    private Vector3 thispos;
   
    
    private void Start()
    {
        thispos = this.transform.position;
    }
    private void Update()
    {

        transform.position = new Vector3(Mathf.Sin(Time.time) * speed + thispos.x, thispos.y, thispos.z);

    }
}
