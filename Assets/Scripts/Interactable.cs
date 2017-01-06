using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    [HideInInspector]

    private bool hasInteracted;
    public NavMeshAgent playerAgent;

    public virtual void MoveToInteraction(NavMeshAgent agent) {
        hasInteracted = false;
        this.playerAgent = agent;
        playerAgent.stoppingDistance = 2.5f;
        playerAgent.destination = this.transform.position;
    }

    private void Update() {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending) {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact() {
        Debug.Log("Interacting with base class.");
    }
}
