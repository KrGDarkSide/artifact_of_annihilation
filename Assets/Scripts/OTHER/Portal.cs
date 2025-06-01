using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportTarget;  // The destination to teleport the player to

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            CharacterController controller = obj.GetComponent<CharacterController>();

            // Temporarily disable CharacterController if using one
            if (controller != null)
                controller.enabled = false;

            obj.transform.position = teleportTarget.position;
            obj.transform.rotation = teleportTarget.rotation;

            if (controller != null)
                controller.enabled = true;
        }
    }
}
