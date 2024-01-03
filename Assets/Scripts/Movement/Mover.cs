using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {


        NavMeshAgent agent;
        Animator animator;

        [SerializeField]
        Transform target;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        public bool MoveTo(Vector3 destination, float stoppingDistance = 0)
        {
            agent.destination = destination;
            float distanceToTarget = Vector3.Distance(transform.position, destination);
            
            if (stoppingDistance > 0)
            {
                if (distanceToTarget <= stoppingDistance) {
                    Stop();
                    return true;
                }
             
            }
            agent.isStopped = false;
            return distanceToTarget > .1 ? false : true;

        }

        void Stop() { agent.isStopped = true; }

        void UpdateAnimator()
        {
            Vector3 velocity = agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            animator.SetFloat("forwardSpeed", speed);
        }
    }

}
