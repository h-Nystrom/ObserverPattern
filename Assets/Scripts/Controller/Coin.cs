using UnityEngine;

namespace Controller{
    public class Coin : MonoBehaviour{

        [SerializeField] int value = 1;
        public int Value => value;
        
        void OnTriggerEnter(Collider other){
            if (!other.gameObject.CompareTag("Player")) return;
            MessageHandler.instance.Send<CoinMessage>(new CoinMessage(value));
            Destroy(gameObject);
        }
    }
    //TODO: Possible to use a factory class instead?
    public class CoinMessage{
        int value;
        public int Value => value;

        public CoinMessage(int value){
            this.value = value;
        }
    }
    public class TotalCoinMessage{
        int value;
        public int Value => value;

        public TotalCoinMessage(int value){
            this.value = value;
        }
    }
}
