using Unity.FPS.Game;
using UnityEngine;

public class PlatformAfterDeath : MonoBehaviour
{
    [Tooltip("The door's animator to trigger on enemy death")]
    public Animator anim;

    private Health enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<Health>();

        if (enemyHealth != null)
        {
            enemyHealth.OnDie += PlatformOn;
        }
    }

    void PlatformOn()
    {
        if (anim != null)
        {
            anim.SetTrigger("Dead");
        }
    }
}
