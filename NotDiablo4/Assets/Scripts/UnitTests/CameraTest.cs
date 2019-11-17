using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class CameraTest
    {
        [Test]
        public void CameraExists()
        {
            //TODO
            GameObject worldMap = GameObject.FindWithTag("WorldMap");

            Assert.IsNotNull(worldMap);
        }
    }
}
