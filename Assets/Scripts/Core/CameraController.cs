using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] Vector3 distanceToPlayer;


        void LateUpdate()
        {
            transform.position = player.position - distanceToPlayer;
        }
    }
}
