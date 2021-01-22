using UnityEngine;

namespace Controller{
    public class Coin : MonoBehaviour{

        [SerializeField] int value = 1;
        void OnTriggerEnter(Collider other){
            if (!other.gameObject.CompareTag("Player")) return;
            AddCoin();
        }

        public void AddCoin(){
            CoinObserver.OnCoinChange(value);
            Destroy(gameObject);
        }
    }
}
