using System;
using System.Numerics;

namespace Model.ShipModel
{
    public class AIChaserShipInputHandler : IAIShipInputHandler
    {
        private const float MoveInputValue = 1f;
        private const float RotateRightInputValue = 1f;
        private const float RotateLeftInputValue = -1f;
        private const float NoRotationInputValue = 0f;
        private const float RotationDeadzone = 5f;
        private const float RotationSmoothTime = 0.1f;
        private const float Deg2Rad = MathF.PI / 180f;
        private const float Rad2Deg = 180f / MathF.PI;

        private float _currentRotationInput;

        public AIChaserShipInputHandler(IShip self, IShip targetShip)
        {
            Self = self;
            TargetShip = targetShip;
        }

        public float MoveInput => MoveInputValue;

        public float RotateInput => CalculateRotationInput();

        public IShip Self { get; }

        public IShip TargetShip { get; }

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
            return Vector2.Normalize(TargetShip.Position - Self.Position);
        }

        private Vector2 CalculateSelfForward()
        {
            var rotationInRadians = Self.RotationAngle * Deg2Rad;
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