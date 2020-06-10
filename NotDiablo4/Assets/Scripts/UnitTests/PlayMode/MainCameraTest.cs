using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NotDiablo4;


namespace PlayModeUnitTests
{
    class MainCameraTest
    {
        private MainCamera mainCamera;
        private Player     camerasPlayer;


        [SetUp]
        public void Setup()
        {
            GameObject cameraObject = Resources.Load("Prefabs/MainCamera") as GameObject;
            cameraObject            = Object.Instantiate(cameraObject);
            
            mainCamera        = cameraObject.GetComponent<MainCamera>();
            mainCamera.Player = Utility.InstantiatePlayer();
            camerasPlayer     = mainCamera.Player;
        }


        [Test, Order(0)]
        public void Exists()
        {
            Assert.IsNotNull(mainCamera);
        }

        [Test, Order(1)]
        public void HasPlayer()
        {
            Assert.IsNotNull(camerasPlayer);
        }

        [UnityTest]
        public IEnumerator FollowsPlayer()
        {
            yield return Utility.PlayerMovement(camerasPlayer,  1,  1);
            mainCamera.Movement(camerasPlayer);

            Assert.AreEqual(camerasPlayer.transform.position.x, mainCamera.transform.position.x);
            Assert.AreEqual(camerasPlayer.transform.position.y, mainCamera.transform.position.y);
        }
    }
}
