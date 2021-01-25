using Model;
using UnityEngine;
using View;

namespace Controller{
    public class Trap : MonoBehaviour{
        [SerializeField] int attackDamage = 1;
        void OnTriggerEnter(Collider other){
            if (!other.gameObject.CompareTag("Player")) return;
            other.GetComponent<IHealth>().TakingDamage(attackDamage);
            Destroy(gameObject);
        }
    }
}