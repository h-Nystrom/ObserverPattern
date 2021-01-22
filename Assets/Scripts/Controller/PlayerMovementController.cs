using Model;
using UnityEngine;

namespace Controller{
    [RequireComponent(typeof(Rigidbody), typeof(IHealth))]
    public class PlayerMovementController : MonoBehaviour{
        [SerializeField] float speed;
        Rigidbody rb;

        void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate(){
            OnMove(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")).normalized);
        }
        void OnMove(Vector3 moveDirection){
            if(moveDirection.magnitude == 0)
                return;
            rb.MovePosition(transform.position + moveDirection * (speed * Time.fixedDeltaTime));
        }
    }
}
