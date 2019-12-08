using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class CameraTest
    {
        Camera camera = Camera.main;
        float maxCamDepth = -0.3f;


        [Test]
        public void CameraExists()
        {
            Assert.IsNotNull(camera);
        }

        [Test]
        public void ThereIsOnlyOneCamera()
        {
            Assert.AreEqual(Camera.allCamerasCount, 1);
        }

        [Test]
        public void CameraIsAboveMap()
        {
            Assert.GreaterOrEqual(maxCamDepth, camera.transform.position.z);
        }
    }
}
