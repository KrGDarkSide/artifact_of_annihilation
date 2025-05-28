using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class PickupKey : Pickup
    {
        public string keyID;

        public static HashSet<string> collectedKeys = new HashSet<string>();

        protected override void OnPicked(PlayerCharacterController playerController)
        {
            base.OnPicked(playerController);

            if (!collectedKeys.Contains(keyID))
            {
                collectedKeys.Add(keyID);
            }

            Destroy(gameObject);
        }
    }
}

