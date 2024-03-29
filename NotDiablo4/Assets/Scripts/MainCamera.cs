﻿using UnityEngine;


namespace NotDiablo4
{
    public class MainCamera : MonoBehaviour
    {
        public Player Player;


        private void LateUpdate()
        {
            Movement(Player);
        }


        public void Movement(Player player)
        {   
            Vector3 playerPosition = player.transform.position;
            playerPosition.z       = transform.position.z;   //maintain the cameras z/depth position
            transform.position     = playerPosition;
        }
    }
}
