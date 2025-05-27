using Unity.FPS.Gameplay;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    private Animator anim;
    public PadlockEffect padlockEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PickupKey.HasKey)
        {
            anim.SetTrigger("Open");

            if (padlockEffect != null)
            { padlockEffect.UnlockPadlock(); }
        }
    }
}
