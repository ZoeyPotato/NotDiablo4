using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NotDiablo4;


namespace Tests
{
    public class PlayerTest
    {
        private Player      player;
        private Rigidbody2D rigidBody;


        [SetUp]
        public void Setup()
        {
            GameObject playerObject = Resources.Load("Prefabs/Player") as GameObject;
            playerObject = Object.Instantiate(playerObject);
 
            player    = playerObject.GetComponent<Player>();
            rigidBody = playerObject.GetComponent<Rigidbody2D>();
            
            rigidBody.simulated = false;   //need to turn off simulation to work around a unity bug
                                           //for some reason, the rigid body moves around even though gravity and so on are zeroed out
                                           //so we need to turn off physics simulation until we are ready to move
        }


        [Test, Order(0)]
        public void RigidBodyExists()
        {
            Assert.IsNotNull(rigidBody);
        }

        [UnityTest, Order(1)]
        public IEnumerator PlayerMovement()
        {
            rigidBody.simulated = true;   //turn on physics simulation just before movement testing

            yield return playerMoveUp();
            yield return playerMoveLeftUp();
            yield return playerMoveLeft();
            yield return playerMoveLeftDown();
            yield return playerMoveDown();
            yield return playerMoveRightDown();
            yield return playerMoveRight();
            yield return playerMoveRightUp();
        }
        #region movement
        private IEnumerator playerMoveUp()
        {
            Vector2 initialPos = rigidBody.position;

            player.Movement( 0,  1);
            yield return new WaitForFixedUpdate();

            Assert.AreEqual(rigidBody.position.x, initialPos.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveLeftUp()
        {
            Vector2 initialPos = rigidBody.position;

            player.Movement(-1,  1);
            yield return new WaitForFixedUpdate();

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveLeft()
        {
            Vector2 initialPos = rigidBody.position;

            player.Movement(-1,  0);
            yield return new WaitForFixedUpdate();

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.AreEqual(rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveLeftDown()
        {
            Vector2 initialPos = rigidBody.position;

            player.Movement(-1, -1);
            yield return new WaitForFixedUpdate();

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveDown()
        {
            Vector2 initialPos = rigidBody.position;

            player.Movement( 0, -1);
            yield return new WaitForFixedUpdate();

            Assert.AreEqual(rigidBody.position.x, initialPos.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveRightDown()
        {
            Vector2 initialPos = rigidBody.position;

            player.Movement( 1, -1);
            yield return new WaitForFixedUpdate();

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveRight()
        {
            Vector2 initialPos = rigidBody.position;

            player.Movement( 1,  0);
            yield return new WaitForFixedUpdate();

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.AreEqual(rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveRightUp()
        {
            Vector2 initialPos = rigidBody.position;

            player.Movement( 1,  1);
            yield return new WaitForFixedUpdate();

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        #endregion
    }
}
