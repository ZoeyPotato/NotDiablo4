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
            cameraObject = Object.Instantiate(cameraObject);
            
            mainCamera = cameraObject.GetComponent<MainCamera>();
            mainCamera.player = Utility.InstantiatePlayer();
            camerasPlayer = mainCamera.player;
        }


        [Test, Order(0)]
        public void CameraHasPlayer()
        {
            Assert.IsNotNull(camerasPlayer);
        }

        [UnityTest, Order(1)]
        public IEnumerator CameraFollowsPlayer()
        {
            yield return Utility.PlayerMovement(camerasPlayer,  1,  1);
            mainCamera.Movement(camerasPlayer);

            Assert.AreEqual(mainCamera.transform.position.x, camerasPlayer.transform.position.x);
            Assert.AreEqual(mainCamera.transform.position.y, camerasPlayer.transform.position.y);
        }
    }
}
