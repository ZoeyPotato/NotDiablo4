using UnityEngine;


namespace NotDiablo4
{
    public class Player : MonoBehaviour
    {
        public GameObject player;
        public float speed = 10f;


        void Update()
        {
            movement();
        }

        void movement()
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
            float translation = speed * Time.deltaTime / 2;
            Debug.Log("up");
            player.transform.Translate(0, translation, 0);
        }
        public void MoveLeft()
        {
            float translation = -speed * Time.deltaTime;
            Debug.Log("left");
            player.transform.Translate(translation, 0, 0);
        }
        public void MoveDown()
        {
            float translation = -speed * Time.deltaTime / 2;
            Debug.Log("down");
            player.transform.Translate(0, translation, 0);
        }
        public void MoveRight()
        {
            float translation = speed * Time.deltaTime;
            Debug.Log("right");
            player.transform.Translate(translation, 0, 0);
        }
        #endregion
    }
}
