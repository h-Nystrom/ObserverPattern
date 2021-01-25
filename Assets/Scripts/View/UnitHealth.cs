using System;
using Controller;
using UnityEngine;
using UnityEngine.Events;

namespace View{
    public class UnitHealth : MonoBehaviour, IHealth{
        
        [SerializeField] int maxHealth = 10;
        [SerializeField] UnityEvent<string> healthChanged;
        public int Health => health;
        int health;

        void Awake(){
            health = maxHealth;
            
            healthChanged?.Invoke($"Health: ({Health}/{maxHealth})");
          
        }
        public void TakingDamage(int damage){
            health -= damage;
            if (health < 0){
                health = 0;
            }
            healthChanged?.Invoke($"Health: ({Health}/{maxHealth})");
            MessageHandler.instance.Send<PlayerHealthMessage>(new PlayerHealthMessage(health));
        }
    }

    public class PlayerHealthMessage{
        int value;

        public int Value => value;

        public PlayerHealthMessage(int value){
            this.value = value;
        }
    }

    public interface IHealth{
        int Health{ get; }
        void TakingDamage(int damage);
    }
}