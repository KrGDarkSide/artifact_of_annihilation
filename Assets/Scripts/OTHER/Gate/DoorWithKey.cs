using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    private Animator anim;

    public List<string> requiredKeyIDs;
    public List<KeyPadlockPair> padlocks;

    [System.Serializable]
    public class KeyPadlockPair
    {
        public string keyID;
        public PadlockEffect padlock;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            foreach (var pair in padlocks)
            {
                if (PickupKey.collectedKeys.Contains(pair.keyID) && pair.padlock != null)
                {
                    pair.padlock.UnlockPadlock();
                }
            }


            if (HasAllKeys())
            {
                anim.SetTrigger("Open");
            }
        }
    }

    bool HasAllKeys()
    {
        foreach (string keyID in requiredKeyIDs)
        {
            if (!PickupKey.collectedKeys.Contains(keyID))
                return false;
        }
        return true;
    }
}
