using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    // ==========================
    //      CONSTRUCTOR
    // ==========================
    public Idle(Enemy npc, Rigidbody rb, Transform player) : base(npc, rb, player)
    {
        name = STATE.IDLE;
    }



    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        npc.StartCoroutine(WaitBeforeStateChange());
    }

    public override void Exit()
    {
        base.Exit();
    }



    private IEnumerator WaitBeforeStateChange()
    {
        float waitFor = Random.Range(2.0f, 5.0f);
        yield return new WaitForSeconds(waitFor);

        if (PlayerDetected())
        {
            //nextState = new Pursue(npc, rb, player);
        }
        else
        {
            //newState = new Patrol(npc, rb, player);
        }

        stage = EVENT.EXIT;
    }
}
