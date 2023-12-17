using Model.ShipModel;
using Model.ShipModel.ShipInputHandler;
using NSubstitute;
using NUnit.Framework;
using Presenter.ShipPresenter;

namespace Tests.Model
{
    [TestFixture]
    public class AIShooterShipInputHandlerTest
    {
        [SetUp]
        public void SetUp()
        {
            _ship = Substitute.For<IAIShip>();
            _shipPresenter = Substitute.For<IAIShooterShipPresenter>();

            _inputHandler = new AIShooterShipInputHandler(_ship, _shipPresenter);
        }

        private IAIShip _ship;
        private IAIShooterShipPresenter _shipPresenter;

        private AIShooterShipInputHandler _inputHandler;

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
        public void FrontalShootInput_WhenCanShoot_ReturnTrue()
        {
            _shipPresenter.CanFrontalShoot().Returns(true);

            var shootInput = _inputHandler.FrontalShootInput;

            Assert.IsTrue(shootInput, "Frontal shoot input should be true when can shoot.");
        }

        [Test]
        public void FrontalShootInput_WhenCannotShoot_ReturnFalse()
        {
            _shipPresenter.CanFrontalShoot().Returns(false);

            var shootInput = _inputHandler.FrontalShootInput;

            Assert.IsFalse(shootInput, "Frontal shoot input should be false when cannot shoot.");
        }
    }
}