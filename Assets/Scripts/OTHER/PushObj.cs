using UnityEngine;

public class PushObj : MonoBehaviour
{
    public float interactRange = 2f;
    public float pushForce = 5f;
    public Transform playerCamera;

    private Rigidbody heldObject;

    public bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKey(KeyCode.E))
        {
            TryGrabObject();
        }
        else if (heldObject != null)
        {
            heldObject = null;
        }

        if (heldObject != null)
        {
            Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = playerCamera.transform.TransformDirection(moveDir);
            moveDir.y = 0;
            heldObject.linearVelocity = moveDir.normalized * pushForce;
        }
    }

    void TryGrabObject()
    {
        if (heldObject != null) return;

        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            if (hit.rigidbody != null && !hit.rigidbody.isKinematic)
            {
                heldObject = hit.rigidbody;
            }
        }
    }
}
