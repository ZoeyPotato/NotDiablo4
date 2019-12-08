using NUnit.Framework;
using UnityEngine;
using NotDiablo4;


namespace Tests
{
    public class PlayerTest
    {
        //TODO get player from func in player script
        GameObject player = GameObject.FindWithTag("Player");
        //TODO get player count from func in player script
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        
        [Test]
        public void PlayerExists()
        {
            Assert.IsNotNull(player);
        }

        [Test]
        public void ThereIsOnlyOnePlayer()
        {
            Assert.AreEqual(players.Length, 1);
        }

        [Test]
        public void PlayerStartsAtSpawn()
        {
            Vector3 startingPos = player.transform.position;
            Vector3 spawnPoint = new Vector3(0, -25, 0);

            Assert.AreEqual(startingPos, spawnPoint);
        }

        [Test]
        public void PlayerCanMove()
        {
            playerMoveUp();
            playerMoveLeft();
            playerMoveDown();
            playerMoveRight();
        }
        #region
        void playerMoveUp()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().MoveUp();

            Assert.AreEqual(player.transform.position.x, currentPos.x);
            Assert.Greater (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        void playerMoveLeft()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().MoveLeft();

            Assert.Less    (player.transform.position.x, currentPos.x);
            Assert.AreEqual(player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        void playerMoveDown()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().MoveDown();

            Assert.AreEqual(player.transform.position.x, currentPos.x);
            Assert.Less    (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        void playerMoveRight()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().MoveRight();

            Assert.Greater (player.transform.position.x, currentPos.x);
            Assert.AreEqual(player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        #endregion
    }
}
