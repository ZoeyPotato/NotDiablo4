using NUnit.Framework;
using UnityEngine;


namespace Tests
{
    public class CameraTest
    {
        GameObject camera = GameObject.FindWithTag("Camera");
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("Camera");


        [Test]
        public void CameraExists()
        {
            Assert.IsNotNull(camera);
        }

        [Test]
        public void ThereIsOnlyOneCamera()
        {
            Assert.AreEqual(1, cameras.Length);
        }

        [Test]
        public void CameraIsAboveMap()
        {
            Assert.LessOrEqual(camera.transform.position.z, -0.3);
        }
    }
}
