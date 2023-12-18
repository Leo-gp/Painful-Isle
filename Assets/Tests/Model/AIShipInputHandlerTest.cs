using System.Numerics;
using Model.ShipModel;
using Model.ShipModel.ShipInputHandler;
using NSubstitute;
using NUnit.Framework;
using Presenter.ShipPresenter;

namespace Tests.Model
{
    [TestFixture]
    public class AIShipInputHandlerTest
    {
        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IAIShip>();
            _shipPresenter = Substitute.For<IShipPresenter>();

            _inputHandler = new AIShipInputHandler(_ship, _shipPresenter);
        }

        private IAIShip _ship;
        private IShipPresenter _shipPresenter;

        private AIShipInputHandler _inputHandler;

        [Test]
        public void MoveInput_WhenCanMove_ReturnOne()
        {
            _shipPresenter.CanMove().Returns(true);

            var moveInput = _inputHandler.MoveInput;

            Assert.AreEqual(1f, moveInput, "Move input should be one when can move.");
        }

        [Test]
        public void MoveInput_WhenCannotMove_ReturnZero()
        {
            _shipPresenter.CanMove().Returns(false);

            var moveInput = _inputHandler.MoveInput;

            Assert.AreEqual(0f, moveInput, "Move input should be zero when cannot move.");
        }

        [Test]
        public void RotateInput_WhenCannotRotate_ReturnZero()
        {
            _shipPresenter.CanRotate().Returns(false);

            var rotationInput = _inputHandler.RotateInput;

            Assert.AreEqual(0f, rotationInput, "Rotation input should be zero when cannot rotate.");
        }

        [Test]
        public void RotateInput_WhenCanRotateAndSelfIsFacingTarget_ReturnZero()
        {
            _shipPresenter.CanRotate().Returns(true);
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.RotationAngle.Returns(0f);
            _ship.Target.Position.Returns(new Vector2(0f, -10f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.AreEqual(0f, rotationInput, "Rotation input should be zero when facing target.");
        }

        [Test]
        public void RotateInput_WhenCanRotateAndAngleToTargetIsPositive_ReturnNegativeValue()
        {
            _shipPresenter.CanRotate().Returns(true);
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.RotationAngle.Returns(0f);
            _ship.Target.Position.Returns(new Vector2(10f, 5f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.That(rotationInput, Is.LessThan(0),
                "Rotation input should be negative when angle to target is positive.");
        }

        [Test]
        public void RotateInput_WhenCanRotateAngleToTargetIsNegative_ReturnPositiveValue()
        {
            _shipPresenter.CanRotate().Returns(true);
            _ship.Position.Returns(new Vector2(0f, 0f));
            _ship.RotationAngle.Returns(0f);
            _ship.Target.Position.Returns(new Vector2(-10f, 5f));

            var rotationInput = _inputHandler.RotateInput;

            Assert.That(rotationInput, Is.GreaterThan(0),
                "Rotation input should be positive when angle to target is negative.");
        }
    }
}