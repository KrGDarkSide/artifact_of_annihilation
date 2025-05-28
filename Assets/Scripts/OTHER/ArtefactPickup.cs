using UnityEngine;
using Unity.FPS.Game;
using System.Collections.Generic;

namespace Unity.FPS.Gameplay
{
    public class ArtefactPickup : Pickup
    {
        [Tooltip("Reference to the door to open when this gem is picked up")]
        public List<ExitDoor> doorsToOpen;

        protected override void Start()
        {
            base.Start();

            PickupRigidbody.isKinematic = false;
            PickupRigidbody.useGravity = true;
            PickupRigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            m_Collider.isTrigger = false;
        }

        void Update()
        {
            if (PickupRigidbody.isKinematic)
            {
                float bobbing = ((Mathf.Sin(Time.time * VerticalBobFrequency) * 0.5f) + 0.5f) * BobbingAmount;
                transform.position = m_StartPosition + Vector3.up * bobbing;
                transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime, Space.Self);
            }
        }

        protected override void OnPicked(PlayerCharacterController playerController)
        {
            base.OnPicked(playerController);

            foreach (var door in doorsToOpen)
            {
                if (door != null)
                    door.OpenDoor();
            }

            Destroy(gameObject);
        }
    }
}
