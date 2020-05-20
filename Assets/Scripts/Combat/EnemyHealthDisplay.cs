using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter = null;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            Health target = fighter.GetTarget();
            if (target == null)
            {
                GetComponent<Text>().text = String.Format("N/A");
            }
            else
            {
                GetComponent<Text>().text = String.Format("{0:0}%", target.GetPercentage());
            }
        }
    }
}
