using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractableItem : Interactable
    {
        public override void Interact()
        {
            if (interactionIsACallBack) return;
            if (interacted) return;

            if(itemType.itemCategory == ItemCategory.Gun)
            {
                EventsManager.OnAddWeaponToInventory?.Invoke(itemType.weaponCharactaristics);
            }

            if (itemType.itemCategory == ItemCategory.Mod)
            {
                EventsManager.OnAddMod?.Invoke(itemType.modifier, itemType.modifier.Category);
            }


            interacted = true;

            if (interactionVisual)
            {
                interactionVisual.ApplyInteractionVisuals();
                return;
            }

            Debug.Log(gameObject.name + " " + "Collected");

            

            LeanPool.Despawn(gameObject);
        }

        public override void InteractFromCallBack()
        {
            if (interacted) return;

            if (itemType.itemCategory == ItemCategory.Gun)
            {
                EventsManager.OnAddWeaponToInventory?.Invoke(itemType.weaponCharactaristics);
            }

            if (itemType.itemCategory == ItemCategory.Mod)
            {
                EventsManager.OnAddMod?.Invoke(itemType.modifier, itemType.modifier.Category);
            }


            interacted = true;

            if (interactionVisual)
            {
                interactionVisual.ApplyInteractionVisuals();
                return;
            }

            Debug.Log(gameObject.name + " " + "Collected");



            LeanPool.Despawn(gameObject);
        }
    }
}