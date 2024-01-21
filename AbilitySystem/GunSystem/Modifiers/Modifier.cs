using UnityEngine;

namespace GunSystem
{
    public enum GunModifierType
    {
        DamageMod,
        FireRateMod,
        ExplosiveShellMod
    }

    [CreateAssetMenu(fileName = "Modifiers", menuName = "GunSystem/Modifiers/Modifier")]
    public class Modifier : ScriptableObject
    {
        [SerializeField] protected WeaponCategory category;
        [SerializeField] protected GunModifierType modifierType;
        [SerializeField] protected float modValue;

        public float ModValue => modValue;
        public WeaponCategory Category => category;
        public GunModifierType ModType => modifierType;
    }
}