using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    // ===========================
    //          VARIABLES
    // ===========================
    public float health;
    public float currentHealth;
    public float damage;
    public float patrolSpeed;
    public float pursueSpeed;
    public float visibleDistance;
    public float attackRange;
    public float attackCooldown;

    public Rigidbody rb;
    public Transform player;
    public Transform[] poatrolCheckpoints;


    protected State currentState;



    // ===========================
    //          CONSTRUCTOR
    // ===========================
    public Enemy() {}

    public Enemy(float hp, float dam, float patSpeed, float purSpeed, float visDist, float attRange, float attCooldown)
    {
        health = hp;
        damage = dam;
        patrolSpeed = patSpeed;
        pursueSpeed = purSpeed;
        visibleDistance = visDist;
        attackRange = attRange;
        attackCooldown = attCooldown;
    }



    
    public virtual void Start()
    {
        currentHealth = health;
        rb = GetComponent<Rigidbody>();

        //...

        currentState = new Idle(this, rb, player);
    }

    public virtual void Update()
    {
        currentState = currentState.Process();
    }



    // ===========================
    //          METHODS
    // ===========================
    public State SetState(State newState)
    {
        return newState;
    }
}
