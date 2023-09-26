using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]        // automatically adds the component to the gameObject
[RequireComponent(typeof(AgentRotate2d))]
[RequireComponent(typeof(AgentOverride2d))]

public class Pawn : MonoBehaviour       // pawn refers to the player's controlled character 
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();     
    }

   

    public void MoveToPosition(Vector2 position)        // pawn movement 
    {
        agent.isStopped = false;
        agent.SetDestination(position);
    }

    public void CancelMovement()        // cancels pawn movement
    {
        agent.isStopped = true;
    }

    public Vector2 GetPosition()        // access to player pawn's position
    {
        return (Vector2)transform.position;
    }
    
}
