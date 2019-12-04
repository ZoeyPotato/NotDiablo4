using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class CameraTest
    {
        GameObject camera = GameObject.FindWithTag("Camera");
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("Camera");
        float maxCamDepth = -0.3f;


        [Test]
        public void CameraExists()
        {
            Assert.IsNotNull(camera);
        }

        [Test]
        public void ThereIsOnlyOneCamera()
        {
            Assert.AreEqual(cameras.Length, 1);
        }

        [Test]
        public void CameraIsAboveMap()
        {
            Assert.GreaterOrEqual(maxCamDepth, camera.transform.position.z);
        }
    }
}
