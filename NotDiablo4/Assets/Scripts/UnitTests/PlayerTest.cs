using NUnit.Framework;
using UnityEngine;
using NotDiablo4;


namespace Tests
{
    public class PlayerTest
    {
        GameObject player = GameObject.FindWithTag("Player");


        [Test]
        public void PlayerExists()
        {
            Assert.IsNotNull(player);
        }

        [Test]
        public void ThereIsOnlyOnePlayer()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            Assert.AreEqual(players.Length, 1);
        }

        [Test, Order(1)]
        public void PlayerStartsAtSpawn()
        {
            Vector3 startingPos = player.transform.position;
            Vector3 spawnPoint  = new Vector3(0, -25, 0);

            Assert.AreEqual(startingPos, spawnPoint);
        }

        [Test, Order(2)]
        public void PlayerMovement()
        {
            playerMoveUp();
            playerMoveLeftUp();
            playerMoveLeft();
            playerMoveLeftDown();
            playerMoveDown();
            playerMoveRightDown();
            playerMoveRight();
            playerMoveRightUp();
        }
        #region movement
        private void playerMoveUp()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().Movement( 0,  1);

            Assert.AreEqual(player.transform.position.x, currentPos.x);
            Assert.Greater (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        private void playerMoveLeftUp()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().Movement(-1,  1);

            Assert.Less    (player.transform.position.x, currentPos.x);
            Assert.Greater (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        private void playerMoveLeft()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().Movement(-1,  0);

            Assert.Less    (player.transform.position.x, currentPos.x);
            Assert.AreEqual(player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        private void playerMoveLeftDown()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().Movement(-1, -1);

            Assert.Less    (player.transform.position.x, currentPos.x);
            Assert.Less    (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        private void playerMoveDown()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().Movement( 0, -1);

            Assert.AreEqual(player.transform.position.x, currentPos.x);
            Assert.Less    (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        private void playerMoveRightDown()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().Movement( 1, -1);

            Assert.Greater (player.transform.position.x, currentPos.x);
            Assert.Less    (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        private void playerMoveRight()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().Movement( 1,  0);

            Assert.Greater (player.transform.position.x, currentPos.x);
            Assert.AreEqual(player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        private void playerMoveRightUp()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().Movement( 1,  1);

            Assert.Greater (player.transform.position.x, currentPos.x);
            Assert.Greater (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        #endregion
    }
}
