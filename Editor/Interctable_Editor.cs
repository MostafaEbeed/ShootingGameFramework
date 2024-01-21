using GunSystem;
using InteractionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InteractableItem))]
public class Interctable_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (InteractableItem)target;

        script.itemType.itemCategory = (ItemCategory)EditorGUILayout.EnumPopup("Item Category", script.itemType.itemCategory);
        script.interactionIsACallBack = EditorGUILayout.Toggle("Is A Callback", script.interactionIsACallBack);
        if (script.interactionIsACallBack == false) { }
        else { }

        if (script.itemType.itemCategory == ItemCategory.Gun)
        {
            script.itemType.weaponCharactaristics = EditorGUILayout.ObjectField("Charactaristics", script.itemType.weaponCharactaristics, typeof(WeaponCharactaristics), true) as WeaponCharactaristics;
            script.itemType.prefab = EditorGUILayout.ObjectField("Prefab", script.itemType.prefab, typeof(GameObject), true) as GameObject;

        }
        else if (script.itemType.itemCategory == ItemCategory.Mod)
        {
            script.itemType.modType = (ModType)EditorGUILayout.EnumPopup("Mod Type", script.itemType.modType);
            script.itemType.modifier = (Modifier)EditorGUILayout.ObjectField("Modifier", script.itemType.modifier, typeof(Modifier), true);
            script.itemType.prefab = EditorGUILayout.ObjectField("Prefab", script.itemType.prefab, typeof(GameObject), true) as GameObject;
            script.shouldHaveMeshHolder = EditorGUILayout.Toggle("Have Mesh Holder", script.shouldHaveMeshHolder);
            if (script.shouldHaveMeshHolder == false) return;

            if (script.shouldHaveMeshHolder == true)
            {
                script.meshHolder = EditorGUILayout.ObjectField("Mesh Holder", script.meshHolder, typeof(Transform), true) as Transform;
            }
        }
        else if (script.itemType.itemCategory == ItemCategory.EnvItem)
        {
            //script.interactionVisual = EditorGUILayout.ObjectField("Interaction Visual", script.meshHolder, typeof(InteractionVisual), true) as InteractionVisual;
            script.shouldHaveMeshHolder = EditorGUILayout.Toggle("Have Mesh Holder", script.shouldHaveMeshHolder);
            if (script.shouldHaveMeshHolder == false) return;

            if (script.shouldHaveMeshHolder == true)
            {
                script.meshHolder = EditorGUILayout.ObjectField("Mesh Holder", script.meshHolder, typeof(Transform), true) as Transform;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
