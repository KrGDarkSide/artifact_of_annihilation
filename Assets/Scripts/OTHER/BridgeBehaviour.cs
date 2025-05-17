using UnityEngine;

public class BridgeBehaviour : MonoBehaviour
{
    private Animator anim;
    private bool access;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        access = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player") && !access)
        {
            anim.SetTrigger("Disconnect");
        }
    }

    public void BridgeConnect()
    {
        anim.SetTrigger("Connect");
        access = true;
    }
}
