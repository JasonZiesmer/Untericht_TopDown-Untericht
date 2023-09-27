using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]        // automatically adds the component to the gameObject
[RequireComponent(typeof(AgentRotate2d))]
[RequireComponent(typeof(AgentOverride2d))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Pawn : PawnBase      // pawn refers to the player's controlled character 
{
    private NavMeshAgent agent;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveByDistance(Vector2 movement)
    {
        CancelMovement();
        rigidbody.AddForce(movement, ForceMode2D.Force);
    }

    public void MoveToPosition(Vector2 position)        // pawn movement 
    {
        agent.isStopped = false;
        agent.ResetPath();
        agent.SetDestination(position);
    }

    public void CancelMovement()        // cancels pawn movement
    {
        agent.isStopped = true;
    }

   
    
}
