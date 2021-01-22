using System;
using System.IO.IsolatedStorage;
using UnityEngine;

namespace Controller{
    public class FollowTarget : MonoBehaviour{
        [SerializeField] Transform target;
        Transform myTransform;
        void Start(){
            myTransform = transform;
            if(target == null)
                throw new Exception("Error: No target transform has been added!");
        }
        void LateUpdate(){
            myTransform.position = target.position;
        }
    }
}
