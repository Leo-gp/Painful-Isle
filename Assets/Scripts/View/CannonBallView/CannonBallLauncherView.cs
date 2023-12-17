using UnityEngine;
using View.ShipView;

namespace View.CannonBallView
{
    public class CannonBallLauncherView : MonoBehaviour
    {
        [SerializeField] private CannonBallView cannonBallViewPrefab;

        public void LaunchCannonBall(Vector2 position, Vector2 direction, IShipView ownerShipView)
        {
            var cannonBallView = Instantiate(cannonBallViewPrefab, position, Quaternion.identity);
            cannonBallView.Initialize(position, direction, ownerShipView);
        }
    }
}