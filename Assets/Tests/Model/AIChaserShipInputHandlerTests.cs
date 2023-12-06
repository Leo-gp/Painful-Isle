using System.Numerics;
using Model.ShipModel;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Model
{
    [TestFixture]
    public class AIChaserShipInputHandlerTests
    {
        [SetUp]
        public void SetUp()
        {
            _self = Substitute.For<IShip>();
            _target = Substitute.For<IShip>();

            _inputHandler = new AIChaserShipInputHandler(_self, _target);
        }

        private IShip _self;
        private IShip _target;

        private AIChaserShipInputHandler _inputHandler;

        [Test]
        public void MoveInput_ShouldReturnOne()
        {
            var moveInput = _inputHandler.MoveInput;

            Assert.AreEqual(1f, moveInput, "Move input should be one.");
        }

        [Test]
        public void RotateInput_WhenSelfIsFacingTarget_ReturnZero()
        {
            _self.Position.Returns(new Vector2(0f, 0f));
            _self.RotationAngle.Returns(0f);

            _target.Position.Returns(new Vector2(0f, -10f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.AreEqual(0f, rotationInput, "Rotation input should be zero when facing target.");
        }

        [Test]
        public void RotateInput_WhenAngleToTargetIsPositive_ReturnNegativeValue()
        {
            _self.Position.Returns(new Vector2(0f, 0f));
            _self.RotationAngle.Returns(0f);

            _target.Position.Returns(new Vector2(10f, 5f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.That(rotationInput, Is.LessThan(0),
                "Rotation input should be negative when angle to target is positive.");
        }

        [Test]
        public void RotateInput_WhenAngleToTargetIsNegative_ReturnPositiveValue()
        {
            _self.Position.Returns(new Vector2(0f, 0f));
            _self.RotationAngle.Returns(0f);

            _target.Position.Returns(new Vector2(-10f, 5f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.That(rotationInput, Is.GreaterThan(0),
                "Rotation input should be positive when angle to target is negative.");
        }
    }
}