using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    [RequireComponent(typeof(Mover))]    
    public class PlayerController : MonoBehaviour
    {
        Camera mainCamera;

        Mover mover;
        Fighter fighter;

        RaycastHit onClickRayHit;

        void Start()
        {
            mover = GetComponent<Mover>();
            fighter = GetComponent<Fighter>();
            mainCamera = Camera.main;
        }

        void Update()
        {
            if (Interact()) return;
            
            Movement();
        }

        private void Movement()
        {
            if (Input.GetMouseButton(1))
            { 
                Ray clickRay = GetMouseRay();
                bool hasHit = Physics.Raycast(clickRay, out onClickRayHit);

                if (fighter != null) { fighter.CancelAttack(); }
                if (hasHit) { mover.MoveTo(onClickRayHit.point); }
            }
        }


        

        private Ray GetMouseRay()
        {
            return mainCamera.ScreenPointToRay(Input.mousePosition);
        }

        bool Interact()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit[] hitsArray = Physics.RaycastAll(GetMouseRay());
                foreach (var hit in hitsArray)
                {
                    IInteractable inter = hit.transform.GetComponent<IInteractable>();
                    if (inter != null)
                    {
                        inter.Interact(this);
                        return true;
                    }
                }
            } 
            return false;
        }
    }
}
