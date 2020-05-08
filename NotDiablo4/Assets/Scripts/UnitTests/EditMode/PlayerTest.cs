using NUnit.Framework;
using UnityEngine;


namespace EditModeUnitTests
{
    public class PlayerTest
    {
        private GameObject player = GameObject.FindWithTag("Player");


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

        [Test]
        public void PlayerStartsAtSpawn()
        {
            Vector2 startingPos = player.transform.position;
            Vector2 spawnPoint  = new Vector3(0, -25, 0);

            Assert.AreEqual(startingPos, spawnPoint);
        }
    }
}
