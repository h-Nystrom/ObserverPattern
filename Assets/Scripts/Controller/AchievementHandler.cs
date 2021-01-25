using System;
using Model;
using UnityEngine;
using UnityEngine.Events;

namespace Controller
{ 
    public class AchievementHandler : MonoBehaviour{
        
        [SerializeField] CoinAchievement[] coinAchievements;
        [SerializeField] UnityEvent<string> totalCoinsChanged;
        [SerializeField] Transform parent, popUpParent;
        public int Amount{
            get => PlayerPrefs.GetInt(name,0);
            private set => PlayerPrefs.SetInt(name,value);
        }
        void Start(){
            MessageHandler.instance.SubscribeTo<CoinMessage>(AddCoin);
            foreach (var coinAchievement in coinAchievements){
                coinAchievement.SetUp(parent, popUpParent);
                if (Amount < coinAchievement.GoalAmount){
                    MessageHandler.instance.SubscribeTo<TotalCoinMessage>(coinAchievement.AddCoin);
                }
                else{
                    coinAchievement.InstantiateAchievement();
                }
            }
            totalCoinsChanged?.Invoke($"Total coins collected: {Amount}");
        }
        void AddCoin(CoinMessage coinMessage){
            Amount += coinMessage.Value;
            MessageHandler.instance.Send(new TotalCoinMessage(Amount));
            totalCoinsChanged?.Invoke($"Total coins collected: {Amount}");
        }
    }
}