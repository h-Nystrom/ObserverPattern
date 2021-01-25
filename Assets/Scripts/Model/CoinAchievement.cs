using System;
using Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Model{
    [CreateAssetMenu(fileName = "CoinCollector", menuName = "Achievement/CoinCollector", order = 0)]
    public class CoinAchievement : ScriptableObject{
        [SerializeField] int goalAmount = 10;
        [SerializeField] Text achievementPrefab;
        Transform parent;
        Transform popUpParent;
        public int GoalAmount => goalAmount;

        public void SetUp(Transform parent, Transform popUpParent){
            this.parent = parent;
            this.popUpParent = popUpParent;
        }
        public void AddCoin(TotalCoinMessage totalCoinMessage){
            if(totalCoinMessage.Value < goalAmount)
                return;
            Debug.Log(totalCoinMessage.Value);
            InstantiateAchievement();
            InstantiatePopUpAchievement();
            MessageHandler.instance.UnsubscribeFrom<TotalCoinMessage>(AddCoin);
        }
        void InstantiatePopUpAchievement(){
            var instance = Instantiate(achievementPrefab, popUpParent);
            instance.text = $"{name}: {goalAmount}coins";
            Destroy(instance.gameObject,3f);
        }
        public void InstantiateAchievement(){
            var instance = Instantiate(achievementPrefab, parent);
            instance.text = $"{name}: {goalAmount}coins";
        }
    }
    public interface ICoin{
        void AddCoin(CoinMessage coinMessage);
    }
}