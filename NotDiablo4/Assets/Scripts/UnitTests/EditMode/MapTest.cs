using NUnit.Framework;
using UnityEngine;


namespace EditModeUnitTests
{
    public class MapTest
    {
        private GameObject mapObject;


        [SetUp]
        public void Setup()
        { 
            mapObject = GameObject.FindWithTag("Map");
        }


        [Test, Order(0)]
        public void Exists()
        {
            Assert.IsNotNull(mapObject);
        }

        [Test]
        public void ThereIsOnlyOne()
        {
            int numberOfMaps = GameObject.FindGameObjectsWithTag("Map").Length;

            Assert.AreEqual(1, numberOfMaps);
        }

        [Test]
        public void IsOrigin()
        {
            Assert.AreEqual(Vector3.zero, mapObject.transform.position);
        }
    }
}
