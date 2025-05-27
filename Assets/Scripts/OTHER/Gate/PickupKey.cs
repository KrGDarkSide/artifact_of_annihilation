using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class PickupKey : Pickup
    {
        public static bool HasKey = false;

        protected override void OnPicked(PlayerCharacterController playerController)
        {
            base.OnPicked(playerController);

            HasKey = true;
            Debug.Log("Key picked up!");

            // Optionally destroy the key object
            Destroy(gameObject);
        }
    }
}

