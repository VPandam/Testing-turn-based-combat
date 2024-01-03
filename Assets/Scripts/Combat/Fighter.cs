using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    CombatTarget actualTarget;
    Mover mover;
    [SerializeField]float weaponRange;

    private void Start()
    {
        mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if (actualTarget == null) return;
        bool reachedEnemy = mover.MoveTo(actualTarget.transform.position, weaponRange);
        if(reachedEnemy) Attack();
    }

    public void SetTarget(CombatTarget target)
    {
        {
            actualTarget = target;
        }
    }
    void Attack()
    {
        Debug.Log("attacking " + actualTarget);
    }
    public void CancelAttack() { actualTarget = null; }
}
