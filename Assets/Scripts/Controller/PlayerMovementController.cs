using Model;
using UnityEngine;
using View;

namespace Controller{
    [RequireComponent(typeof(CharacterController), typeof(IHealth))]
    public class PlayerMovementController : MonoBehaviour{
        [SerializeField] float speed;
        CharacterController characterController;

        void Awake(){
            characterController = GetComponent<CharacterController>();
        }

        void Update(){
            OnMove(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized);
        }
        void OnMove(Vector3 moveDirection){
            if(moveDirection.magnitude == 0)
                return;
            characterController.Move(moveDirection * (speed * Time.deltaTime));
        }
    }
}
