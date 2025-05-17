using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public BridgeBehaviour bridge;
    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bridge.BridgeConnect();
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
