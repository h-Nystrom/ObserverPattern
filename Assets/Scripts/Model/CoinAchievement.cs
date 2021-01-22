using Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Model{
    [CreateAssetMenu(fileName = "CoinCollector", menuName = "Achievement/CoinCollector", order = 0)]
    public class CoinAchievement : ScriptableObject, ICoinChange{
        [SerializeField] int goalAmount = 10;
        [SerializeField] Text achievementPrefab;
        Transform parent;
        public int GoalAmount => goalAmount;

        public void SetUp(Transform parent){
            this.parent = parent;
        }
        public void AddCoin(int amount){
            if(amount < goalAmount)
                return;
            Debug.Log("Completed!");
            AchievementsObserver.UnSubscribeToCoinChange(this);
            InstantiateAchievement();
        }
        public void InstantiateAchievement(){
            var instance = Instantiate(achievementPrefab, parent);
            instance.text = $"{name}: {goalAmount}coins";
        }
    }
}