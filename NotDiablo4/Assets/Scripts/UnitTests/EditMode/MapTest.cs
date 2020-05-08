﻿using NUnit.Framework;
using UnityEngine;


namespace EditModeUnitTests
{
    public class MapTest
    {
        private GameObject map = GameObject.FindWithTag("Map");


        [Test]
        public void MapExists()
        {
            Assert.IsNotNull(map);
        }

        [Test]
        public void ThereIsOnlyOneMap()
        {
            GameObject[] maps = GameObject.FindGameObjectsWithTag("Map");

            Assert.AreEqual(maps.Length, 1);
        }

        [Test]
        public void MapIsOrigin()
        {
            Assert.AreEqual(map.transform.position, Vector3.zero);
        }
    }
}
