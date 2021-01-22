using System;
using UnityEngine;

namespace Controller{
    public class Coin : MonoBehaviour
    {
        void OnTriggerEnter(Collider other){
            if (!other.gameObject.CompareTag("Player")) return;
            print("CallEventHere");
            Destroy(gameObject);
        }
    }
}
