using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class CameraTest
    {
        Camera camera = Camera.main;


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
            float maxDepth = -0.3f;

            Assert.GreaterOrEqual(maxDepth, camera.transform.position.z);
        }
    }
}
