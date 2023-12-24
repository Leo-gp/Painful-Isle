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

            var shipDeteriorationConfiguration = ShipPresenterFixture.ShipDeteriorationConfiguration;
            _ship.DeteriorationConfiguration.Returns(shipDeteriorationConfiguration);
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

        [TestCase(10f, 100f, 100f, 90f, ShipDeterioration.Healthy, false, 90f)]
        [TestCase(10f, 60f, 100f, 50f, ShipDeterioration.Damaged, false, 50f)]
        [TestCase(15f, 25f, 50f, 10f, ShipDeterioration.Critical, false, 20f)]
        [TestCase(50f, 30f, 50f, 0f, ShipDeterioration.Destroyed, true, 0f)]
        public void TakeDamageTests
        (
            float amount,
            float currentHealth,
            float maxHealth,
            float expectedCurrentHealth,
            ShipDeterioration expectedDeterioration,
            bool shouldExplode,
            float healthBarPercentage
        )
        {
            _ship.CurrentHealth.Returns(currentHealth);
            _ship.MaxHealth.Returns(maxHealth);

            _shipPresenter.TakeDamage(amount);

            _ship.Received().CurrentHealth = expectedCurrentHealth;
            _ship.Received().Deterioration = expectedDeterioration;
            _shipView.Received().UpdateDeterioration(expectedDeterioration);
            _shipView.Received().UpdateHealthBarSlider(healthBarPercentage);

            if (shouldExplode) _shipView.Received().Explode();
            else _shipView.DidNotReceive().Explode();
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