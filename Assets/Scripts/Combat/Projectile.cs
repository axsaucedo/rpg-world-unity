﻿using UnityEngine;
using RPG.Attributes;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 1;
        [SerializeField] bool isHoming = true;
        [SerializeField] GameObject hitEffect = null;
        [SerializeField] float maxLifetTime = 10f;

        Health target = null;
        GameObject instigator = null;
        float damage = 0;

        private void Start()
        {
            transform.LookAt(GetAimLocation());
        }

        private void Update()
        {
            if (target == null) return;

            if (isHoming && !target.IsDead())
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        public void SetTarget(Health target, GameObject instigator, float damage)
        {
            this.target = target;
            this.instigator = instigator;
            this.damage = damage;

            Destroy(gameObject, maxLifetTime);
        }

        private Vector3 GetAimLocation()
        {
            // Arrow shoots at feet so this ensures arrow aims at middle of capsule collider
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return target.transform.position;
            }
            return target.transform.position + (Vector3.up * targetCapsule.height / 2);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (target.IsDead()) return;
            if (other.GetComponent<Health>() != target) return;

            target.TakeDamage(instigator, damage);

            if (hitEffect != null)
            {
                Instantiate(hitEffect, GetAimLocation(), transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
