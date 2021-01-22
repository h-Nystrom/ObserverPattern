using Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Model{
    [CreateAssetMenu(fileName = "CoinCollector", menuName = "Achievement/CoinCollector", order = 0)]
    public class CoinAchievement : ScriptableObject, ICoinChange{
        [SerializeField] int goalAmount = 10;
        [SerializeField] Text achievementPrefab;
        Transform parent;
        Transform popUpParent;
        public int GoalAmount => goalAmount;

        public void SetUp(Transform parent, Transform popUpParent){
            this.parent = parent;
            this.popUpParent = popUpParent;
        }
        public void AddCoin(int amount){
            if(amount < goalAmount)
                return;
            
            AchievementsObserver.UnSubscribeToCoinChange(this);
            InstantiateAchievement();
            InstantiatePopUpAchievement();
        }

        void InstantiatePopUpAchievement(){
            Debug.Log("PopUp");
            var instance = Instantiate(achievementPrefab, popUpParent);
            instance.text = $"{name}: {goalAmount}coins";
            Destroy(instance.gameObject,5f);
        }
        public void InstantiateAchievement(){
            var instance = Instantiate(achievementPrefab, parent);
            instance.text = $"{name}: {goalAmount}coins";
        }
    }
}