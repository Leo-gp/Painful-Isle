using System.Numerics;
using Model.ShipModel;
using NSubstitute;
using NUnit.Framework;
using Presenter.ShipPresenter;
using View.ShipView;

namespace Tests.Presenter
{
    [TestFixture]
    public class ShipPresenterTests
    {
        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IShip>();
            _shipView = Substitute.For<IShipView>();

            _shipPresenter = Substitute.ForPartsOf<ShipPresenter>(_ship, _shipView);
        }

        private IShip _ship;
        private IShipView _shipView;

        private ShipPresenter _shipPresenter;

        [Test]
        public void Move_ShouldMoveShipViewAndSetPosition()
        {
            const float moveInput = 1f;
            const float shipMoveSpeed = 10f;
            var shipViewPosition = new Vector2(10f, 0f);

            const float expectedMove = moveInput * shipMoveSpeed;

            _ship.MoveSpeed.Returns(shipMoveSpeed);
            _shipView.Position.Returns(shipViewPosition);

            _shipPresenter.Move(moveInput);

            _shipView.Received().Move(expectedMove);
            _ship.Received().Position = shipViewPosition;
        }

        [Test]
        public void Rotate_ShouldRotateShipViewAndSetRotationAngle()
        {
            const float rotationInput = 1f;
            const float shipRotationSpeed = 10f;
            const float shipViewRotation = 90f;

            const float expectedRotation = rotationInput * shipRotationSpeed;

            _ship.RotationSpeed.Returns(shipRotationSpeed);
            _shipView.Rotation.Returns(shipViewRotation);

            _shipPresenter.Rotate(rotationInput);

            _shipView.Received().Rotate(expectedRotation);
            _ship.Received().RotationAngle = shipViewRotation;
        }

        [Test]
        public void
            TakeDamage_WhenAmountIsGreaterOrEqualCurrentHealth_ShouldSetCurrentHealthToZeroAndAndExplodeAndUpdateHealthBarSlider()
        {
            const float amount = 15f;
            const float currentHealth = 10f;
            const float maxHealth = 10f;

            _ship.CurrentHealth.Returns(currentHealth);
            _ship.MaxHealth.Returns(maxHealth);

            _shipPresenter.TakeDamage(amount);

            _ship.Received().CurrentHealth = 0f;
            _shipView.Received().Explode();
            _shipView.Received().UpdateHealthBarSlider(0f);
        }

        [Test]
        public void
            TakeDamage_WhenAmountIsLessThanCurrentHealth_ShouldUpdateCurrentHealthAndNotExplodeAndUpdateHealthBarSlider()
        {
            const float amount = 10f;
            const float currentHealth = 15f;
            const float maxHealth = 20f;

            _ship.CurrentHealth.Returns(currentHealth);
            _ship.MaxHealth.Returns(maxHealth);

            _shipPresenter.TakeDamage(amount);

            _ship.Received().CurrentHealth = 5f;
            _shipView.DidNotReceive().Explode();
            _shipView.Received().UpdateHealthBarSlider(25f);
        }

        [Test]
        public void CanMove_WhenShipIsDestroyed_ReturnFalse()
        {
            _ship.IsDestroyed.Returns(true);

            var canMove = _shipPresenter.CanMove();

            Assert.IsFalse(canMove, "Should return false when ship is destroyed.");
        }

        [Test]
        public void CanMove_WhenShipIsNotDestroyed_ReturnTrue()
        {
            _ship.IsDestroyed.Returns(false);

            var canMove = _shipPresenter.CanMove();

            Assert.IsTrue(canMove, "Should return true when ship is not destroyed.");
        }

        [Test]
        public void CanRotate_WhenShipIsDestroyed_ReturnFalse()
        {
            _ship.IsDestroyed.Returns(true);

            var canRotate = _shipPresenter.CanRotate();

            Assert.IsFalse(canRotate, "Should return false when ship is destroyed.");
        }

        [Test]
        public void CanRotate_WhenShipIsNotDestroyed_ReturnTrue()
        {
            _ship.IsDestroyed.Returns(false);

            var canRotate = _shipPresenter.CanRotate();

            Assert.IsTrue(canRotate, "Should return true when ship is not destroyed.");
        }
    }
}