using NUnit.Framework;
using UnityEngine;
using NotDiablo4;


namespace Tests
{
    public class PlayerTest
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        Vector3 spawnPoint = new Vector3(0, -25, 0);
        Vector3 initialPos;


        //PlayerTest()   //TODO resolve No suitable constructor was found
        //{
        //    currentPos = player.transform.position;
        //}

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

        //[Test]
        //public void PlayerStartsAtSpawn()
        //{
        //    Assert.AreEqual(initialPos, spawnPoint);
        //}

        [Test]
        public void PlayerCanMove()
        {
            PlayerMoveUp();
            PlayerMoveLeft();
            PlayerMoveDown();
            PlayerMoveRight();
        }
        #region
        void PlayerMoveUp()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().MoveUp();

            Assert.AreEqual(player.transform.position.x, currentPos.x);
            Assert.Greater (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        void PlayerMoveLeft()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().MoveLeft();

            Assert.Less    (player.transform.position.x, currentPos.x);
            Assert.AreEqual(player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        void PlayerMoveDown()
        {
            Vector3 currentPos = player.transform.position;

            player.GetComponent<Player>().MoveDown();

            Assert.AreEqual(player.transform.position.x, currentPos.x);
            Assert.Less    (player.transform.position.y, currentPos.y);
            Assert.AreEqual(player.transform.position.z, currentPos.z);
        }
        void PlayerMoveRight()
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
