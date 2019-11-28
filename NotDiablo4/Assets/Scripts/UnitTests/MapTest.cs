using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class Map
    {
        GameObject map = GameObject.FindWithTag("Map");
        GameObject[] maps = GameObject.FindGameObjectsWithTag("Map");


        [Test]
        public void MapExists()
        {
            Assert.IsNotNull(map);
        }

        [Test]
        public void ThereIsOnlyOneMap()
        {
            Assert.AreEqual(1, maps.Length);
        }

        [Test]
        public void MapIsOrigin()
        {
            Assert.AreEqual(Vector3.zero, map.transform.position);
        }
    }
}
