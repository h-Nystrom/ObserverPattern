using System;
using Model;
using UnityEngine;

namespace Controller{
    public class Coin : MonoBehaviour{
        [SerializeField]CoinsCollected coinsCollected;
        void OnTriggerEnter(Collider other){
            if (!other.gameObject.CompareTag("Player")) return;
            coinsCollected.AddCoin();
            Destroy(gameObject);
        }
    }
}
