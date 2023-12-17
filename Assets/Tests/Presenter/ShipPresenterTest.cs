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
    }
}