using System;
using Model;
using UnityEngine;

namespace Controller{
    public class Trap : MonoBehaviour{
        [SerializeField] int attackDamage = 1;
        void OnTriggerEnter(Collider other){
            if (!other.gameObject.CompareTag("Player")) return;
            other.gameObject.GetComponent<IHealth>().TakingDamage(attackDamage);
            Destroy(gameObject);
        }
    }
}