using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed=0.5f;
    private void Update()
    {
        transform.position +=new Vector3(speed,0)*Input.GetAxis("Horizontal");
        transform.position +=new Vector3(0,speed)*Input.GetAxis("Vertical");
    }
}
