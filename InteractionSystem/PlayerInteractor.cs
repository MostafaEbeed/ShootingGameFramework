using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] InputReader inputReader;
        
        private void OnTriggerStay(Collider other)
        {
            InteractableItem interactableItem = other.GetComponent<InteractableItem>();
            if(interactableItem && inputReader.PlayerInteractPerformed)
            {
                interactableItem.Interact();
            }
        }
    }
}