using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Unity.FPS.Gameplay.PlayerCharacterController>();
        var pickup = GetComponentInParent<Unity.FPS.Gameplay.Pickup>();

        if (player != null && pickup != null)
        {
            pickup.SendMessage("OnTriggerEnter", other, SendMessageOptions.DontRequireReceiver);
        }
    }
}
