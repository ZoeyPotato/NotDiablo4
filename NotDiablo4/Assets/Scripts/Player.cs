using UnityEngine;


namespace NotDiablo4
{
    public class Player : MonoBehaviour
    {
        public GameObject player;
        public float      movementSpeed = 5f;
        public bool       isMoving      = false;


        void Update()
        {
            Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }


        public void Movement(float horizontalInput, float verticalInput)
        {
            isMoving = horizontalInput != 0 || verticalInput != 0;

            if (isMoving)
            {
                Vector3 movementInput = new Vector3(horizontalInput, verticalInput).normalized;
                movementInput = Utility.RotateMovementInput(movementInput);
                
                Vector3 movement  = movementInput * movementSpeed * Time.deltaTime;
                movement  = Utility.CartesianToIsometric(movement);
                
                player.transform.Translate(movement);
            }
        }
    }
}
