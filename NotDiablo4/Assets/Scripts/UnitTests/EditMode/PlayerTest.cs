using NUnit.Framework;
using UnityEngine;
using NotDiablo4;


namespace EditModeUnitTests
{
    public class PlayerTest
    {
        private Player player;


        [SetUp]
        public void Setup()
        { 
            GameObject playerObject = GameObject.FindWithTag("Player");
            player                  = playerObject.GetComponent<Player>();
        }


        [Test, Order(0)]
        public void Exists()
        {
            Assert.IsNotNull(player);
        }

        [Test]
        public void ThereIsOnlyOne()
        {
            int numberOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

            Assert.AreEqual(1, numberOfPlayers);
        }

        [Test]
        public void StartsAtSpawn()
        {
            Vector3 spawnPoint = new Vector3(0, -25, 0);

            Assert.AreEqual(spawnPoint, player.transform.position);
        }
    }
}
