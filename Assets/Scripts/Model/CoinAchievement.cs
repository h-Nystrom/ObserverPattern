using UnityEngine;

namespace Model{
    [CreateAssetMenu(fileName = "CoinCollector", menuName = "Achievement/CoinCollector", order = 0)]
    public class CollectedCoins : ScriptableObject{
        [SerializeField] int goalAmount = 10;
        public int GoalAmount => goalAmount;
        
    }
}