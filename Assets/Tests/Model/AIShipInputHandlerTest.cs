using System.Numerics;
using Model.ShipModel;
using Model.ShipModel.ShipInputHandler;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Model
{
    [TestFixture]
    public class AIShipInputHandlerTest
    {
        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IAIShip>();

            _inputHandler = new AIShipInputHandler(_ship);
        }

        private IAIShip _ship;

        private AIShipInputHandler _inputHandler;

        [Test]
        public void MoveInput_ShouldReturnOne()
        {
            var moveInput = _inputHandler.MoveInput;

            Assert.AreEqual(1f, moveInput, "Move input should be one.");
        }

        [Test]
        public void MoveInput_WhenInputsAreDisabled_ShouldReturnZero()
        {
            _inputHandler.DisableInputs();

            var moveInput = _inputHandler.MoveInput;

            Assert.AreEqual(0f, moveInput, "Move input should be zero when inputs are disabled.");
        }

        [Test]
        public void RotateInput_WhenSelfIsFacingTarget_ReturnZero()
        {
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.RotationAngle.Returns(0f);
            _ship.Target.Position.Returns(new Vector2(0f, -10f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.AreEqual(0f, rotationInput, "Rotation input should be zero when facing target.");
        }

        [Test]
        public void RotateInput_WhenAngleToTargetIsPositive_ReturnNegativeValue()
        {
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.RotationAngle.Returns(0f);
            _ship.Target.Position.Returns(new Vector2(10f, 5f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.That(rotationInput, Is.LessThan(0),
                "Rotation input should be negative when angle to target is positive.");
        }

        [Test]
        public void RotateInput_WhenAngleToTargetIsNegative_ReturnPositiveValue()
        {
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.RotationAngle.Returns(0f);
            _ship.Target.Position.Returns(new Vector2(-10f, 5f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.That(rotationInput, Is.GreaterThan(0),
                "Rotation input should be positive when angle to target is negative.");
        }

        [Test]
        public void RotateInput_WhenInputsAreDisabled_ShouldReturnZero()
        {
            _inputHandler.DisableInputs();

            var rotationInput = _inputHandler.RotateInput;

            Assert.AreEqual(0f, rotationInput, "Rotation input should be zero when inputs are disabled.");
        }
    }
}