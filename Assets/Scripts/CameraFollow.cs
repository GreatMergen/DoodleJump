using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float cameraSpeed;
    [SerializeField] float  offSet;

    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        if(target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, target.position.y + offSet, -10), cameraSpeed * Time.deltaTime);
        }
       
    }
}
