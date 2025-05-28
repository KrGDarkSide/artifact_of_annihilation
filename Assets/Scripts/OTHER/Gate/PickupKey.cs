using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class PickupKey : Pickup
    {
        public static int playersKeys = 0;

        protected override void OnPicked(PlayerCharacterController playerController)
        {
            base.OnPicked(playerController);

            playersKeys++;

            // Destroy the key object
            Destroy(gameObject);
        }
    }
}

