using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NotDiablo4;


namespace PlayModeUnitTests
{
    public class PlayerTest
    {
        private Player      player;
        private Rigidbody2D rigidBody;


        [SetUp]
        public void Setup()
        { 
            player    = Utility.InstantiatePlayer();
            rigidBody = player.GetComponent<Rigidbody2D>();
        }


        [Test, Order(0)]
        public void PlayerHasRigidbody()
        {
            Assert.IsNotNull(rigidBody);
        }

        [UnityTest, Order(1)]
        public IEnumerator PlayerMovement()
        {
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

            yield return Utility.PlayerMovement(player,  0,  1);

            Assert.AreEqual(rigidBody.position.x, initialPos.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveLeftUp()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player, -1,  1);

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveLeft()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player, -1,  0);

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.AreEqual(rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveLeftDown()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player, -1, -1);

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveDown()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  0, -1);

            Assert.AreEqual(rigidBody.position.x, initialPos.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveRightDown()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  1, -1);

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveRight()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  1,  0);

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.AreEqual(rigidBody.position.y, initialPos.y);
        }
        private IEnumerator playerMoveRightUp()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  1,  1);

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        #endregion
    }
}
