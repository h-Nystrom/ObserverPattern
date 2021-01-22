using UnityEngine;

namespace Model{
    public class UnitHealth : MonoBehaviour, IHealth{
        [SerializeField]int health;

        public int Health => health;

        public void TakingDamage(int damage){
            health -= damage;
            
            if (health < 0){
                health = 0;
                //Invoke deathEvent
            }
            //invoke takingDamage
        }
    }

    public interface IHealth{
        int Health{ get; }
        void TakingDamage(int damage);
    }
}