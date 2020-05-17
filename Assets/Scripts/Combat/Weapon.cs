using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapons", menuName = "RPG World/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] bool isRightWield = true;

        public void Spawn(Transform rightHandTransform, Transform leftHandTransform, Animator animator)
        {
            if (weaponPrefab != null)
            {
                Transform handTransform;
                if (isRightWield)
                {
                    handTransform = rightHandTransform;
                }
                else 
                {
                    handTransform = leftHandTransform;
                }
                Instantiate(weaponPrefab, handTransform);
            }
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
        }

        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetRange()
        {
            return weaponRange;
        }
    }
}
