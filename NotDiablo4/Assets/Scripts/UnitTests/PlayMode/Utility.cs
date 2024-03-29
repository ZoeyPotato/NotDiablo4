﻿using System.Collections;
using UnityEngine;
using NotDiablo4;


namespace PlayModeUnitTests
{
    class Utility
    {
        public static Player InstantiatePlayer()
        {
            GameObject playerObject = Resources.Load("Prefabs/Player") as GameObject;
            playerObject            = Object.Instantiate(playerObject);
            Player player           = playerObject.GetComponent<Player>();
            
            Rigidbody2D rigidBody = playerObject.GetComponent<Rigidbody2D>();
            rigidBody.simulated   = false;   //need to turn off simulation to work around a unity bug
                                             //for some reason, the rigid body moves itself around in PlayMode testing...
                                             //even though gravity and everything is zeroed out
                                             //so we need to turn off physics simulation until we actually move

            return player;
        }

        public static IEnumerator PlayerMovement(Player player, float horizontalInput, float verticalInput)
        {
            Rigidbody2D rigidBody = player.GetComponent<Rigidbody2D>();
            rigidBody.simulated   = true;    //turn on physics simulation so we can move

            player.Movement(horizontalInput, verticalInput);
            yield return new WaitForFixedUpdate();

            rigidBody.simulated   = false;   //turn off to work around unity bug, so the rigidBody doesn't move on its own
        }
    }
}
