using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NotDiablo4;


namespace PlayModeUnitTests
{
    public class PlayerTest
    {
        private Player      player;
        private Rigidbody2D rigidBody;


        [SetUp]
        public void Setup()
        { 
            player    = Utility.InstantiatePlayer();
            rigidBody = player.GetComponent<Rigidbody2D>();
        }


        [Test, Order(0)]
        public void Exists()
        {
            Assert.IsNotNull(player);
        }

        [Test, Order(1)]
        public void HasRigidbody()
        {
            Assert.IsNotNull(rigidBody);
        }

        [UnityTest]
        public IEnumerator Movement()
        {
            yield return movementUp();
            yield return movementLeftUp();
            yield return movementLeft();
            yield return movementLeftDown();
            yield return movementDown();
            yield return movementRightDown();
            yield return movementRight();
            yield return movementRightUp();
        }
        #region movement
        private IEnumerator movementUp()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  0,  1);

            Assert.AreEqual(initialPos.x, rigidBody.position.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator movementLeftUp()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player, -1,  1);

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator movementLeft()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player, -1,  0);

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.AreEqual(initialPos.y, rigidBody.position.y);
        }
        private IEnumerator movementLeftDown()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player, -1, -1);

            Assert.Less    (rigidBody.position.x, initialPos.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator movementDown()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  0, -1);

            Assert.AreEqual(initialPos.x, rigidBody.position.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator movementRightDown()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  1, -1);

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.Less    (rigidBody.position.y, initialPos.y);
        }
        private IEnumerator movementRight()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  1,  0);

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.AreEqual(initialPos.y, rigidBody.position.y);
        }
        private IEnumerator movementRightUp()
        {
            Vector2 initialPos = rigidBody.position;

            yield return Utility.PlayerMovement(player,  1,  1);

            Assert.Greater (rigidBody.position.x, initialPos.x);
            Assert.Greater (rigidBody.position.y, initialPos.y);
        }
        #endregion


        //TODO move player state machine in its own class

        [Test, Order(2)]
        public void StateMachineStartsInIdle()
        {
            Assert.AreEqual(Player.State.Idle, player.GetCurrentState());
        }

        [Test]
        public void StateMachineGoIdle()
        {
            PlayerInput zeroInput = new PlayerInput();

            player.StateMachine(zeroInput);

            Assert.AreEqual(Player.State.Idle, player.GetCurrentState());
        }

        [Test]
        public void StateMachineGoMoving()
        {
            stateMachineGoMovingUp();
            stateMachineGoMovingLeftUp();
            stateMachineGoMovingLeft();
            stateMachineGoMovingLeftDown();
            stateMachineGoMovingDown();
            stateMachineGoMovingRightDown();
            stateMachineGoMovingRight();
            stateMachineGoMovingRightUp();
        }
        #region stateMachineGoMoving
        private void stateMachineGoMovingUp()
        {
            PlayerInput moveUp     = new PlayerInput();
            moveUp.HorizontalInput =  0;
            moveUp.VerticalInput   =  1;

            player.StateMachine(moveUp);

            Assert.AreEqual(Player.State.Moving, player.GetCurrentState());
        }
        private void stateMachineGoMovingLeftUp()
        {
            PlayerInput moveLeftUp     = new PlayerInput();
            moveLeftUp.HorizontalInput = -1;
            moveLeftUp.VerticalInput   =  1;

            player.StateMachine(moveLeftUp);

            Assert.AreEqual(Player.State.Moving, player.GetCurrentState());
        }
        private void stateMachineGoMovingLeft()
        {
            PlayerInput moveLeft     = new PlayerInput();
            moveLeft.HorizontalInput = -1;
            moveLeft.VerticalInput   =  0;

            player.StateMachine(moveLeft);

            Assert.AreEqual(Player.State.Moving, player.GetCurrentState());
        }
        private void stateMachineGoMovingLeftDown()
        {
            PlayerInput moveLeftDown     = new PlayerInput();
            moveLeftDown.HorizontalInput = -1;
            moveLeftDown.VerticalInput   = -1;

            player.StateMachine(moveLeftDown);

            Assert.AreEqual(Player.State.Moving, player.GetCurrentState());
        }
        private void stateMachineGoMovingDown()
        {
            PlayerInput moveDown     = new PlayerInput();
            moveDown.HorizontalInput =  0;
            moveDown.VerticalInput   = -1;

            player.StateMachine(moveDown);

            Assert.AreEqual(Player.State.Moving, player.GetCurrentState());
        }
        private void stateMachineGoMovingRightDown()
        {
            PlayerInput moveRightDown     = new PlayerInput();
            moveRightDown.HorizontalInput =  1;
            moveRightDown.VerticalInput   = -1;

            player.StateMachine(moveRightDown);

            Assert.AreEqual(Player.State.Moving, player.GetCurrentState());
        }
        private void stateMachineGoMovingRight()
        {
            PlayerInput moveRight     = new PlayerInput();
            moveRight.HorizontalInput =  1;
            moveRight.VerticalInput   =  0;

            player.StateMachine(moveRight);

            Assert.AreEqual(Player.State.Moving, player.GetCurrentState());
        }
        private void stateMachineGoMovingRightUp()
        {
            PlayerInput moveRightUp     = new PlayerInput();
            moveRightUp.HorizontalInput =  1;
            moveRightUp.VerticalInput   =  1;

            player.StateMachine(moveRightUp);

            Assert.AreEqual(Player.State.Moving, player.GetCurrentState());
        }
        #endregion

        [Test]
        public void stateMachineGoMeleeing()
        {
            PlayerInput melee = new PlayerInput();
            melee.LeftClick   = 1;

            player.StateMachine(melee);

            Assert.AreEqual(Player.State.Meleeing, player.GetCurrentState());
        }

        [Test]
        public void stateMachineGoMeleeingWhileMoving()
        {
            PlayerInput meleeWhileMovement     = new PlayerInput();
            meleeWhileMovement.HorizontalInput = 1;
            meleeWhileMovement.VerticalInput   = 1;
            meleeWhileMovement.LeftClick       = 1;

            player.StateMachine(meleeWhileMovement);

            Assert.AreEqual(Player.State.Meleeing, player.GetCurrentState());
        }

        [UnityTest]
        public IEnumerator StateMachineMeleeingLock()
        {
            float meleeTimer  = player.GetMeleeDuration();
            PlayerInput melee = new PlayerInput();
            melee.LeftClick   = 1;
            player.StateMachine(melee);

            while (meleeTimer > 0)
            {
                stateMachineMeleeingLockZeroInput();
                stateMachineMeleeingLockMovementInput();
                stateMachineMeleeingLockMeleeInput();
                stateMachineMeleeingLockAllInput();

                yield return new WaitForFixedUpdate();

                meleeTimer -= Time.fixedDeltaTime;
            }
        }
        #region stateMachineMeleeingLock
        private void stateMachineMeleeingLockZeroInput()
        {
            PlayerInput input = new PlayerInput();

            player.StateMachine(input);

            Assert.AreEqual(Player.State.Meleeing, player.GetCurrentState());
        }
        private void stateMachineMeleeingLockMovementInput()
        {
            PlayerInput input     = new PlayerInput();
            input.HorizontalInput = 1;
            input.VerticalInput   = 1;

            player.StateMachine(input);

            Assert.AreEqual(Player.State.Meleeing, player.GetCurrentState());
        }
        private void stateMachineMeleeingLockMeleeInput()
        {
            PlayerInput input = new PlayerInput();
            input.LeftClick   = 1;

            player.StateMachine(input);

            Assert.AreEqual(Player.State.Meleeing, player.GetCurrentState());
        }
        private void stateMachineMeleeingLockAllInput()
        {
            PlayerInput input     = new PlayerInput();
            input.HorizontalInput = 1;
            input.VerticalInput   = 1;
            input.LeftClick       = 1;

            player.StateMachine(input);

            Assert.AreEqual(Player.State.Meleeing, player.GetCurrentState());
        }
        #endregion

        //TODO public IEnumerator ExitMeleeingState()
    }
}
