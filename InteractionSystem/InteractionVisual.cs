using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractionVisual : MonoBehaviour
    {
        [SerializeField] Animator animator;
        [SerializeField] Collider _collider;

        public void ApplyInteractionVisuals()
        {
            if(animator)
            {
                animator.SetTrigger("Interacted");
            }

            if(_collider)
                _collider.enabled = false;
        }
    }
}