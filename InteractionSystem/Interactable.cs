using GunSystem;
using Lean.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InteractionSystem
{
    public enum ItemCategory
    {
        Gun,
        Mod,
        Key,
        EnvItem,
        Grenade
    }

    public enum ModType
    {
        FireRate,
        Damage
    }

    [Serializable]
    public struct ItemType
    {
        public ItemCategory itemCategory;
        public ModType modType;
        public Modifier modifier;
        public WeaponCharactaristics weaponCharactaristics;
        public GameObject prefab;
    }

    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] public ItemType itemType;
        [SerializeField] protected bool interacted;
        [SerializeField] public bool interactionIsACallBack;

        [Header("Idling")]
        [SerializeField] public bool shouldHaveMeshHolder;
        [SerializeField] public Transform meshHolder;

        [Header("Visual")]
        [SerializeField] public InteractionVisual interactionVisual;

        private void Awake()
        {
            if (interactionIsACallBack)
            {
                EventsManager.OnRoomCleared += InteractFromCallBack;
            }

            if (itemType.prefab)
            {
                GameObject go = LeanPool.Spawn(itemType.prefab, transform.position, Quaternion.identity);
                go.transform.SetParent(meshHolder);
            }

            interactionVisual = GetComponent<InteractionVisual>();
        }

        public abstract void Interact();
        public abstract void InteractFromCallBack();

        private void OnDestroy()
        {
            if (interactionIsACallBack)
                EventsManager.OnRoomCleared -= InteractFromCallBack;
        }
    }

    /*[CustomEditor(typeof(InteractableItem))]
    public class Interctable_Editor : Editor
    {
        
    } */
}