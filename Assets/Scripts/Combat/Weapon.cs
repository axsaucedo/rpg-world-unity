using System.Collections;
using System.Collections.Generic;
using RPG.Core;
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
        [SerializeField] Projectile projectile = null;

        public void Spawn(Transform rightHandTransform, Transform leftHandTransform, Animator animator)
        {
            if (weaponPrefab != null)
            {
                Transform handTransform = GetTransform(rightHandTransform, leftHandTransform);
                Instantiate(weaponPrefab, handTransform);
            }
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
        }

        private Transform GetTransform(Transform rightHandTransform, Transform leftHandTransform)
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

            return handTransform;
        }

        public bool HasProjectile()
        {
            return projectile != null;
        }

        public void LaunchProjectile(Transform rightHandTransform, Transform leftHandTransform, Health target)
        {
            Transform handTransform = GetTransform(rightHandTransform, leftHandTransform);
            Projectile projectileInstance = Instantiate(projectile, handTransform.position, Quaternion.identity);
            projectileInstance.SetTarget(target, weaponDamage);
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
