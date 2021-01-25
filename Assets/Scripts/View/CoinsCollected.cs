using Controller;
using Model;
using UnityEngine;
using UnityEngine.Events;

namespace View{
    public class CoinsCollected : MonoBehaviour, ICoin{

        int coins;
        [SerializeField] UnityEvent<string> coinChanged;
        public int Coins{
            get => coins;
            private set{
                coins = value;
                coinChanged?.Invoke($"Coins: {value}");
            }
        }
        void Start(){
            MessageHandler.instance.SubscribeTo<CoinMessage>(AddCoin);
            coinChanged?.Invoke($"Coins: {Coins}");
        }
        public void AddCoin(CoinMessage coinMessage){
            Coins += coinMessage.Value;
        }
    }
}