using System;
using System.Numerics;

namespace Model.ShipModel.ShipInputHandler
{
    public class AIShipInputHandler : IShipInputHandler
    {
        private const float MoveInputValue = 1f;
        private const float RotateRightInputValue = 1f;
        private const float RotateLeftInputValue = -1f;
        private const float NoRotationInputValue = 0f;
        private const float RotationDeadzone = 5f;
        private const float RotationSmoothTime = 0.1f;
        private const float Deg2Rad = MathF.PI / 180f;
        private const float Rad2Deg = 180f / MathF.PI;

        private readonly IAIShip _ship;

        private float _currentRotationInput;
        private bool _inputsEnabled;

        public AIShipInputHandler(IAIShip ship)
        {
            _ship = ship;
            _inputsEnabled = true;
        }

        public virtual float MoveInput => _inputsEnabled ? MoveInputValue : 0f;

        public float RotateInput => _inputsEnabled ? CalculateRotationInput() : 0f;

        public void DisableInputs()
        {
            _inputsEnabled = false;
        }

        private float CalculateRotationInput()
        {
            var directionToTarget = CalculateDirectionToTarget();
            var selfForward = CalculateSelfForward();
            var angleDiff = CalculateAngleDifferenceToTarget(selfForward, directionToTarget);
            var targetRotationInput = DetermineTargetRotationInput(angleDiff);
            _currentRotationInput = SmoothRotationInput(targetRotationInput);
            return _currentRotationInput;
        }

        private Vector2 CalculateDirectionToTarget()
        {
            return Vector2.Normalize(_ship.Target.Position - _ship.Position);
        }

        private Vector2 CalculateSelfForward()
        {
            var rotationInRadians = _ship.RotationAngle * Deg2Rad;
            return new Vector2(MathF.Sin(rotationInRadians), -MathF.Cos(rotationInRadians));
        }

        private static float CalculateAngleDifferenceToTarget(Vector2 selfForward, Vector2 directionToTarget)
        {
            var angleSelf = MathF.Atan2(selfForward.Y, selfForward.X);
            var angleToTarget = MathF.Atan2(directionToTarget.Y, directionToTarget.X);
            var angleDifference = (angleToTarget - angleSelf) * Rad2Deg;
            return NormalizeAngleTo180(angleDifference);
        }

        private static float NormalizeAngleTo180(float angle)
        {
            return angle switch
            {
                < -180 => angle + 360,
                > 180 => angle - 360,
                _ => angle
            };
        }

        private static float DetermineTargetRotationInput(float angleDiff)
        {
            return angleDiff switch
            {
                > RotationDeadzone => RotateLeftInputValue,
                < -RotationDeadzone => RotateRightInputValue,
                _ => NoRotationInputValue
            };
        }

        private float SmoothRotationInput(float targetRotationInput)
        {
            return Lerp(_currentRotationInput, targetRotationInput, RotationSmoothTime);
        }

        private static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
    }
}