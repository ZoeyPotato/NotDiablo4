using UnityEngine;


namespace NotDiablo4
{
    public class PlayerInput
    {
        public float HorizontalInput = 0;
        public float VerticalInput   = 0;
        public float LeftClick       = 0;


        public void Update()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput   = Input.GetAxisRaw("Vertical");
            LeftClick       = Input.GetAxisRaw("LeftClick");
        }
    }
}
