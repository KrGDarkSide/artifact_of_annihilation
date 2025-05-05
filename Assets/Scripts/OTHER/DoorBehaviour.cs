using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // OPEN DOOR WHEN PLAYER IS IN COLLIDER SPACE
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            anim.SetTrigger("Open");
        }
    }

    // CLOSE DOOR WHEN PLAYER IS IN COLLIDER SPACE
    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            anim.SetTrigger("Close");
        }
    }
}
