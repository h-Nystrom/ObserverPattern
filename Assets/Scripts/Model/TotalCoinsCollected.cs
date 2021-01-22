using UnityEngine;

namespace Model{
    [CreateAssetMenu(menuName = "ScriptableObjects/TotalCoinsCollected")]
    public class TotalCoinsCollected : ScriptableObject{
        public int Amount{
            get => PlayerPrefs.GetInt(name,0);
            set => PlayerPrefs.SetInt(name, Amount + value);
        }
    }
}