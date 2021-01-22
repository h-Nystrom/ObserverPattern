using System;
using Controller;
using UnityEngine;
using UnityEngine.Events;

namespace View{
    public class CoinsCollected : MonoBehaviour, ICoinChange{

        int coins;
        [SerializeField] UnityEvent<string> coinChanged;
        public int Coins{
            get => coins;
            private set{
                coins = value;
                coinChanged?.Invoke($"Coins: {value}");
            }
        }

        void Awake(){
            CoinObserver.SubscribeToCoinChange(this);
            coinChanged?.Invoke($"Coins: {Coins}");
        }
        public void AddCoin(int amount){
            Coins += amount;
        }
    }
}