using UnityEngine;

public class State
{
    public enum STATE
    { IDLE, PATROL, PURSUE, ATTACK };

    public enum EVENT
    { ENTER, UPDATE, EXIT };



    // ===========================
    //          VARIABLES
    // ===========================
    public STATE name;
    protected EVENT stage;
    protected Enemy npc;
    protected Transform player;
    protected State nextState;
    protected Rigidbody rb;



    // ===========================
    //          CONSTRUCTOR
    // ===========================
    public State(Enemy npc, Rigidbody rb, Transform player)
    {
        this.npc = npc;
        this.rb = rb;
        this.player = player;

        stage = EVENT.ENTER;
    }



    // ===========================
    //          METHODS
    // ===========================
    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }


    public State Process()
    {
        if (stage == EVENT.ENTER) { Enter(); }
        if (stage == EVENT.UPDATE) { Update(); }
        if (stage == EVENT.EXIT)
        {
            Exit();
            return npc.SetState(nextState);
        }

        return this;
    }


    public bool PlayerDetected()
    {
        return false;
    }

    public bool CombatHand()
    {
        return false;
    }

    public bool CombatGun()
    {
        return false;
    }

}
