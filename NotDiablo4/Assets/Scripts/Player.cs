using UnityEngine;


namespace NotDiablo4
{
    public class Player : MonoBehaviour
    {
        public  float       MovementSpeed = 5f;
        
        private bool        isMoving      = false;
        private Rigidbody2D rigidBody;
        private Animator animator;
        


        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            animator  = GetComponent<Animator>();
        }


        private void FixedUpdate()
        {
            Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }


        public void Movement(float horizontalInput, float verticalInput)
        {
            rigidBody.velocity = Vector2.zero;   //need to manually zero velocity when not moving
                                                 //unity will set velocity to a non-zero value after colliding into a corner...
                                                 //maybe move to OnCollisionEnter, detect when the corner case happens, then set to zero
            
            isMoving = horizontalInput != 0 || verticalInput != 0;
            animator.SetBool("IsMoving", isMoving);

            if (isMoving)
            {
                Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;
                movementInput = Utility.RotateMovementInput(movementInput);

                Vector2 movement = movementInput * MovementSpeed * Time.fixedDeltaTime;
                movement = Utility.CartesianToIsometric(movement);

                rigidBody.MovePosition(rigidBody.position + movement);
            }
        }
    }
}
