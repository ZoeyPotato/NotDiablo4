using NUnit.Framework;
using UnityEngine;
using NotDiablo4;


namespace EditModeUnitTests
{
    public class MainCameraTest
    {
        private MainCamera mainCamera;


        [SetUp]
        public void Setup()
        { 
            GameObject cameraObject = GameObject.FindWithTag("MainCamera");
            mainCamera              = cameraObject.GetComponent<MainCamera>();
        }


        [Test, Order(0)]
        public void Exists()
        {
            Assert.IsNotNull(mainCamera);
        }

        [Test]
        public void ThereIsOnlyOne()
        {
            Assert.AreEqual(1, Camera.allCamerasCount);
        }

        [Test]
        public void HasPlayer()
        {
            Assert.IsNotNull(mainCamera.Player);
        }

        [Test]
        public void IsAtRequiredDepth()
        {
            float requiredDepth = -10;

            Assert.AreEqual(requiredDepth, mainCamera.transform.position.z);
        }
    }
}
