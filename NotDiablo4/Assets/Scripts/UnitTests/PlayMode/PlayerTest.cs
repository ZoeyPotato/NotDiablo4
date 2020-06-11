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
            int horizontalInput = -1;
            int verticalInput   = -1;

                while (horizontalInput <= 1)
            {
                while (verticalInput   <= 1)
                {
                    Vector2 initialPos = rigidBody.position;

                    yield return Utility.PlayerMovement(player, horizontalInput, verticalInput);

                    #region asserts
                    if (horizontalInput == -1)
                        Assert.Less    (rigidBody.position.x, initialPos.x);
                    if (verticalInput   == -1)
                        Assert.Less    (rigidBody.position.y, initialPos.y);
                    if (horizontalInput ==  0)
                        Assert.AreEqual(initialPos.x, rigidBody.position.x);
                    if (verticalInput   ==  0)
                        Assert.AreEqual(initialPos.y, rigidBody.position.y);
                    if (horizontalInput ==  1)
                        Assert.Greater (rigidBody.position.x, initialPos.x);
                    if (verticalInput   ==  1)
                        Assert.Greater (rigidBody.position.y, initialPos.y);
                    #endregion

                    verticalInput++;
                }

                horizontalInput++;
                verticalInput = -1;
            }
        }


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
            int horizontalInput = -1;
            int verticalInput   = -1;

                while (horizontalInput <= 1)
            {
                while (verticalInput   <= 1)
                {
                    if (horizontalInput == 0 && verticalInput == 0)
                    {
                        verticalInput++;

                        continue;
                    }

                    PlayerInput movement     = new PlayerInput();
                    movement.HorizontalInput = horizontalInput;
                    movement.VerticalInput   = verticalInput;

                    player.StateMachine(movement);

                    Assert.AreEqual(Player.State.Moving, player.GetCurrentState());

                    verticalInput++;
                }

                horizontalInput++;
                verticalInput = -1;
            }
        }

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
            int horizontalInput = -1;
            int verticalInput   = -1;

                while (horizontalInput <= 1)
            {
                while (verticalInput   <= 1)
                {
                    PlayerInput meleeWhileMoving     = new PlayerInput();
                    meleeWhileMoving.HorizontalInput = horizontalInput;
                    meleeWhileMoving.VerticalInput   = verticalInput;
                    meleeWhileMoving.LeftClick       = 1;

                    player.StateMachine(meleeWhileMoving);

                    Assert.AreEqual(Player.State.Meleeing, player.GetCurrentState());

                    verticalInput++;
                }

                horizontalInput++;
                verticalInput = -1;
            }
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
                int horizontalInput = -1;
                int verticalInput   = -1;
                int leftClick       =  0;

                        while (horizontalInput <= 1)
                {
                        while (verticalInput   <= 1)
                    {
                        while (leftClick       <= 1)
                        {
                            PlayerInput inputs     = new PlayerInput();
                            inputs.HorizontalInput = horizontalInput;
                            inputs.VerticalInput   = verticalInput;
                            inputs.LeftClick       = leftClick;

                            player.StateMachine(inputs);

                            Assert.AreEqual(Player.State.Meleeing, player.GetCurrentState());

                            leftClick++;
                        }

                        verticalInput++;
                        leftClick = 0;
                    }

                    horizontalInput++;
                    verticalInput = -1;
                    leftClick = 0;
                }

                yield return new WaitForFixedUpdate();

                meleeTimer -= Time.fixedDeltaTime;
            }
        }

        //TODO public IEnumerator ExitMeleeingState()
    }
}
