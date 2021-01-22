using System;
using System.IO.IsolatedStorage;
using UnityEngine;

namespace Controller{
    public class CameraController : MonoBehaviour{
        [SerializeField] Transform target;
        [SerializeField] float smoothSpeed = 0.025f;
        Transform myTransform;
        void Start(){
            myTransform = transform;
            if(target == null)
                throw new Exception("Error: No target transform has been added!");
        }
        void FixedUpdate(){
            myTransform.position = Vector3.Lerp(myTransform.position, target.position, smoothSpeed);
        }
    }
}
