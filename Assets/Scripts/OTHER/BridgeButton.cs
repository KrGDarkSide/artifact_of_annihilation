using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public BridgeBehaviour bridge;
    private bool playerInRange;
    private Animator anim;
    public Renderer rend;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bridge.BridgeConnect();
            anim.SetTrigger("Pressed");

            // Disable material emission
            if (rend != null)
            {
                Material mat = rend.material;
                mat.DisableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", Color.black);
            }
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
