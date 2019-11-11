using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class WorldMap
    {
        [Test]
        public void MapExists()
        {
            GameObject worldMap = GameObject.FindWithTag("WorldMap");

            Assert.IsNotNull(worldMap);
        }

        [Test]
        public void ThereIsOnlyOneMap()
        {
            GameObject[] worldMaps = GameObject.FindGameObjectsWithTag("WorldMap");

            Assert.AreEqual(1, worldMaps.Length);
        }

        [Test]
        public void MapIsOrigin()
        {
            GameObject worldMap = GameObject.FindWithTag("WorldMap");

            Assert.AreEqual(Vector3.zero, worldMap.transform.position);
        }
    }
}
