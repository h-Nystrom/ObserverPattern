using Model;
using UnityEngine;
using UnityEngine.Events;

namespace Controller
{ 
    public class AchievementsObserver : MonoBehaviour, ICoinChange{
        
        delegate void CoinsChange(int amount);
        static event CoinsChange CoinsChanged;
        [SerializeField] CoinAchievement[] coinAchievements;
        [SerializeField] UnityEvent<string> totalCoinsChanged;
        [SerializeField] Transform parent, popUpParent;
        public int Amount{
            get => PlayerPrefs.GetInt(name,0);
            private set => PlayerPrefs.SetInt(name,value);
        }
        void Awake(){
            CoinObserver.SubscribeToCoinChange(this);
            foreach (var coinAchievement in coinAchievements){
                if (Amount < coinAchievement.GoalAmount){
                    CoinsChanged += coinAchievement.AddCoin;
                    coinAchievement.SetUp(parent, popUpParent);
                }
                else{
                    coinAchievement.SetUp(parent, popUpParent);
                    coinAchievement.InstantiateAchievement();
                }
            }
            totalCoinsChanged?.Invoke($"Total coins collected: {Amount}");
        }
        void OnDestroy(){
            CoinObserver.UnSubscribeToCoinChange(this);
            foreach (var coinAchievement in coinAchievements){
                CoinsChanged -= coinAchievement.AddCoin;
            }
        }
        
        public static void UnSubscribeToCoinChange(ICoinChange coinChange){
            CoinsChanged -= coinChange.AddCoin;
        }
        public void AddCoin(int amount){
            Amount += 1;
            CoinsChanged?.Invoke(Amount);
            totalCoinsChanged?.Invoke($"Total coins collected: {Amount}");
        }
    }
}