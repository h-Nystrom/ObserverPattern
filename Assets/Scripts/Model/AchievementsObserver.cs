using System;
using Controller;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Model{
    public class AchievementsObserver : MonoBehaviour, ICoinChange{
        
        delegate void CoinsChange(int amount);
        static event CoinsChange CoinsChanged;
        [SerializeField] CoinAchievement[] coinAchievements;
        [SerializeField] UnityEvent<string> totalCoinsChanged;
        [SerializeField] Transform parent;
        public int Amount{
            get => PlayerPrefs.GetInt(name,0);
            private set => PlayerPrefs.SetInt(name,value);
        }
        void Awake(){
            CoinObserver.SubscribeToCoinChange(this);
            foreach (var coinAchievement in coinAchievements){
                if (Amount < coinAchievement.GoalAmount){
                    CoinsChanged += coinAchievement.AddCoin;
                    coinAchievement.SetUp(parent);
                }
                else{
                    coinAchievement.SetUp(parent);
                    coinAchievement.InstantiateAchievement();
                }
            }
            totalCoinsChanged?.Invoke($"Total coins collected: {Amount}");
        }
        public static void UnSubscribeToCoinChange(ICoinChange coinChange){
            CoinsChanged -= coinChange.AddCoin;
        }
        public void AddCoin(int amount){
            Amount += 1;
            CoinsChanged?.Invoke(Amount);
            totalCoinsChanged?.Invoke($"Total coins collected: {Amount}");
        }
        void OnDestroy(){
            CoinsChanged = null;
        }
    }
}