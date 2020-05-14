using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{        
    public class Fighter : MonoBehaviour 
    {
        [SerializeField] float weaponRange = 2f;

        Transform target;

        private void Update() {
            if (target != null)
            {
                bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
                Mover mover = GetComponent<Mover>();
                if (!isInRange)
                {
                    mover.MoveTo(target.position);
                }
                else
                {
                    mover.Stop();
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}

