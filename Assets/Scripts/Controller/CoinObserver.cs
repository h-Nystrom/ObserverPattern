using UnityEngine;

namespace Controller{
    public class CoinObserver : MonoBehaviour{

        delegate void CoinsChange(int amount);
        static event CoinsChange CoinsChanged;

        public static void SubscribeToCoinChange(ICoinChange coinChange){
            CoinsChanged += coinChange.AddCoin;
        }
        public static void UnSubscribeToCoinChange(ICoinChange coinChange){
            CoinsChanged -= coinChange.AddCoin;
        }
        public static void OnCoinChange(int amount){
            if (amount < 0) return;
            CoinsChanged?.Invoke(amount);
        }
    }
    public interface ICoinChange{
        void AddCoin(int amount);
    }
}
