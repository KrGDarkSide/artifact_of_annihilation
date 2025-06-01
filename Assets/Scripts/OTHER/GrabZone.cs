using UnityEngine;

public class GrabZone : MonoBehaviour
{
    public PushObj pushScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pushScript.playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pushScript.playerInRange = false;
        }
    }
}
