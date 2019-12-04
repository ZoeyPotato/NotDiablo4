using UnityEngine;


namespace NotDiablo4
{
    public class Player : MonoBehaviour
    {
        public GameObject player;
        float speed = 5f;


        void Update()
        {
            Movement();
        }

        void Movement()
        {
            if (Input.GetButton("w"))
                MoveUp();
            if (Input.GetButton("a"))
                MoveLeft();
            if (Input.GetButton("s"))
                MoveDown();
            if (Input.GetButton("d"))
                MoveRight();
        }
        #region
        public void MoveUp()
        {
            float translation = speed * Time.deltaTime;
            player.transform.Translate(0, translation, 0);
        }
        public void MoveLeft()
        {
            float translation = -speed * Time.deltaTime;
            player.transform.Translate(translation, 0, 0);
        }
        public void MoveDown()
        {
            float translation = -speed * Time.deltaTime;
            player.transform.Translate(0, translation, 0);
        }
        public void MoveRight()
        {
            float translation = speed * Time.deltaTime;
            player.transform.Translate(translation, 0, 0);
        }
        #endregion
    }
}
