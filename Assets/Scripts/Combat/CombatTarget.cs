using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTarget : MonoBehaviour, IInteractable
{


    public void Interact(MonoBehaviour interactionMaker)
    {
        Fighter fighter = interactionMaker.gameObject.GetComponent<Fighter>();
        if ( fighter != null)
        {
            fighter.SetTarget(this);
        }
        Debug.Log("Interactign with " + gameObject.name);

    }
}
