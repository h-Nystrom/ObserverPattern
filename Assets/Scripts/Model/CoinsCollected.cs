using UnityEngine;

namespace Model{
    public class CoinsCollected : MonoBehaviour{

        int coins;
        public int Coins{
            get => coins;
            set{
                coins = value;
                print($"Coins {coins}");
            }
        }

        public void AddCoin(){
            Coins += 1;
        }
    }
}