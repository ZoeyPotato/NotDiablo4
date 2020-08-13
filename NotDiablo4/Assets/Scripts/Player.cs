using UnityEngine;


namespace NotDiablo4
{
    public class Player : MonoBehaviour
    {
        public float MovementSpeed = 5f;
        
        public enum State
        {
            Meleeing,
            Moving,
            Idle
        }
        public State GetCurrentState()  { return currentState;  }
        public float GetMeleeDuration() { return meleeDuration; }
        

        private PlayerInput input = new PlayerInput();
        
        private State currentState  = State.Idle;
        private float meleeDuration = 1;
        private float meleeTimer    = 0;
        
        private Rigidbody2D rigidBody;
        private Animator    animator;
        

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            animator  = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            input.Update();

            StateMachine(input);

            tickTimers();
        }


        public void StateMachine(PlayerInput input)
        {
            bool meleeing = input.LeftClick != 0;
            bool moving   = input.HorizontalInput != 0 || input.VerticalInput != 0;

                 if (meleeing || meleeTimer > 0)
            {
                currentState = State.Meleeing;

                //TODO animation

                Melee();
            }
            else if (moving)
            {
                currentState = State.Moving;
                
                animator.Play("Moving");

                Movement(input.HorizontalInput, input.VerticalInput);
            }
            else
            {
                currentState = State.Idle;
                
                animator.Play("Idle");

                Idle();
            }
        }


        public void Melee()
        {
            if (meleeTimer == 0)
                meleeTimer = meleeDuration;

            
            //TODO melee stuff
        }

        public void Movement(float horizontalInput, float verticalInput)
        {
            rigidBody.velocity = Vector2.zero;   //need to manually zero velocity when not moving
                                                 //unity will set velocity to a non-zero value after colliding into a corner...
                                                 //maybe move to OnCollisionEnter, detect when the corner case happens, then set to zero
            
            Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;
            movementInput         = Utility.RotateMovementInput(movementInput);

            Vector2 movement = movementInput * MovementSpeed * Time.fixedDeltaTime;
            movement         = Utility.CartesianToIsometric(movement);

            rigidBody.MovePosition(rigidBody.position + movement);
        }

        public void Idle()
        {
            //TODO idle stuff

            return;
        }


        private void tickTimers()
        {
            if (currentState == State.Meleeing)
                meleeTimer -= Time.fixedDeltaTime;

            if (meleeTimer < 0)
                meleeTimer = 0;
        }
    }
}
