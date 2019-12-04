using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class MapTest
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
            Assert.AreEqual(maps.Length, 1);
        }

        [Test]
        public void MapIsOrigin()
        {
            Assert.AreEqual(map.transform.position, Vector3.zero);
        }
    }
}
