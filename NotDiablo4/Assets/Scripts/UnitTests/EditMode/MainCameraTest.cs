using NUnit.Framework;
using UnityEngine;
using NotDiablo4;


namespace EditModeUnitTests
{
    public class MainCameraTest
    {
        private GameObject mainCamera = GameObject.FindWithTag("MainCamera");


        [Test]
        public void CameraExists()
        {
            Assert.IsNotNull(mainCamera);
        }

        [Test]
        public void CameraHasPlayer()
        {
            Player camerasPlayer = mainCamera.GetComponent<MainCamera>().player;

            Assert.IsNotNull(camerasPlayer);
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

            Assert.GreaterOrEqual(maxDepth, mainCamera.transform.position.z);
        }
    }
}
